using System;

namespace Domain.Models
{
	public class CounterRemoteObject : MarshalByRefObject
	{
		private int _count;

		public int Count => _count++;
	}
}
