using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projekbetol;

namespace projekbetol.Controllers
{
    [Authorize]
    public class IssueBooksController : Controller
    {
        private Database1Entities3 db = new Database1Entities3();

        // GET: IssueBooks
        public ActionResult Index()
        {
            var issueBooks = db.IssueBooks.Include(i => i.Book).Include(i => i.Status).Include(i => i.Student);
            return View(issueBooks.ToList());
        }

        // GET: IssueBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // GET: IssueBooks/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "BookName");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Status1");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName");
            return View();
        }

        // POST: IssueBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookId,StatusId,Date,StudentId")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.IssueBooks.Add(issueBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "Id", "BookName", issueBook.BookId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Status1", issueBook.StatusId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName", issueBook.StudentId);
            return View(issueBook);
        }

        // GET: IssueBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "BookName", issueBook.BookId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Status1", issueBook.StatusId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName", issueBook.StudentId);
            return View(issueBook);
        }

        // POST: IssueBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookId,StatusId,Date,StudentId")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issueBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "BookName", issueBook.BookId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Status1", issueBook.StatusId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName", issueBook.StudentId);
            return View(issueBook);
        }

        // GET: IssueBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // POST: IssueBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssueBook issueBook = db.IssueBooks.Find(id);
            db.IssueBooks.Remove(issueBook);
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
