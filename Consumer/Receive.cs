
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;


var factory = new ConnectionFactory
              {
                  HostName = "localhost"
              };
using var connection = factory.CreateConnection();
using var channel    = connection.CreateModel();

channel.QueueDeclare("hello", false, false, false, null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body    = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};

channel.BasicConsume("hello", true, consumer);

Console.WriteLine(" Press [enter] to exit");
Console.ReadLine();
