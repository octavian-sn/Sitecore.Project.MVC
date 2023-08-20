using Sitecore.Mvc.Presentation;
using Sitecore.Project.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Project.MVC.Web.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            //1.Pass Item to the view
            var model = new AboutViewModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            //2. Read the values, build the model and pass it to the view

            //3. Read the values using fieldRenderer (supports experience editor)

            return View(model);
        }
    }
}