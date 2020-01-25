using BerlinClock.Model.Interface;
using System;
using System.Text;

namespace BerlinClock.Model
{
    public class MinuteLamps : BaseLamps, IMinuteLamps
    {
        public string SetLamps(int minutes)
        {
            if (minutes < 0 || minutes >= 60)
            {
                throw new ArgumentException("Minutes must be in range of 00 - 24");
            }

            int fiveMinutesLamps = minutes / 5;
            int singileMinuteLamps = minutes % 5;

            return SetLampsForFiveMinutesGroup(fiveMinutesLamps) + "\r\n" + SetLampsLine(singileMinuteLamps, ClockLights.Yellow);
        }

        private string SetLampsForFiveMinutesGroup(int fiveMinutesLamp)
        {
            StringBuilder lamps = new StringBuilder();
            int i;

            for (i = 0; i < fiveMinutesLamp; i++)
            {
                if (i % 3 == 2)
                {
                    lamps.Append(ClockLights.Red);
                }
                else
                {
                    lamps.Append(ClockLights.Yellow);
                }
            }

            for (int j = i; j < 11; j++)
            {
                lamps.Append(ClockLights.No_light);
            }

            return lamps.ToString();
        }
    }
}
