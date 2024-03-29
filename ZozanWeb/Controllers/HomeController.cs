﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZozanWeb.Models;

namespace ZozanWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult listOfShows()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult GrilleProgramme()
        {         
            return View();
        }

        public IActionResult ReplaysList()
        {
            return View();
        }

        public IActionResult Video(string videon)
        {
            return View();
        }



        public IActionResult getLastReplaysFromChannel(string c)
        {
            ViewData["c"] = c;

            return View();    
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
