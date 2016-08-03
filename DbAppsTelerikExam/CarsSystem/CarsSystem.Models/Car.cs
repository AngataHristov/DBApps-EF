namespace CarsSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarsSystem.Models.Enums;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(21)]
        public string Model { get; set; }

        public TransmitionType TransmitionType { get; set; }

        public ushort Year { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
