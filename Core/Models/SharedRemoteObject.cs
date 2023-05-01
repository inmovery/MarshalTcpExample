using System;
using Domain.Contracts;

namespace Domain.Models
{
	public class SharedRemoteObject : MarshalByRefObject, IRemoteObject
	{
		public SharedRemoteObject()
		{
			Console.WriteLine("Ctor of remote object was invoked.");
		}

		public void PrintPersonDetails(Person person)
		{
			Console.WriteLine($"Received person with name '{person.Name}' and age '{person.Age}'.");
		}
	}
}
