using Mission13Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Test.Components
{
    public class TypesViewComponent : ViewComponent
    {
        
        private BowlerDataContext bdc { get; set; }
        public TypesViewComponent(BowlerDataContext temp)
        {
            bdc = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Team"];

            var teams = bdc.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }

    }
}
