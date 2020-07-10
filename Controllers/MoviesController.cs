using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMovies.Models;

//servicios
using AppMovies.Services;

namespace AppMovies.Controllers
{


    public class Search
    {
       public string search { get; set; }
    }

    //[Authorize]
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        [AllowAnonymous]
        // GET: Movies
        public ActionResult Index(string categoria, int? C  )
        {
            /*var categories = db.Movies.Include(x => x.MovieCategories).ToList();
            var category_mc = categories[0].MovieCategories[0].Category;*/

            /*var mc = db.Movies.Select(x=>x.MovieCategories).ToList();
            var movieCategories = db.MoviesCategories.Include(x=> x.Movie).Include(x=> x.Category).ToList();*/
            
            if (C != null)
            {
                int id = (int)C;
                var categoryMovies = db.MoviesCategories.Where(x => x.Category.Id == id).Select(x => x.Movie).ToList();
                var model = categoryMovies;
                ViewBag.Category_Name = categoria;
                return View(model);
            }

            ViewBag.DbContext = db;
            return View(db.Movies.ToList());
        }

        public ActionResult Search(string search)
        {    
            var moviesSearch = db.Movies.Where(x => x.Title.ToLower().Contains(search.ToLower())== true).ToList();
            var model = moviesSearch;
            ViewBag.Search = search;
            return View("Index",model);
        }
        

        // GET: Movies/Details/5
        public ActionResult Details(string _movie,int _m)
        {
            
            Movie movie = db.Movies.Where(x=>x.Title == _movie && x.Id == _m).FirstOrDefault();
            int? id = movie.Id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            
            return View(movie);
        }

        [Authorize]
        public ActionResult Favotires()
        {
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie, List<string> category)
        {
           if (ModelState.IsValid)
            {


                SetMoviesCategories.SetMovieCategory<Movie, List<string>, ApplicationDbContext>(movie, category, db);

                var _movie = SetVideosAndImages.addVideoAndImage<Movie>(movie);
                db.Movies.Add(_movie);
                /*db.SaveChanges();*/

                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
           }

            return View(movie);
        }
        

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,ImagePath,VideoPath")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
