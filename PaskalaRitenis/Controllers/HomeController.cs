﻿using PaskalaRitenis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaskalaRitenis.Controllers
{
    public class HomeController : Controller
    {
        private INewsRepository _repository;
        public HomeController()
            : this(new NewsRepository())
        {
        }
        public HomeController(INewsRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var news = _repository.GetNews();
            return View(news);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Supporters()
        {

            return View();
        }


        

    }
}
