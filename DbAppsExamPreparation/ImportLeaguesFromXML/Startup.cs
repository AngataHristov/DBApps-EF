namespace ImportLeaguesFromXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using DatabaseFirst;
    using System.Xml;

    public class Startup
    {
        public static void Main()
        {
            var context = new FootballEntities();

            using (context)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("../../Leagues-and-teams.xml");

                var root = doc.DocumentElement;
                int id = 1;

                foreach (XmlNode league in root.ChildNodes)
                {
                    Console.WriteLine("Processing league #{0} ...", id);

                    XmlNode leagueNameNode = league.SelectSingleNode("league-name");
                    League newLeague = null;

                    if (leagueNameNode != null)
                    {
                        string leagueName = leagueNameNode.InnerText;
                        newLeague = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);

                        if (newLeague != null)
                        {
                            Console.WriteLine("Existing league: {0}", leagueName);
                        }
                        else
                        {
                            newLeague = new League()
                            {
                                LeagueName = leagueName
                            };

                            Console.WriteLine("Creating league: {0}", leagueName);
                        }

                    }

                    XmlNode teamsNode = league.SelectSingleNode("teams");

                    if (teamsNode != null)
                    {
                        foreach (XmlNode xmlTeam in teamsNode.ChildNodes)
                        {
                            Team team = null;
                            string teamName = xmlTeam.Attributes["name"].Value;
                            string countryName = null;

                            if (xmlTeam.Attributes["country"] != null)
                            {
                                countryName = xmlTeam.Attributes["country"].Value;
                            }

                            team = context.Teams
                               .FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == countryName);

                            if (team != null)
                            {
                                Console.WriteLine("Existing team: {0} ({1})", teamName, countryName ?? "no country");
                            }
                            else
                            {
                                Country country = context.Countries
                                    .FirstOrDefault(c => c.CountryName == countryName);

                                team = new Team
                                {
                                    TeamName = teamName,
                                    Country = country
                                };

                                context.Teams.Add(team);

                                Console.WriteLine("Create team: {0} ({1})", teamName, countryName);
                            }

                            if (newLeague != null)
                            {
                                if (newLeague.Teams.Contains(team))
                                {
                                    Console.WriteLine(
                                        "Existing team in league: {0} belongs to {1}",
                                        teamName, newLeague.LeagueName);
                                }
                                else
                                {
                                    newLeague.Teams.Add(team);
                                    Console.WriteLine(
                                        "Added team to league: {0} to league {1}",
                                        teamName, newLeague.LeagueName);
                                }
                            }
                        }
                    }

                    id++;
                    context.SaveChanges();
                }
            }
        }
    }
}
