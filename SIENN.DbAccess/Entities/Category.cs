using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIENN.DbAccess.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Code { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}