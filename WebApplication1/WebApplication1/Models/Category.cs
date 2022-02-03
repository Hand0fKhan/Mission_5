using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_A.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
