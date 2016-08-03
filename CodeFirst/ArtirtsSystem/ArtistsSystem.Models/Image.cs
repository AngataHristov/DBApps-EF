namespace ArtistsSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtention { get; set; }

        public string OriginalFileName { get; set; }

        [ForeignKey("Album")]
        [Required]
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }

        // public string FilePath { get; set; }
    }
}
