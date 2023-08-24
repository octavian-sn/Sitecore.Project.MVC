using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Project.MVC.Web.Controllers;

namespace Sitecore.Project.MVC.Web.Models
{
    public class FeatureModel
    {
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString Icon { get; set; }

    }
}