using MVCPustokApp.Models.Base;

namespace MVCPustokApp.Models
{
    public class Feature:BaseEntity
    {
        public string Heading { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public int PriceDiscount { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        //public Feature(string heading, string detail, decimal price, decimal priceOld, int priceDiscount, string imageUrl)
        //{
        //    Heading = heading;
        //    Detail = detail;
        //    Price = price;
        //    PriceOld = priceOld;
        //    PriceDiscount = priceDiscount;
        //    ImageUrl = imageUrl;
        //}
    }
}
