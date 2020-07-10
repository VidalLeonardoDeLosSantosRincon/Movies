using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppMovies.Models
{
    public class MovieCategory
    {
        [Key]
        public int Id { get; set;}

       /*public int Movie_Id { get; set; }
        public int Category_Id { get; set; }
        */
    
        public Movie Movie { get; set; }
        
        public Category Category { get; set; }
    }
}