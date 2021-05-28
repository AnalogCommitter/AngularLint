using Formula1.Core.Entities;
using System.Collections;
using System.Linq;

namespace Formula1.Core
{
    public class ResultCalculator
    {
        /// <summary>
        /// Berechnet aus den Ergebnissen den aktuellen WM-Stand für die Fahrer
        /// </summary>
        /// <returns>DTO für die Fahrerergebnisse</returns>
        public static TotalResultDto<Driver>[] GetDriverWmTable()
        {
            // TODO 03 GetDriverWmTable
            var drivers_dtos = ImportController.LoadResultsFromXmlIntoCollections()
                .GroupBy(r => r.Driver)
                .Select(pair =>
                {
                    return new TotalResultDto<Driver>
                    {
                        Competitor = pair.Key,
                        Points = pair.Sum(r => r.Points),
                    };
                })
                .OrderByDescending(d => d.Points)
                .ThenBy(d => d.Competitor.Name)
                .ToList();
            drivers_dtos.ForEach(d => d.Position = drivers_dtos.IndexOf(d) + 1);
            return drivers_dtos.ToArray();
        }

        /// <summary>
        /// Berechnet aus den Ergebnissen den aktuellen WM-Stand für die Teams
        /// </summary>
        /// <returns>DTO für die Teamergebnisse</returns>
        public static TotalResultDto<Team>[] GetTeamWmTable()
        {
            // TODO 04 GetTeamWmTable
            var teams_dtos = ImportController.LoadResultsFromXmlIntoCollections()
                .GroupBy(r => r.Team)
                .Select(pair =>
                {
                    return new TotalResultDto<Team>
                    {
                        Competitor = pair.Key,
                        Points = pair.Sum(r => r.Points),
                    };
                })
                .OrderByDescending(t => t.Points)
                .ThenBy(t => t.Competitor.Name)
                .ToList();
            teams_dtos.ForEach(t => t.Position = teams_dtos.IndexOf(t) + 1);
            return teams_dtos.ToArray();
        }


        /// <summary>
        /// Tabelle der Fahrer mit den schnellsten Runden, wenn sie einmal die
        /// schnellste Runde erzielt haben
        /// </summary>
        /// <returns></returns>
        public static TotalResultDto<Driver>[] GetFastestRoundsPerDriverTable()
        {
            // TODO 05 GetFastestRoundsPerDriverTable
            var fastestDrivers = ImportController.GetFastestLapDrivers();
            fastestDrivers.ForEach(d => d.Position = fastestDrivers.IndexOf(d) + 1);
            return fastestDrivers.ToArray();
        }

        /// <summary>
        /// Tabelle der Teams mit den schnellsten Runden, wenn sie einmal die
        /// schnellste Runde erzielt haben
        /// </summary>
        /// <returns></returns>
        public static TotalResultDto<Team>[] GetFastestRoundsPerTeamTable()
        {
            // TODO 05 GetFastestRoundsPerTeamTable
            var fastestTeams = ImportController.GetFastestLapTeams();
            fastestTeams.ForEach(t => t.Position = fastestTeams.IndexOf(t) + 1);
            return fastestTeams.ToArray();
        }
    }
}



