using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_Episode_0.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowUser(int? id)
        {
            ViewBag.Id = id;
            ViewBag.UserName = "Rakotomahay";
            return View();
        }

    }
}