using System.ComponentModel.DataAnnotations;

namespace Taanka.Models.DomainModels
{
    public class Order
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
        public string Details { get; set; }
        public double TotalAmount { get; set; }

        [Required]
        public string Email { get; set; }
       
        public DateTime OrderDate { get; set; }

    }
}
