namespace ArtistsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Category> categories;

        public Category()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }

        [InverseProperty("SubCategories")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> SubCategories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }
    }
}
