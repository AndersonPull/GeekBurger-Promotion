using System;
namespace Services.ServiceBus
{
	public interface IServiceBus
	{
		Task Send(string message, string queue);
	}
}