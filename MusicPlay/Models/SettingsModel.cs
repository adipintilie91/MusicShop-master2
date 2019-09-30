using System.Collections.Generic;

namespace MusicPlay.Models
{
    public class SettingsModel
    {
        public List<CategoryModel> categories { get; set; }
        public List<CountryModel> countries { get; set; }
        public List<CustomerModel> customers { get; set; }
        public List<OrderModel> orders { get; set; }
        public List<OrderDetailModel> orderDetails { get; set; }
        public List<ProductModel> products { get; set; }
        public List<ProductDetailModel> productDetails { get; set; }
    }
}