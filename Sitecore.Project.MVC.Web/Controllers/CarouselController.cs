using Sitecore.Data.Fields;
using Sitecore.Mvc.Names;
using Sitecore.Mvc.Presentation;
using Sitecore.Project.MVC.Web.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Project.MVC.Web.Controllers
{
    public class CarouselController : Controller
    {
        public ActionResult Index()
        {
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField slidesField = dataSource.Fields["Slides"];

            CarouselModel model = new CarouselModel();
            List<Slide> slides = new List<Slide>();

            if(slidesField?.Count > 0 )
            {
                var slideItems = slidesField.GetItems();

                foreach( var slideItem in slideItems )
                {
                    var title = new MvcHtmlString(FieldRenderer.Render
                      (slideItem, "Title"));
                    var subTitle = new MvcHtmlString(FieldRenderer.Render
                      (slideItem, "Sub_Title"));
                    var description = new MvcHtmlString(FieldRenderer.Render
                      (slideItem, "Description"));
                    var leftCTA = new MvcHtmlString(FieldRenderer.Render
                      (slideItem, "Left_CTA"
                      , "class=btn btn-primary py-md-3 px-md-5 me-3 animated slideInLeft"));
                    var rightCTA = new MvcHtmlString(FieldRenderer.Render
                      (slideItem, "Right_CTA"
                      , "class=btn btn-light py-md-3 px-md-5 animated slideInRight"));
                    var image = new MvcHtmlString(FieldRenderer.Render
                      (slideItem, "Image"
                      , "class=img-fluid"));

                    slides.Add(new Slide
                    {
                        Title = title,
                        SubTitle = subTitle,
                        Description = description,
                        LeftCTA = leftCTA,
                        RightCTA = rightCTA,
                        Image = image
                    });
                }
                model.Slides = slides;
            }
            return View(model);
        }
    }
}