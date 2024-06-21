using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibDB.models
{
    public class BookRental
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
        public User User { get; set; } = null! ;
        public Book Book { get; set; } = null! ;

    }
}
