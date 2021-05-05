using System;
using System.Numerics;
using BenchmarkDotNet.Running;

namespace Karatsuba
{
	class Program
	{
		

		public static void Main(String[] args)
		{
			Karatsuba karatsuba = new Karatsuba();
			Console.WriteLine(karatsuba.karaMult(BigInteger.Pow(UInt64.MaxValue, 300), BigInteger.Pow(UInt64.MaxValue, 300)));
			BenchmarkRunner.Run <KaratsubaBenchmarks> ();
		}
	}
}
