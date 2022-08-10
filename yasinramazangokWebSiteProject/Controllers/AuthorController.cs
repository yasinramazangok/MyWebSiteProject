﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yasinramazangokWebSiteProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager();
        AuthorManager authorManager = new AuthorManager();

        [AllowAnonymous]
        public PartialViewResult authorAbout(int id)
        {
            // Bu metot ile blog içerisinde sağ tarafta yazar bilgisini görüntülemekteyiz.
            var authorDetails = blogManager.getBlogById(id);
            return PartialView(authorDetails);
        }

        [AllowAnonymous]
        public PartialViewResult authorPopularBlogs(int id) // Parametre olarak girilen id, bloğun id'sidir.
        {
            // Bu metot ile blog içerisinde sağ tarafta yazar bilgisini görüntülemekteyiz.
            var blogAuthorId = blogManager.getAll().Where(x => x.id == id).Select(y => y.authorId).FirstOrDefault();
            var authorBlogs = blogManager.getBlogByAuthor(blogAuthorId);
            return PartialView(authorBlogs);
        }

        public ActionResult authorList()
        {
            // Yazar listesini döndüren metot
            var authorLists = authorManager.getAll();
            return View(authorLists);
        }

        [HttpGet]
        public ActionResult addNewAuthor() 
        {
            // Yeni yazar ekleme metodu burasıdır.
            return View(); 
        }

        [HttpPost]
        public ActionResult addNewAuthor(Author p)
        {
            authorManager.addNewAuthorBL(p);
            return RedirectToAction("authorList");
        }

        [HttpGet]
        public ActionResult authorEdit(int id)
        {
            Author author = authorManager.findAuthor(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult authorEdit(Author p)
        {
            authorManager.editAuthor(p);
            return RedirectToAction("authorList");
        }
    }
}