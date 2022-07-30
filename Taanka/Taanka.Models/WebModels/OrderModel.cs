using System.ComponentModel.DataAnnotations;

namespace Taanka.Models.WebModels
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        public bool? IsApproved { get; set; }
        [Required]
        public string Phone { get; set; }

        public double TotalAmount { get; set; }
        public string Details { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual List<ProductModel> Products { get; set; }
    }
}
