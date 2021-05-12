using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Karatsuba
{
	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class KaratsubaBenchmarks
	{
		public static readonly Karatsuba karatsuba = new Karatsuba();

		private BigInteger number = BigInteger.Pow(UInt64.MaxValue, 5000);

		[Benchmark]
		public void karaMultiSmall()
		{
			karatsuba.karaMult(123, 123);
		}

		[Benchmark]
		public void MultiSmall()
		{
			karatsuba.multiply(123, 123);
		}
		
		[Benchmark]
		public void karaMultiLarge()
		{
			karatsuba.karaMult(number,number);
		}

		[Benchmark]
		public void MultiLarge()
		{
			karatsuba.multiply(number, number);
		}

		//[Benchmark]
		//public void karaMultiArr()
		//{
		//	karatsuba.karaMultiplyArr();
		//}
	}
}
