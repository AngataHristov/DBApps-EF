namespace ArtistsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        [Required]
        public string Title { get; set; }

        public int Duration { get; set; }

        [ForeignKey("Album")]
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
