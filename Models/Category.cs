using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppMovies.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        public List<MovieCategory> MovieCategories { get; set; }
        
    }
}