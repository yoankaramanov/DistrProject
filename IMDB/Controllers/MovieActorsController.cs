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
    public class MovieActorsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: MovieActors
        public ActionResult Index()
        {
            var movieActor = db.MovieActor.Include(m => m.Actor).Include(m => m.Movie);
            return View(movieActor.ToList());
        }

        // GET: MovieActors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActor movieActor = db.MovieActor.Find(id);
            if (movieActor == null)
            {
                return HttpNotFound();
            }
            return View(movieActor);
        }

        // GET: MovieActors/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actor, "ActorId", "ActorName");
            ViewBag.MovieId = new SelectList(db.Movie, "MovieId", "MovieTitle");
            return View();
        }

        // POST: MovieActors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,ActorId")] MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                db.MovieActor.Add(movieActor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actor, "ActorId", "ActorName", movieActor.ActorId);
            ViewBag.MovieId = new SelectList(db.Movie, "MovieId", "MovieTitle", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MovieActors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActor movieActor = db.MovieActor.Find(id);
            if (movieActor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actor, "ActorId", "ActorName", movieActor.ActorId);
            ViewBag.MovieId = new SelectList(db.Movie, "MovieId", "MovieTitle", movieActor.MovieId);
            return View(movieActor);
        }

        // POST: MovieActors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,ActorId")] MovieActor movieActor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actor, "ActorId", "ActorName", movieActor.ActorId);
            ViewBag.MovieId = new SelectList(db.Movie, "MovieId", "MovieTitle", movieActor.MovieId);
            return View(movieActor);
        }

        // GET: MovieActors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActor movieActor = db.MovieActor.Find(id);
            if (movieActor == null)
            {
                return HttpNotFound();
            }
            return View(movieActor);
        }

        // POST: MovieActors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieActor movieActor = db.MovieActor.Find(id);
            db.MovieActor.Remove(movieActor);
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
