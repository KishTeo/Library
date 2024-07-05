using LibDB.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLogic.DTOs
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
        [Required]
        public string MiddleName { get; set; } = null!;
        public int? BirthYear { get; set; }
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public ICollection<BookRentalDTO>? Bookrental { get; set; }
    }
}
