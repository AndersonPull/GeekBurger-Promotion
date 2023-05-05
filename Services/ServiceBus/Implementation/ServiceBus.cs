using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace Services.ServiceBus.Implementation
{
	public class ServiceBus : IServiceBus
	{
        private readonly IConfiguration _configuracao;
        public ServiceBus(IConfiguration configuracao)
		{
            _configuracao = configuracao;
        }

        public async Task Send(string message, string queue)
        {
            QueueClient queueClient = new QueueClient(_configuracao["ServicebusServer"], queue);

            Message messagebus = new Message(Encoding.UTF8.GetBytes(message));
            await queueClient.SendAsync(messagebus);
        }
    }
}