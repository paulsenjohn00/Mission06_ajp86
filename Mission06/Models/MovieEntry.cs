using System;
using System.ComponentModel.DataAnnotations;

namespace Mission06.Models
{
	public class MovieEntry
	{
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage ="Please enter a movie title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter the year")]
        public int Year { get; set; }
        [Required(ErrorMessage ="Please include the movie director")]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }

        // foreign key setup
        [Required(ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

