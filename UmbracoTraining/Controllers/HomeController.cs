using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace UmbracoTraining.Controllers
{
    public class HomeController : SurfaceController
    {
        private const string BasePath = "~/Views/Partials/Home";

        public ActionResult RenderBanner()
        {
            return PartialView($"{BasePath}/Banner.cshtml");
        }

        public ActionResult RenderSection1()
        {
            return PartialView($"{BasePath}/Section1.cshtml");
        }

        public ActionResult RenderSection2()
        {
            return PartialView($"{BasePath}/Section2.cshtml");
        }

    }
}