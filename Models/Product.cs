namespace MyWebSite_Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string ModelName { get; set; }
        public string PathDescription { get; set; }
        public decimal Cost{ get; set; }
        public ModelDescriptionJson[] Description { get; set; } 
    }
}
