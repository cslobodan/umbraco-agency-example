using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTraining.Models
{
    public class NavigationItem
    {
        public string Text { get; set; }
        public NavigationLinkInfo Link { get; set; }
        public List<NavigationItem> NavigationItems { get; set; }
        public bool HasSubnavigation { get { return NavigationItems != null && NavigationItems.Any() && NavigationItems.Count > 0; } }

        public NavigationItem(NavigationLinkInfo link)
        {
            Link = link;
        }
    }
}