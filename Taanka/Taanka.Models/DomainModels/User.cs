using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taanka.Models.DomainModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string LoginId { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
