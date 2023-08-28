using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Project.MVC.Web.Models
{
    public class FreeQuoteModel
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString Description { get; set; }
        public MvcHtmlString Image { get; set; }
    }
}