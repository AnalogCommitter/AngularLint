using System.Linq;
using Formula1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Formula1.CoreTest
{
    [TestClass()]
    public class ImportControllerTests
    {
        /// <summary>
        /// Als erste Übung die Rennen aus der XML-Datei parsen
        /// </summary>
        [TestMethod()]
        public void T01_LoadRacesFromRacesXmlTest()
        {
            var races = ImportController.LoadRacesFromRacesXml().ToList();
            Assert.AreEqual(21, races.Count);
            Assert.AreEqual("Melbourne", races.First().City);
            Assert.AreEqual(1, races.First().Number);
            Assert.AreEqual("Abu Dhabi", races.Last().City);
            Assert.AreEqual(21, races.Last().Number);


            Assert.AreEqual(-1, races.Last().Number);
        }

        /// <summary>
        /// Alle Results in Collections laden.
        /// </summary>
        [TestMethod()]
        public void T02_LoadResultsFromResultsXmlTest()
        {
            var results = ImportController.LoadResultsFromXmlIntoCollections();
            Assert.AreEqual(10, results.GroupBy(res => res.Team).Count());
            Assert.AreEqual(20, results.GroupBy(res => res.Driver).Count());
            Assert.AreEqual(420, results.Length);
        }
        /// <summary>
        /// Results von Verstappen
        /// </summary>
        [TestMethod()]
        public void T03_LoadVerstappenResults()
        {
            var results = ImportController.LoadResultsFromXmlIntoCollections().ToList();

            // TODO: Query for Verstappen
            var verstappenResults = results
                .Where(r => r.Driver.Name == "Verstappen Max")
                .ToArray();

            Assert.AreEqual(21, verstappenResults.Length);
            Assert.AreEqual(3, verstappenResults[0].Position);
            Assert.AreEqual(4, verstappenResults[15].Position);
        }

    }

}