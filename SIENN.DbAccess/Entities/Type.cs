using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIENN.DbAccess.Entities
{
    public class Type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Code { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}