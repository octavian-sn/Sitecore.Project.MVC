using Sitecore.Project.MVC.Web.Extensions;
using Sitecore.Project.MVC.Web.Models;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Shell.Feeds.FeedTypes;
using System.Web.UI.WebControls;
using Sitecore.Data.Fields;

namespace Sitecore.Project.MVC.Web.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            var model = new NavigationViewModel();

            List <Navigation> navigations = new List <Navigation> ();

            var homeItem = Sitecore.Context.Site.HomeItem();

            navigations.Add(BuildNavigation(homeItem));

            if(homeItem.HasChildren)
            {
                foreach (Item child in homeItem.Children)
                {
                    CheckboxField hideInNavigation = child.Fields["hide_in_navigation"];
                    if (!hideInNavigation.Checked) navigations.Add(BuildNavigation(child));
                }
            }
            model.Navigations = navigations;

            return View(model);
        }

        private Navigation BuildNavigation(Item item)
        {
            return new Navigation
            {
                NavigationTitle = item.Fields["navigation_title"]?.Value,
                NavigationUrl = item.Url(),
                ActiveClass = PageContext.Current.Item.ID == item.ID ? "active" : "",
            };
        }
    }
}