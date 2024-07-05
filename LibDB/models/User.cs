using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibDB.models
{
    public class User
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
        public ICollection<BookRental>? Bookrental { get; set; } = null!;


    }
}
