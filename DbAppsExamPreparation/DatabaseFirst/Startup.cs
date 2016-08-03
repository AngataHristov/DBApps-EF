namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var context = new FootballEntities();

            using (context)
            {
                var teams = context.Teams
                    .Select(t => t.TeamName)
                    .ToList();

                foreach (var item in teams)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
