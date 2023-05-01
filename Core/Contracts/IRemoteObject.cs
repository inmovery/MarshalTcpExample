using Domain.Models;

namespace Domain.Contracts
{
	public interface IRemoteObject
	{
		void PrintPersonDetails(Person person);
	}
}
