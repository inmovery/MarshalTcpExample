using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using Domain.Features;

namespace Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var serverSinkProvider = new BinaryServerFormatterSinkProvider
			{
				TypeFilterLevel = TypeFilterLevel.Full
			};

			var clientSinkProvider = new BinaryClientFormatterSinkProvider();

			var properties = new Hashtable
			{
				["port"] = 12345
			};

			var tcpChannel = new TcpChannel(properties, clientSinkProvider, serverSinkProvider);

			ChannelServices.RegisterChannel(tcpChannel, ensureSecurity: false);

			var randomNumberGenerator = new RandomNumberGenerator();

			RemotingServices.Marshal(randomNumberGenerator, URI: "RandomNumberGenerator.rem");

			Console.WriteLine($"Channel Name: {tcpChannel.ChannelName}");
			Console.WriteLine($"Channel Priority: {tcpChannel.ChannelPriority}");

			var channelDataStore = (ChannelDataStore)tcpChannel.ChannelData;
			foreach (var uri in channelDataStore.ChannelUris)
			{
				Console.WriteLine(uri);
			}

			Console.WriteLine("Server started. Press any key to stop.");
			Console.ReadKey();

			RemotingServices.Disconnect(randomNumberGenerator);

			ChannelServices.UnregisterChannel(tcpChannel);
		}
	}
}