namespace SIENN.DbAccess.Entities
{
    public class ProductCategory
    {
        public int ProductCode { get; set; }
        public Product Product { get; set; }

        public int CategoryCode { get; set; }
        public Category Category { get; set; }
    }
}