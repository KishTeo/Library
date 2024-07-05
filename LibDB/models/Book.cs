using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibDB.models
{
    public class Book
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
        public ICollection<BookRental>? BookRental { get; set; }
    }
}