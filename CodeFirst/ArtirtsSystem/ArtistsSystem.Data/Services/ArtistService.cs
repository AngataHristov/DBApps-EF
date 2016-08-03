namespace ArtistsSystem.Data.Services
{
    using ArtistsSystem.Data.Repositories;
    using ArtistsSystem.Models;
    using System.Linq;


    public class ArtistService
    {
        private readonly IRepository<Artist> artists;

        public ArtistService(IRepository<Artist> data)
        {
            this.artists = data;
        }

        public IQueryable<Artist> FindByName(string name)
        {
            return this.artists
                .All()
                .Where(a => a.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
