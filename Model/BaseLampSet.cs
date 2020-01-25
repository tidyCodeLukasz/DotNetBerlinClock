using System.Text;

namespace BerlinClock.Model
{
    public abstract class BaseLamps
    {
        protected string SetLampsLine(int lampsToSet, string lightColor)
        {
            StringBuilder lamps = new StringBuilder();
            int i;

            for (i = 0; i < lampsToSet; i++)
            {
                lamps.Append(lightColor);
            }

            for (int j = i; j < 4; j++)
            {
                lamps.Append(ClockLights.No_light);
            }

            return lamps.ToString();
        }
    }
}