using BerlinClock.Converter;
using BerlinClock.Model.Interface;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class BerlinClockTimeConverterTests
    {
        private BerlinClockTimeConverter _berlicClockConverter;
        private Mock<ISecondLamps> _secondLamps;
        private Mock<IMinuteLamps> _minuteLamps;
        private Mock<IHourLamps> _hourLamps;

        [SetUp]
        protected void SetUp()
        {
            _secondLamps = new Mock<ISecondLamps>();
            _minuteLamps = new Mock<IMinuteLamps>();
            _hourLamps = new Mock<IHourLamps>();

            _berlicClockConverter = new BerlinClockTimeConverter(_secondLamps.Object, _minuteLamps.Object, _hourLamps.Object);
        }

        [TestCase("13:17:01", "O\r\nRROO\r\nRRRO\r\nYYROOOOOOOO\r\nYYOO")]
        public void should_return_lampsLine_for_correct_time(string time, string expectedLamps)
        {
            _hourLamps.Setup(m => m.SetLamps(It.IsAny<int>())).Returns("RROO\r\nRRRO");
            _minuteLamps.Setup(m => m.SetLamps(It.IsAny<int>())).Returns("YYROOOOOOOO\r\nYYOO");
            _secondLamps.Setup(m => m.SetLamps(It.IsAny<int>())).Returns("O");
            
            var berlinClockLampsLines = _berlicClockConverter.convertTime(time);

            Assert.AreEqual(expectedLamps, berlinClockLampsLines);
        }

        [TestCase("24:01:00")]
        public void should_return_exception_for_incorrect_time(string time)
        {
            Assert.Throws<System.ArgumentException>(() => _berlicClockConverter.convertTime(time));
        }
    }
}
