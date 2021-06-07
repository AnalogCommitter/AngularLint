using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Formula1.CoreTest
{
    [TestClass()]
    public class ResultCalculatorTests
    {
        [TestMethod()]
        public void R01_GetDriverWmTableTest()
        {
            var driverResults = ResultCalculator.GetDriverWmTable().ToArray();
            Assert.AreEqual("Hamilton Lewis", driverResults[0].Competitor.Name);
            Assert.AreEqual(413, driverResults[0].Points);
            Assert.AreEqual(1, driverResults[0].Position);
            // Bei gleichen Punkten nach Namen sortieren
            Assert.AreEqual("Hülkenberg Nico", driverResults[12].Competitor.Name);
            Assert.AreEqual(13, driverResults[12].Position);
            Assert.AreEqual(37, driverResults[12].Points);
        }

        [TestMethod()]
        public void R02_GetTeamWmTableTest()
        {
            var teamResults = ResultCalculator.GetTeamWmTable().ToArray();
            Assert.AreEqual("Mercedes", teamResults[0].Competitor.Name);
            Assert.AreEqual(739, teamResults[0].Points);
            Assert.AreEqual("Haas F1 Team", teamResults[8].Competitor.Name);
            Assert.AreEqual(28, teamResults[8].Points);
        }

        [TestMethod()]
        public void R03_GetFastestRoundsTeamTest()
        {
            
        }

        [TestMethod()]
        public void R03_GetFastestRoundsDriverTest()
        {
            
        }

    }
}