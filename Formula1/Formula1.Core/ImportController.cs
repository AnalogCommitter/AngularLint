using Formula1.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Utils;

namespace Formula1.Core
{
    /// <summary>
    /// Daten sind in XML-Dateien gespeichert und werden per Linq2XML
    /// in die Collections geladen.
    /// </summary>
    public static class ImportController
    { 
        /// <summary>
        /// Daten der Rennen werden per Linq2XML aus der
        /// XML-Datei ausgelesen und in die Races-Collection gespeichert.
        /// Races werden nicht aus den Results geladen, weil sonst die
        /// Rennen in der Zukunft fehlen
        /// </summary>
        public static Race[] LoadRacesFromRacesXml()
        {
            // TODO 01 LoadRacesFromRacesXml
            XElement races = XDocument.Load(MyFile.GetFullNameInApplicationTree("Races.xml")).Root;
            if (races == null) return null;
            return races.Elements("Race")
                .Select(r => new Race
                {
                    Number = (int)r.Attribute("round"),
                    Date = (DateTime)r.Element("Date"),
                    Country = r.Element("Circuit")?.Element("Location")?
                    .Element("Country")?.Value,
                    City = r.Element("Circuit")?.Element("Location")?
                    .Element("Locality")?.Value
                }).ToArray();
        }

        /// <summary>
        /// Aus den Results werden alle Collections, außer Races gefüllt.
        /// Races wird extra behandelt, um auch Rennen ohne Results zu verwalten
        /// </summary>
        public static Result[] LoadResultsFromXmlIntoCollections()
        {
            List<Team> teams = new List<Team>();
            List<Driver> drivers = new List<Driver>();
            Race[] races = LoadRacesFromRacesXml();
            // TODO 02 LoadResultsFromXmlIntoCollections
            XElement results = XDocument.Load(MyFile.GetFullNameInApplicationTree("Results.xml")).Root;
            if (results == null) return null;
            return results.Elements("Race")?.Elements("ResultsList")?.Elements("Result")?.Select(r =>
            new Result
            {
                Race = GetRace(r.Parent.Parent, races),
                Driver = GetDriver(r.Element("Driver"), drivers),
                Team = GetTeam(r, teams),
                Points = (int)r.Attribute("points"),
                Position = (int)r.Attribute("position")
            }).ToArray();
        }

        public static List<TotalResultDto<Driver>> GetFastestLapDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            XElement results = XDocument.Load(MyFile.GetFullNameInApplicationTree("results.xml")).Root;
            if (results == null)
            {
                return null;
            }

            var fastestLapDrivers = results
                .Elements("Race")?.Elements("ResultsList")?.Elements("Result")?
                .Elements("FastestLap").Where(x => x.Attribute("rank").Value == "1").Select(r =>
                new
                {
                    Driver = GetDriver(r.Parent.Element("Driver"), drivers)
                });
            return fastestLapDrivers.GroupBy(d => d.Driver).Select(r =>
                new TotalResultDto<Driver>
                {
                    Competitor = r.Key,
                    Points = r.Count()
                })
                .OrderByDescending(d => d.Points)
                .ThenBy(d => d.Competitor.Name)
                .ToList();
        }

        public static List<TotalResultDto<Team>> GetFastestLapTeams()
        {
            List<Team> teams = new List<Team>();
            XElement results = XDocument.Load(MyFile.GetFullNameInApplicationTree("results.xml")).Root;
            if (results == null)
            {
                return null;
            }

            var fastestLapTeams = results.Elements("Race")?.Elements("ResultsList")?
                    .Elements("Result")?.Elements("FastestLap")
                    .Where(x => x.Attribute("rank").Value == "1")
                    .Select(r =>
                new
                {
                    Team = GetTeam(r.Parent, teams)
                });
            return fastestLapTeams.GroupBy(t => t.Team).Select(r =>
                new TotalResultDto<Team>
                {
                    Competitor = r.Key,
                    Points = r.Count()
                })
                .OrderByDescending(t => t.Points)
                .ThenBy(d => d.Competitor.Name)
                .ToList();
        }

        /// <summary>
        /// Team wird aus XML vom einzelnen Result geparst. 
        /// Wenn es noch nicht in der Teamliste ist, wird es eingefügt und zurückgegeben.
        /// Sonst wird das Element aus der Teamliste zurückgegeben
        /// </summary>
        /// <param name="result"></param>
        /// <param name="teams"></param>
        /// <returns></returns>
        private static Team GetTeam(XElement result, List<Team> teams)
        {
            // TODO 02_1 GetTeam
            XElement team = result.Element("Constructor");
            Team found = teams.SingleOrDefault(d => d.Name == (string)team.Element("Name"));
            if(found == null)
            {
                Team newTeam = new Team
                {
                    Name = (string) team.Element("Name"),
                    Nationality = (string) team.Element("Nationality")
                };
                teams.Add(newTeam);
                return newTeam;
            }
            return found;
        }

        /// <summary>
        /// Gibt das Race für das Result zurück, indem das Race
        /// aus den Races auf Basis der Rennnummer gesucht wird.
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="races"></param>
        /// <returns></returns>
        private static Race GetRace(XElement xElement, Race[] races)
        {
            // TODO 01_1 GetRace
            return races.SingleOrDefault(r => r.Number == (int) xElement.Attribute("round"));
        }

        /// <summary>
        /// Fahrer wird aus XML für ein Result geparst.
        /// War der Fahrer schon in der Liste, wir dieser zurückgegeben.
        /// Sonst wird der Fahrer in die Liste gestellt und zurückgegeben.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="drivers"></param>
        /// <returns></returns>
        private static Driver GetDriver(XElement result, List<Driver> drivers)
        {
            // TODO 02_2 GetDriver
            Driver found = drivers.SingleOrDefault(d => d.Name == (string)result.Element("FamilyName") + " " + (string)result.Element("GivenName"));
            if (found == null)
            {
                Driver newDriver = new Driver
                {
                    FirstName = (string)result.Element("GivenName"),
                    LastName = (string)result.Element("FamilyName"),
                    Nationality = (string)result.Element("Nationality")
                };
                drivers.Add(newDriver);
                return newDriver;
            }
            return found;
        }
    }
}