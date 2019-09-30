using System.Collections.Generic;

namespace MusicPlay.Models
{
    public class ShoppingCartModel
    {
        public List<OrderModel> Orders { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}