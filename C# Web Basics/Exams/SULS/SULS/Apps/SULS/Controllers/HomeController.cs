﻿using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View(); //Views/Home(HomeController)/Index (Action name -> Index)
        }
    }
}
