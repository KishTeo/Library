using LibDB.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLogic.DTOs
{
    public class BookDTO
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public DateTime PublicationDate { get; set; } //= null!;
        [Required]
        public DateTime EntranceDate { get; set; } //= null!;
        public DateTime? OffsDate { get; set; }
        [Required]
        public ICollection<BookRentalDTO>? BookRental { get; set; }
    }
}
