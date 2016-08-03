namespace ArtistsSystem.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
