using System;
using System.Collections.Generic;
using System.Text;

namespace Karatsuba
{
	class BingIntegerMul
	{
        public static BigInteger operator *(BigInteger left, BigInteger right)
        {
            left.AssertValid();
            right.AssertValid();

            int sign = +1;
            BigIntegerBuilder reg1 = new BigIntegerBuilder(left, ref sign);
            BigIntegerBuilder reg2 = new BigIntegerBuilder(right, ref sign);

            reg1.Mul(ref reg2);
            return reg1.GetInteger(sign);
        }

        // This version may share memory with regMul.
        public void Mul(ref BigIntegerBuilder regMul)
        {
            AssertValid(true);
            regMul.AssertValid(true);

            if (regMul._iuLast == 0)
                Mul(regMul._uSmall);
            else if (_iuLast == 0)
            {
                uint u = _uSmall;
                if (u == 1)
                    this = new BigIntegerBuilder(ref regMul);
                else if (u != 0)
                {
                    Load(ref regMul, 1);
                    Mul(u);
                }
            }
            else
            {
                int cuBase = _iuLast + 1;
                SetSizeKeep(cuBase + regMul._iuLast, 1);

                for (int iu = cuBase; --iu >= 0;)
                {
                    uint uMul = _rgu[iu];
                    _rgu[iu] = 0;
                    uint uCarry = 0;
                    for (int iuSrc = 0; iuSrc <= regMul._iuLast; iuSrc++)
                        uCarry = AddMulCarry(ref _rgu[iu + iuSrc], regMul._rgu[iuSrc], uMul, uCarry);
                    if (uCarry != 0)
                    {
                        for (int iuDst = iu + regMul._iuLast + 1; uCarry != 0 && iuDst <= _iuLast; iuDst++)
                            uCarry = AddCarry(ref _rgu[iuDst], 0, uCarry);
                        if (uCarry != 0)
                        {
                            SetSizeKeep(_iuLast + 2, 0);
                            _rgu[_iuLast] = uCarry;
                        }
                    }
                }
                AssertValid(true);
            }
        }
    }
