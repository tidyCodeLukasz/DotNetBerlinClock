using BerlinClock.Model.Interface;
using System;
using System.Text;

namespace BerlinClock.Converter
{
    public class BerlinClockTimeConverter : ITimeConverter
    {
        private readonly ISecondLamps _secondLamps;
        private readonly IMinuteLamps _minuteLamps;
        private readonly IHourLamps _hourLamps;

        public BerlinClockTimeConverter(ISecondLamps secondLamps, IMinuteLamps minuteLamps, IHourLamps hourLamps)
        {
            _secondLamps = secondLamps;
            _minuteLamps = minuteLamps;
            _hourLamps = hourLamps;
        }

        public string convertTime(string aTime)
        {
            if (!aTime.IsValidTimeFormat())
            {
                throw new ArgumentException("Time must be in the format HH:MM:SS");
            }

            string[] timeElements = aTime.Split(':');
            StringBuilder lampsLines = new StringBuilder();

            lampsLines.AppendLine(_secondLamps.SetLamps(int.Parse(timeElements[2])))
                .AppendLine(_hourLamps.SetLamps(int.Parse(timeElements[0])))
                .Append(_minuteLamps.SetLamps(int.Parse(timeElements[1])));

            return lampsLines.ToString();
        }
    }
}
