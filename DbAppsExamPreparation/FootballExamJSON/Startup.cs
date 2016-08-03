namespace FootballExamJSON
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using System.IO;
    using Newtonsoft.Json;

    using DatabaseFirst;

    public class Startup
    {
        public static void Main()
        {
            var context = new FootballEntities();

            using (context)
            {
                var leagues = context.Leagues
                    .OrderBy(l => l.LeagueName)
                    .Select(l => new
                    {
                        l.LeagueName,
                        Teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => t.TeamName)
                    })
                    .ToList();

                StringBuilder result = new StringBuilder();

                //foreach (var league in leagues)
                //{
                //     //var leagueJSON = new JavaScriptSerializer().Serialize(league);
                //    var leagueJSON = JsonConvert.SerializeObject(league, Formatting.Indented);

                //    result.Append(leagueJSON);
                //}

                var leagueJSON = JsonConvert.SerializeObject(leagues, Formatting.Indented);

                result.Append(leagueJSON);
                Console.WriteLine(result.ToString());

                var writer = new StreamWriter("TeamsJSAN.txt");
                writer.Write(result.ToString());
                writer.Close();
            }
        }
    }
}
