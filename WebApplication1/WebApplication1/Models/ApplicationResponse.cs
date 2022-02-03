using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_A.Models;

namespace WebApplication1_A.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required (ErrorMessage ="Please enter the movie's rating from the following list: G, PG, PG-13, R")]
        public string Rating { get; set; }
        public bool Edit { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
        [Required (ErrorMessage ="Are we blind!? Deploy the movie title!")]
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
