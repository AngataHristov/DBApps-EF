namespace ForumSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class UserInfo
    {
        [Required]
        [MinLength(2, ErrorMessage = "Kuso")]
        [MaxLength(20)]
        [Column("First name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Column("Last name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public int? Age { get; set; }
    }
}
