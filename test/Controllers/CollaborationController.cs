﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    

    public class CollaborationController : Controller
    {

        Context c = new Context();
        TableList lng = new TableList();
        [Route("CollaborationList")]
        public ActionResult ColList()
        {
            
            lng.collTr = c.Collaborations.Where(x => x.language == true).ToList();
            lng.collEn = c.Collaborations.Where(x => x.language == false).ToList();
            lng.serviceTr = c.Services.Where(x => x.language == true).ToList();
            lng.serviceEn = c.Services.Where(x => x.language == false).ToList();
            lng.productTr = c.Products.Where(x => x.language == true).ToList();
            lng.productEn = c.Products.Where(x => x.language == false).ToList();

            return View(lng);
        }


        public ActionResult ColDetails(int id)
        {
            lng.serviceTr = c.Services.Where(x => x.language == true).ToList();
            lng.serviceEn = c.Services.Where(x => x.language == false).ToList();
            lng.productTr = c.Products.Where(x => x.language == true).ToList();
            lng.productEn = c.Products.Where(x => x.language == false).ToList();

            lng.colldtTr = c.Collaborations.Where(x => x.language == true && x.id == id).ToList();
            lng.colldtEn = c.Collaborations.Where(x => x.language == false && x.id == id).ToList();
            //var col = c.Collaborations.ToList();
            //col = c.Collaborations.Where(x => x.id == id).ToList();
            return View(lng);
        }
    }
}