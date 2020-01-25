using BerlinClock.Model;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class HourLampsTests
    {
        private HourLamps _hourLamps;

        [SetUp]
        protected void SetUp()
        {
            _hourLamps = new HourLamps();
        }

        [TestCase(0, "OOOO\r\nOOOO")]
        [TestCase(1, "OOOO\r\nROOO")]
        [TestCase(5, "ROOO\r\nOOOO")]
        [TestCase(23, "RRRR\r\nRRRO")]
        [TestCase(24, "RRRR\r\nRRRR")]
        public void should_return_lamps_for_hours(int hours, string expectedLamps)
        {
            var lamps = _hourLamps.SetLamps(hours);

            Assert.AreEqual(expectedLamps, lamps);
        }

        [TestCase(25)]
        [TestCase(-1)]
        public void should_return_exception_for_incorrect_hours(int hours)
        {
            Assert.Throws<System.ArgumentException>(()=> _hourLamps.SetLamps(hours));
        }
    }
}
