using BerlinClock.Model;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class MinuteLampsTests
    {
        private MinuteLamps _minuteLamps;

        [SetUp]
        protected void SetUp()
        {
            _minuteLamps = new MinuteLamps();
        }

        [TestCase(0,"OOOOOOOOOOO\r\nOOOO")]
        [TestCase(1, "OOOOOOOOOOO\r\nYOOO")]
        [TestCase(6, "YOOOOOOOOOO\r\nYOOO")]
        [TestCase(59, "YYRYYRYYRYY\r\nYYYY")]
        public void should_return_lamps_for_minutes(int minutes, string expectedLamps)
        {
            var lamps = _minuteLamps.SetLamps(minutes);

            Assert.AreEqual(expectedLamps, lamps);
        }

        [TestCase(60)]
        [TestCase(-1)]
        public void should_return_exception_for_incorrect_minutes(int minutes)
        {
            Assert.Throws<System.ArgumentException>(() => _minuteLamps.SetLamps(minutes));
        }
    }
}
