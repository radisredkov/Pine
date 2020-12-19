using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeamDeliriumProject.Controllers
{
    public class CommunityController : Controller
    {
        public IActionResult AllPosts()
        {
            return View();
        }
        public IActionResult Communities()
        {
            return View();
        }
    }
}
