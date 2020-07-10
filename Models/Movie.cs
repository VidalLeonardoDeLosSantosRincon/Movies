using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppMovies.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
       
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Upload Image")]
        //[Required]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Upload Video")]
        //[Required]
        public string VideoPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase VideoFile { get; set; }

        public List<MovieCategory> MovieCategories { get; set; }


    }
}