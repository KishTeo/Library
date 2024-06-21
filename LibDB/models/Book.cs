﻿using System.ComponentModel.DataAnnotations;
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
        public int? PublicationYear { get; set; }
        [Required]
        public int EntranceYear { get; set; }
        public int? OffsYear { get; set; }
        [Required]
        public BookRental BookRental { get; set; } = null!;
    }
}