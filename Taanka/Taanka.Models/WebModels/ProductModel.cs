using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Taanka.Models.WebModels
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        public double Price { get; set; }

        public string? Image_url_path { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public bool? IsTrending { get; set; }

        public string Department { get; set; }

        //Unsticted etc etc 
        public string Category { get; set; }
        //Shalwar kameez etc etc
        public string SubCategory { get; set; }

        public string Fabric { get; set; }

        //2 piece 3 piece
        public string Sizes { get; set; }
        public string Colors { get; set; }


    }
}
