using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("Users")]
    public class UserController : Controller
    {
        private readonly SchoolContext Context;

        public UserController(SchoolContext context)
        {
            Context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var UserList = Context.Users.ToList();
            return View(UserList);
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View("../Shared/Error");
        }
    }
}