using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using Sitecore.Project.MVC.Web.Models;
using Sitecore.Web.UI.WebControls;
using Sitecore.Project.MVC.Web.Db;

namespace Sitecore.Project.MVC.Web.Controllers
{
    public class FreeQuoteController : Controller
    {
        //private readonly QuoteContext _db;

        //public FreeQuoteController(QuoteContext context )
        //{
        //    _db = context;
        //}

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

        [HttpPost]
        public ActionResult Index(Quote quote)
        {
            QuoteContext db = new QuoteContext();

            db.Quotes.Add(quote);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Quotes(Quote quote) 
        {
            QuoteContext db = new QuoteContext();
            
            var query = from q in db.Quotes
                        orderby q.Name
                        select q;

            List<Quote> quoteList = new List<Quote>();

            foreach(var item in query)
            {
                Quote quote1 = new Quote()
                {
                    Name = item.Name,
                    Email = item.Email,
                    Mobile  = item.Mobile,
                    Service = item.Service,
                    Note = item.Note,
                };
                quoteList.Add(quote1);
            }

            return View(quoteList);
        }

    }
}