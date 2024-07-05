using LibDB.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLogic.DTOs
{
    public class BookRentalDTO
    {
        [Key]
        public int BookRentalId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public DateTime dateCapture { get; set; }
        public DateTime? dateReturn { get; set; }
        public UserDTO User { get; set; } = null!;
        public BookDTO Book { get; set; } = null!;
    }
}
