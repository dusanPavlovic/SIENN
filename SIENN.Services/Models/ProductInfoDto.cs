﻿namespace SIENN.Services.Models
{
    public class ProductInfoDto
    {
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        public string IsAvailable { get; set; }
        public string DeliveryDate { get; set; }
        public int CategoriesCount { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}