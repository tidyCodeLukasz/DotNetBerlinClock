using BerlinClock.Model;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class SecondLampsTests
    {
        private SecondLamps _secondLamps;

        [SetUp]
        protected void SetUp()
        {
            _secondLamps = new SecondLamps();
        }

        [TestCase(1)]
        [TestCase(3)]
        public void should_return_O_when_secends_are_odd(int seconds)
        {
            var lamp = _secondLamps.SetLamps(seconds);
            Assert.AreEqual("O", lamp);
        }

        [TestCase(0)]
        [TestCase(4)]
        public void should_return_Y_when_secends_are_even(int seconds)
        {
            var lamp = _secondLamps.SetLamps(seconds);
            Assert.AreEqual("Y", lamp);
        }

        [TestCase(60)]
        [TestCase(-1)]
        public void should_return_exception_for_incorrect_seconds(int seconds)
        {
            Assert.Throws<System.ArgumentException>(() => _secondLamps.SetLamps(seconds));
        }
    }
}
