using crud_framework_sqlserver.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_framework_sqlserver.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (dbModels context = new dbModels())
            {
                return View(context.Books.ToList());
             }
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            using (dbModels context = new dbModels())
            {
                return View(context.Books.Where(x=>x.id == id));
            }
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book books)
        {
            try
            {
                // TODO: Add insert logic here
                using (dbModels context = new dbModels())
                {
                    context.Books.Add(books);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (dbModels context = new dbModels())
            {
                return View(context.Books.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                using (dbModels context = new dbModels())
                {
                    context.Entry(book).State = EntityState.Modified;
                    context.SaveChanges(); 
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (dbModels context = new dbModels())
            {
                return View(context.Books.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using(dbModels context = new dbModels())
                {
                    Book book = context.Books.Where(x=>x.id == id).FirstOrDefault();
                    context.Books.Remove(book);
                    context.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
