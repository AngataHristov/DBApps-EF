namespace ArtistsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ArtistsSystem.Models.Enum;

    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.Members = 1;
            this.albums = new HashSet<Album>();
            this.Information = new ArtistInfo();
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Incorrect name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public ArtistInfo Information { get; set; }

        public GenderType Gender { get; set; }

        public int Members { get; set; }

        [NotMapped]
        public bool IsGroup
        {
            get
            {
                return this.Members > 1;
            }
        }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}
