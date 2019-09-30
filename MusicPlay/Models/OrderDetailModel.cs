using System;

namespace MusicPlay.Models
{
    public class OrderDetailModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductDetailId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public DateTime DateOrdered{ get; set; }
    }
}