using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Converter;
using BerlinClock.Model;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {

        private ITimeConverter berlinClock = new BerlinClockTimeConverter(new SecondLamps(), new MinuteLamps(), new HourLamps());
        private String theTime;


        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.convertTime(theTime), theExpectedBerlinClockOutput);
        }

    }
}
