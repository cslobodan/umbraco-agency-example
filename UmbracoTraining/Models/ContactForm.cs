using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTraining.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}