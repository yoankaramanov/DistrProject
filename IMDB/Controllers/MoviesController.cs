using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    public class MoviesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movie = db.Movie.Include(m => m.Cinema).Include(m => m.Company).Include(m => m.Director);
            return View(movie.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinema, "CinemaId", "CinemaName");
            ViewBag.CompanyId = new SelectList(db.Company, "CompanyId", "CompanyName");
            ViewBag.DirectorId = new SelectList(db.Director, "DirectorId", "DirectorName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieTitle,ImageURL,DirectorId,Runtime,Genre,Budget,ReleaseDate,CompanyId,CinemaId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movie.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinema, "CinemaId", "CinemaName", movie.CinemaId);
            ViewBag.CompanyId = new SelectList(db.Company, "CompanyId", "CompanyName", movie.CompanyId);
            ViewBag.DirectorId = new SelectList(db.Director, "DirectorId", "DirectorName", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaId = new SelectList(db.Cinema, "CinemaId", "CinemaName", movie.CinemaId);
            ViewBag.CompanyId = new SelectList(db.Company, "CompanyId", "CompanyName", movie.CompanyId);
            ViewBag.DirectorId = new SelectList(db.Director, "DirectorId", "DirectorName", movie.DirectorId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieTitle,ImageURL,DirectorId,Runtime,Genre,Budget,ReleaseDate,CompanyId,CinemaId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinema, "CinemaId", "CinemaName", movie.CinemaId);
            ViewBag.CompanyId = new SelectList(db.Company, "CompanyId", "CompanyName", movie.CompanyId);
            ViewBag.DirectorId = new SelectList(db.Director, "DirectorId", "DirectorName", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
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
            Movie movie = db.Movie.Find(id);
            db.Movie.Remove(movie);
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
