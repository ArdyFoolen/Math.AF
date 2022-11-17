using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.AF.Tests
{
    public class PiTests
    {
        [Test]
        public void NotARealTest()
        {
            var bytes = $"3.{string.Concat(Pi.PiDigits(0x100).Take(100).Select(_ => $"{_.ToString("x2")} "))}";
            var words = $"3.{string.Concat(Pi.PiDigits(0x10000).Take(100).Select(_ => $"{_.ToString("x4")} "))}";
            var dwords = $"3.{string.Concat(Pi.PiDigits(0x100000000).Take(100).Select(_ => $"{_.ToString("x8")} "))}";
            var result10 = $"3.{string.Concat(Pi.PiDigits().Take(100).Select(_ => _.ToString("d")))}";
            var result16 = $"3.{string.Concat(Pi.PiDigits(16).Take(100).Select(_ => _.ToString("x")))}";
            var blowfishKey = $"{string.Concat(Pi.PiDigits(16).Take(144).Select(_ => _.ToString("x")))}";
            var blowfishS1 = $"{string.Concat(Pi.PiDigits(16).Skip(144).Take(2048).Select(_ => _.ToString("x")))}";
            var blowfishS2 = $"{string.Concat(Pi.PiDigits(16).Skip(2192).Take(2048).Select(_ => _.ToString("x")))}";
            var blowfishS3 = $"{string.Concat(Pi.PiDigits(16).Skip(4240).Take(2048).Select(_ => _.ToString("x")))}";
            var blowfishS4 = $"{string.Concat(Pi.PiDigits(16).Skip(6288).Take(2048).Select(_ => _.ToString("x")))}";
        }

        private ulong[] HexPiDigits = new ulong[]
        {
            0x2,0x4,0x3,0xF,0x6,0xA,0x8,0x8,0x8,0x5,0xA,0x3,0x0,0x8,0xD,0x3,0x1,0x3,0x1,0x9,0x8,0xA,0x2,0xE,0x0,0x3,0x7,0x0,0x7,0x3
        };

        private ulong[] DecPiDigits = new ulong[]
        {
            0x1,0x4,0x1,0x5,0x9,0x2,0x6,0x5,0x3,0x5,0x8,0x9,0x7,0x9,0x3,0x2,0x3,0x8,0x4,0x6,0x2,0x6,0x4,0x3,0x3,0x8,0x3,0x2,0x7,0x9
        };

        [Test]
        public void PiDigits_Hex_Succeeds()
        {
            // Act
            var result = Pi.PiDigits(16).Take(30).ToArray();

            // Assert
            Assert.That(result, Is.EquivalentTo(HexPiDigits));
        }

        [Test]
        public void PiDigits_Dec_Succeeds()
        {
            // Act
            var result = Pi.PiDigits(10).Take(30).ToArray();

            // Assert
            Assert.That(result, Is.EquivalentTo(DecPiDigits));
        }
    }
}
