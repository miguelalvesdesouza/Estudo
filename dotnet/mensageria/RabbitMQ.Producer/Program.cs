using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// Declara a fila (se não existir, cria)
channel.QueueDeclare(queue: "fila_teste", durable: false, exclusive: false, autoDelete: false, arguments: null);

for (int i = 1; i <= 5; i++)
{
    string message = $"Mensagem {i}";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "", routingKey: "fila_teste", basicProperties: null, body: body);
    Console.WriteLine($"[x] Enviou: {message}");
}

Console.WriteLine("Pressione qualquer tecla para sair.");
Console.ReadKey();
