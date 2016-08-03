namespace ArtistsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ArtistsSystem.Models.Enum;

    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;
        private ICollection<Image> images;

        public Album()
        {
            this.Id = Guid.NewGuid();
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
            this.images = new HashSet<Image>();
        }

        [Key]
        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        [Required]
       // [DefaultValue("Qkata rabota")]
        public string Title { get; set; }

        public decimal? Price { get; set; }

        public DateTime? ReleasedOn { get; set; }

        public AlbumStatus Status { get; set; }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }
    }
}
