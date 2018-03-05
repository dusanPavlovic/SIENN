using System;
using System.Collections.Generic;

namespace SIENN.Services.Models
{
    public class ProductDto
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TypeCode { get; set; }
        public int UnitCode { get; set; }
        public List<int> Categories { get; set; } 
    }
}