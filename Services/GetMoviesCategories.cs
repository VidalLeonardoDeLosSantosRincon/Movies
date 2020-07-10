using AppMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMovies.Services
{
    public static class GetMoviesCategories
    {


        public static List<string> GetMovieCategory<M, D>(M _movie, D db) 
            where M : Movie
            where D: ApplicationDbContext
        {

            List<string> peliculaCategorias = db.MoviesCategories.Where(x => x.Movie.Id == _movie.Id).Select(x => x.Category.Name).ToList();

            return peliculaCategorias;
        }
    }
}