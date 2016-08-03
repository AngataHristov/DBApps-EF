namespace ExportInternationnalXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.Threading;
    using System.Xml.Linq;

    using DatabaseFirst;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new FootballEntities();

            using (context)
            {
                var internationalMatches = context.InternationalMatches
                    .OrderBy(m => m.MatchDate)
                    .ThenBy(m => m.CountryHome.CountryName)
                    .ThenBy(m => m.CountryAway.CountryName)
                    .Select(m => new
                    {
                        HomeScores = m.HomeGoals,
                        AwayScores = m.AwayGoals,
                        HomeCountryCode = m.HomeCountryCode,
                        AwayCountryCode = m.AwayCountryCode,
                        Date = m.MatchDate,
                        HomeCountryName = m.CountryHome.CountryName,
                        AwayCountryName = m.CountryAway.CountryName,
                        MatchLeagueName = m.League.LeagueName
                    })
                    .ToList();

                XElement matches = new XElement("matches");

                foreach (var match in internationalMatches)
                {
                    XElement xmlMatch =
                        new XElement("match",
                            new XElement("home-country",
                                new XAttribute("code", match.HomeCountryCode),
                                match.AwayCountryName),
                            new XElement("away-country",
                                new XAttribute("code", match.AwayCountryCode),
                                match.HomeCountryName)
                            );

                    if (match.MatchLeagueName != null)
                    {
                        xmlMatch.Add(new XElement("league", match.MatchLeagueName));
                    }

                    if (match.HomeScores != null && match.AwayScores != null)
                    {
                        xmlMatch.Add(new XElement("score",
                            string.Format(
                            "{0}-{1}", match.HomeScores, match.AwayScores)));
                    }

                    if (match.Date != null)
                    {
                        if (match.Date != null)
                        {
                            DateTime dateTime;
                            DateTime.TryParse(match.Date.ToString(), out dateTime);

                            if (dateTime.TimeOfDay.TotalSeconds == 0.0)
                            {
                                xmlMatch.Add(new XAttribute("date", dateTime.ToString("dd-MMM-yyyy")));
                            }
                            else
                            {
                                xmlMatch.Add(new XAttribute("date-time", dateTime.ToString("dd-MMM-yyyy hh:mm")));
                            }
                        }
                    }

                    matches.Add(xmlMatch);
                }

                var writer = new StreamWriter("MatchesXml.txt");

                writer.Write(matches.ToString());
                writer.Close();

                Console.WriteLine(matches.ToString());
            }
        }
    }
}
