using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Project.MVC.Web.Models;
using Sitecore.Web.UI.WebControls;

namespace Sitecore.Project.MVC.Web.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        public ActionResult Index()
        {
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField featuresField = dataSource.Fields["feature"];

            FeatureModel model = new FeatureModel();
            List<Feature> features = new List<Feature>();

            if(featuresField.Count > 0)
            {
                var featureItems = featuresField.GetItems();

                foreach( var featureItem in featureItems )
                {
                    var title = new MvcHtmlString(FieldRenderer.Render
                        (featureItem, "Title"));

                    var icon = new MvcHtmlString(FieldRenderer.Render
                        (featureItem, "Icon"));

                    features.Add(new Feature
                    {
                        Title = title,
                        Icon = icon,
                    });
                }

                model.Features = features;
            }
            return View(model);
        }
    }
}