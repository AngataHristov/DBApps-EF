namespace ArtistsSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ArtistInfo
    {
        [Column("Age")]
        [Range(1, 120)]
        public int Age { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Biography")]
        public string Biography { get; set; }
    }
}
