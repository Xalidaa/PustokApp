namespace MVCPustokApp.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOld { get; set; }
        public int PriceDiscount { get; set; }
        public string ImageUrl { get; set; }

        public Feature(int id, string heading, string detail, decimal price, decimal priceOld, int priceDiscount, string imageUrl)
        {
            Id = id;
            Heading = heading;
            Detail = detail;
            Price = price;
            PriceOld = priceOld;
            PriceDiscount = priceDiscount;
            ImageUrl = imageUrl;
        }
    }
}
