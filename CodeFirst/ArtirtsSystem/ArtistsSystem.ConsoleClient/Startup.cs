namespace ArtistsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ArtistsSystem.Data;
    using ArtistsSystem.Models;
    using ArtistsSystem.Models.Enum;
    using ArtistsSystem.Data.Repositories;

    public class Startup
    {
        public static void Main()
        {
            //IRepository<Artist> artistRepo = new EfRepository<Artist>();

            //artistRepo.Add(new Artist()
            //    {
            //        Name = "Asencho",
            //        Gender = GenderType.Male,
            //        Information = new ArtistInfo()
            //        {
            //            Age = 18,
            //            Biography = "dgfn",
            //            Country = "Bulgariq"
            //        },
            //    });

            //artistRepo.SaveChanges();
        }
    }
}
