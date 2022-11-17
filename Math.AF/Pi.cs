using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math.AF
{
    public class Pi
    {
        // Convert Pi to Pi in hex
        // Link: https://math.stackexchange.com/questions/1231826/how-to-convert-pi-to-base-16
        // π = 3.141592653589793238462643383279
        // in hex = 3.243F6A8885A308D313198A2E037073

        // a0 = 3.141592653589793238462643383279 = 3
        // a1 = 16 * .1415926535897932384626433832795 = 2
        // a2 = 16 * (a1 result - 2) = 4
        // a3 = 16 * (a2 result - 4) = 3
        // a4 = 16 * (a3 result - 3) = 15 = F
        // a5 = 16 * (a4 result - 15) = 6
        // a6 = 16 * (a5 result - 6) = 10 = A
        // a7 = 16 * (a6 result - 10) = 8
        // a8 = 16 * (a7 result - 8) = 8
        // a9 = 16 * (a8 result - 8) = 8
        // a10 = 16 * (a9 result - 8) = 5
        // a11 = 16 * (a10 result - 5) = A

        /// <summary>Enumerates the digits of PI.</summary>
        /// Link: https://rosettacode.org/wiki/Pi#C#
        /// <param name="base">Base of the Numeral System to use for the resulting digits (default = Base.Decimal (10)).</param>
        /// <returns>The digits of PI.</returns>
        public static IEnumerable<long> PiDigits(long @base = 10)
        {
            BigInteger
              k = 1,
              l = 3,
              n = 3,
              q = 1,
              r = 0,
              t = 1
              ;

            // skip integer part
            var nr = @base * (r - t * n);
            n = @base * (3 * q + r) / t - @base * n;
            q *= @base;
            r = nr;

            for (; ; )
            {
                var tn = t * n;
                if (4 * q + r - t < tn)
                {
                    yield return (long)n;
                    nr = @base * (r - tn);
                    n = @base * (3 * q + r) / t - @base * n;
                    q *= @base;
                }
                else
                {
                    t *= l;
                    nr = (2 * q + r) * l;
                    var nn = (q * (7 * k) + 2 + r * l) / t;
                    q *= k;
                    l += 2;
                    ++k;
                    n = nn;
                }
                r = nr;
            }
        }

        public static IEnumerable<uint> HexPiToUints(int skip, int take)
            => Pi.PiDigits(16)
            .Skip(skip * 8)
            .Take(take * 8)
            .Chunk(8)
            .Select(m => m.Aggregate((uint)0x00000000, (acc, a) => acc << 4 | (byte)a));

    }
}
