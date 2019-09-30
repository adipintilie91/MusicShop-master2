using System;

namespace MusicPlay.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal Price { get; set; }
        public int StatusType { get; set; }
    }
}