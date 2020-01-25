using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void should_return_true_for_valid_time()
        {
            var isValid = "21:23:12".IsValidTimeFormat();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void should_return_false_for_invalid_time()
        {
            var isValid = "24:01:01".IsValidTimeFormat();

            Assert.IsFalse(isValid);
        }

        [Test]
        public void should_return_true_for_twenyFour_midtnight()
        {
            var isValid = "24:00:00".IsValidTimeFormat();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void should_return_true_for_midtnight()
        {
            var isValid = "00:00:00".IsValidTimeFormat();

            Assert.IsTrue(isValid);
        }

        [Test]
        public void should_return_false_for_invalid_seconds()
        {
            var isValid = "00:00:60".IsValidTimeFormat();

            Assert.IsFalse(isValid);
        }

        public void should_return_false_for_invalid_minutes()
        {
            var isValid = "00:60:00".IsValidTimeFormat();

            Assert.IsFalse(isValid);
        }

        public void should_return_false_for_invalid_hour()
        {
            var isValid = "25:00:00".IsValidTimeFormat();

            Assert.IsFalse(isValid);
        }
    }
}
