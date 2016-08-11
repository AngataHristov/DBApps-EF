namespace BooksStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
