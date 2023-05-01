using Domain.Contracts;
using System;

namespace Domain.Features
{
	public class RandomNumberGenerator : MarshalByRefObject, IRandomNumberGenerator
	{
		private readonly Random _random = new Random();

		public int GenerateRandomNumber()
		{
			return _random.Next();
		}
	}
}
