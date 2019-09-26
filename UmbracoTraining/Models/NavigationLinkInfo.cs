using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTraining.Models
{
    public class NavigationLinkInfo
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool IsNewTab { get; set; }
        public string Target { get { return IsNewTab ? "_blank" : null; } }
        public string Title { get; set; }

        public NavigationLinkInfo() { }

        public NavigationLinkInfo(string text=null, string url=null, bool isNewTab=false, string title=null)
        {
            Text = text;
            Url = url;
            IsNewTab = isNewTab;
            Title = title;
        }
    }
}