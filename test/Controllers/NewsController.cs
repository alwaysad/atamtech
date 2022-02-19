﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using System.Globalization;
using System.Threading;
namespace test.Controllers
{
    public class NewsController : Controller
    { 
        
        
        NewComment nc = new NewComment();
        TableList lng = new TableList();
        Context c = new Context();
        [Route("NewsList")]
        public ActionResult NewsList()
        {
            
            lng.newsTr = c.News.Where(x => x.language == true); // tr true 
            lng.newsEn = c.News.Where(x => x.language == false); // en false
            
              //  var news = c.News.ToList();
                return View(lng);
        }
       

        public ActionResult NewsDetail(int id)
        {
            //var findNew = c.News.Where(x => x.id == id).ToList();
            nc.Value1 = c.News.Where(x => x.id == id).ToList();
            nc.Value2 = c.Comments.Where(x => x.NewId == id).ToList();
            return View("NewsDetail",nc);
        }

        [HttpGet]
        public PartialViewResult MakeComment(int id)
        {

            @ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult MakeComment(Comment com )
        {

            c.Comments.Add(com);
            c.SaveChanges();


            return PartialView();
        }

    }
}