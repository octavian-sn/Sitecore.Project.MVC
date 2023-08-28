using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Project.MVC.Web.Models;
using Sitecore.Web.UI.WebControls;

namespace Sitecore.Project.MVC.Web.Controllers
{
    public class FreeQuoteController : Controller
    {
        // GET: FreeQuote
        public ActionResult Index()
        {
            var dataSource = RenderingContext.Current.Rendering.Item;

            FreeQuoteModel model = new FreeQuoteModel
            {
                Title = new MvcHtmlString(FieldRenderer.Render(dataSource, "Title")),
                Description = new MvcHtmlString(FieldRenderer.Render(dataSource, "Description")),
                Image = new MvcHtmlString(FieldRenderer.Render(dataSource, "Image", 
                "class=position-absolute img-fluid w-100 h-100,\" style=\"object-fit: cover;"))
            };

            return View(model);
        }
    }
}