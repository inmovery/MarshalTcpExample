using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using Domain.Contracts;
using Domain.Models;

namespace Client
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var tcpChannel = new TcpChannel();
			ChannelServices.RegisterChannel(tcpChannel, ensureSecurity: false);

			RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.On;

			var randomNumberGenerator = (IRandomNumberGenerator)RemotingServices.Connect(
				classToProxy: typeof(IRandomNumberGenerator),
				url: "tcp://localhost:12345/RandomNumberGenerator.rem");

			var randomNumber = randomNumberGenerator.GenerateRandomNumber();

			Console.WriteLine($"Random number = {randomNumber}");

			Console.ReadKey();
		}

		private static void OtherUseCase()
		{
			var remoteObject = (IRemoteObject)Activator.GetObject(
				typeof(IRemoteObject),
				url: "tcp://localhost:12345/RemoteObjectUri");

			var person = new Person
			{
				Name = "Roman",
				Age = 23
			};

			remoteObject.PrintPersonDetails(person);
		}
	}
}
