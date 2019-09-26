using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using UmbracoTraining.Models;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoTraining.Controllers
{
    public class SiteSharedLayoutController : SurfaceController
    {
        public ActionResult RenderHeader()
        {
            List<NavigationItem> nav = GetNavigationModel();
            return PartialView("~/Views/Partials/SiteSharedLayout/Header.cshtml", nav);
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/SiteSharedLayout/Footer.cshtml");
        }

        //STEP 1: Create function to get Navigation Model from Database
        //STEP 2: Create function to get Subnavigation
        //STEP 3: Update the code for RenderHeader() method

        public List<NavigationItem> GetNavigationModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]); //Page position in path
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new List<NavigationItem>
            {
                new NavigationItem(new NavigationLinkInfo(pageInfo.Name, pageInfo.Url, false, pageInfo.Name))
            };
            
            nav.AddRange(GetSubnavigationModel(pageInfo));
            return nav;
        }

        public List<NavigationItem> GetSubnavigationModel(IPublishedContent page)
        {
            List<NavigationItem> navList = null;
            var subPages = page.Children;
            if(subPages != null && subPages.Any())
            {
                navList = new List<NavigationItem>();
                foreach(var subPage in subPages)
                {
                    var listItem = new NavigationItem(new NavigationLinkInfo(subPage.Name, subPage.Url, false, subPage.Name))
                    {
                        NavigationItems = GetSubnavigationModel(subPage)
                    };
                    navList.Add(listItem);
                }
            }
            return navList;
        }


    }
}