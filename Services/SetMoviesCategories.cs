using AppMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMovies.Services
{
    public static class SetMoviesCategories
    {
        public static void SetMovieCategory<M,C,D>(M movie,C category,D db)
            where M: Movie
            where C: List<string> 
            where D : ApplicationDbContext

        {

            if (category.Count() > 0)
            {
                //List<MovieCategory> _moviesCategories = new List<MovieCategory>();

                /*var last_movie = db.Movies.ToArray();
                var _last_movie = last_movie[last_movie.Length - 1];*/
               // var movie_id = _last_movie.Id;


               foreach (var id in category)
                {
                    var _category = db.Categories.Find(int.Parse(id));
                    var _movieCategory = new MovieCategory()
                    {
                        Movie = movie,
                        Category = _category
                    };

                    db.MoviesCategories.Add(_movieCategory);
                    
                    //_moviesCategories.Add(_movieCategory);
                }

                /*if (_moviesCategories.Count()>0) {
                    db.MoviesCategories.AddRange(_moviesCategories); 
                }*/

            }
        }
    }
}