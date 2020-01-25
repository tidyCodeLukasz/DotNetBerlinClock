using BerlinClock.Model.Interface;
using System;

namespace BerlinClock.Model
{
    public class HourLamps : BaseLamps, IHourLamps
    {
        public string SetLamps(int hours)
        {
            if (hours < 0 || hours > 24)//24 is a valid time? (the max time is 23:59:59) I decided to support this to pass BDD tests
            {
                throw new ArgumentException("Hours must be in range of 00 - 24");
            }

            int fiveHoursLamps = hours / 5;
            int singileHourLamps = hours % 5;

            return SetLampsLine(fiveHoursLamps, ClockLights.Red) + "\r\n" + SetLampsLine(singileHourLamps, ClockLights.Red);
        }
    }
}
