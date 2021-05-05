using System;
using System.Numerics;

namespace Karatsuba
{
	public class Karatsuba
	{
		public BigInteger karaMult(BigInteger x, BigInteger y)
		{
			int n = (int)Math.Max(BitLength(x), BitLength(y));
			if (n <= 10000) return x * y;

			n = ((n + 1) / 2);

			BigInteger b = x >> n;
			BigInteger a = x - (b << n);
			BigInteger d = y >> n;
			BigInteger c = y - (d << n);

			BigInteger ac = karaMult(a, c);
			BigInteger bd = karaMult(b, d);
			BigInteger abcd = karaMult(a + b, c + d);

			return ac + ((abcd - ac - bd) << n) + (bd << (2 * n));
		}

		public int BitLength(BigInteger n)
		{
			byte[] Data = n.ToByteArray();
			int result = (Data.Length - 1) * 8;
			byte Msb = Data[Data.Length - 1];
			while (Msb != 0)
			{
				result += 1;
				Msb >>= 1;
			}
			return result;
		}

		public BigInteger multiply(BigInteger x, BigInteger y)
		{
			return x * y;
		}
	}
}
