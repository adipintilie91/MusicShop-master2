using System;
using System.Collections.Generic;

namespace MusicPlay.Models
{
    public class ProductDetailModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public int YearOfProduction { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}