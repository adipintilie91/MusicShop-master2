using System;
using System.ComponentModel.DataAnnotations;

namespace MusicPlay.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage ="String too long. Insert max. 250 chars.")]
        public string Name { get; set; }
    }
}