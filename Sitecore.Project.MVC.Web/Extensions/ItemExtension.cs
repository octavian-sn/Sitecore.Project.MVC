using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Project.MVC.Web.Extensions
{
    public static class ItemExtension
    {
        public static string Url(this Item item, ItemUrlBuilderOptions options = null)
        {
            if (item == null)  
                throw new ArgumentNullException(nameof(item)); 

            if (options != null) 
                return LinkManager.GetItemUrl(item, options);

            return LinkManager.GetItemUrl(item);
        }
    }
}