using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIENN.DbAccess.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Code { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public System.DateTime DeliveryDate { get; set; }

        public int TypeCode { get; set; }

        [Required]
        public Type Type { get; set; }

        public int UnitCode { get; set; }

        [Required]
        public Unit Unit { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}