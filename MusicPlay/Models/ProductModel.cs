using System;

namespace MusicPlay.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public CategoriesEnum Categories { get; set; }
        public string Name { get; set; }    
    }

    public enum CategoriesEnum
    {
        Pianos = 0,
        Guitars = 1,
        Drums = 2,
        Studio = 3,
        Accessories = 4,
        Bass = 5
    }
}