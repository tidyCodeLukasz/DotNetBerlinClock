using BerlinClock.Model.Interface;
using System;

namespace BerlinClock.Model
{
    public class SecondLamps : ISecondLamps
    {
        public string SetLamps(int seconds)
        {
            if (seconds < 0 || seconds >= 60)
            {
                throw new ArgumentException("Seconds must be in range of 00 - 60");
            }

            return seconds % 2 == 0 ? ClockLights.Yellow : ClockLights.No_light;
        }
    }
}
