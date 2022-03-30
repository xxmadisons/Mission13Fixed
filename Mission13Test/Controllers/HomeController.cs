using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Test.Controllers
{
    public class HomeController : Controller
    {
        private BowlerDataContext BowlerContext { get; set; }

        public HomeController(BowlerDataContext someName)
        {
            BowlerContext = someName;
        }

        public IActionResult Index()
        {
            List<Bowler> Bowlers = new List<Bowler>();
            return View();
        }


        [HttpGet]

        public IActionResult EnterBowlers()
        {
            ViewBag.Teams = BowlerContext.Teams.ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult EnterBowlers(Bowler ar)
        {
            if (ModelState.IsValid)
            {

                BowlerContext.Add(ar);
                BowlerContext.SaveChanges();

                return RedirectToAction("BowlerList");
            }
            else //If Invalid
            {
                ViewBag.Teams = BowlerContext.Teams.ToList();
                return View();
            }
        }

        public IActionResult BowlerList()
        {
            var bowlers = BowlerContext.Bowlers
                .Include(x => x.Team)
                .OrderBy(order => order.BowlerLastName)
                .ToList();
            return View(bowlers);
        }


        [HttpGet]
        public IActionResult Edit (int bowlerid)
        {
            ViewBag.Teams = BowlerContext.Teams.ToList();

            var bowl = BowlerContext.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("EnterBowlers", bowl);
        }

        [HttpPost]
        public IActionResult Edit (Bowler ar)
        {
            BowlerContext.Update(ar);
            BowlerContext.SaveChanges();

            return RedirectToAction("BowlerList");
        }

        [HttpGet]
        public IActionResult Delete (int bowlerid)
        {
            var bowl = BowlerContext.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowl);
        }

        [HttpPost]
        public IActionResult Delete (Bowler ar)
        {
            BowlerContext.Bowlers.Remove(ar);
            BowlerContext.SaveChanges();

            return RedirectToAction("BowlerList");
        }

    }

}