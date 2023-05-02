using System;
using System.Text;
using Microsoft.Azure.ServiceBus;

namespace Services.ServiceBus.Implementation
{
	public class ServiceBus : IServiceBus
	{
        public ServiceBus()
		{
		}

        public async Task Send(string message, string queue)
        {
            QueueClient queueClient = new QueueClient("<connection-string>", queue);

            Message messagebus = new Message(Encoding.UTF8.GetBytes(message));
            await queueClient.SendAsync(messagebus);
        }
    }
}

