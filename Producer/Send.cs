using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
              {
                  HostName = "localhost"
              };
using var connection = factory.CreateConnection();
using var channel    = connection.CreateModel();

channel.QueueDeclare("hello", false, false, false,null);

const string message = "Hello rabbitMQ!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty, "hello", null, body);

Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit");
Console.ReadLine();
