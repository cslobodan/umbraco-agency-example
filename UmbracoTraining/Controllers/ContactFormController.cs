using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoTraining.Models;
using System.Configuration;

namespace UmbracoTraining.Controllers
{
    public class ContactFormController : SurfaceController
    {
        private const string BasePath = "~/Views/Partials/SiteSharedLayout";

        public ActionResult RenderContactForm()
        {
            return PartialView($"{BasePath}/ContactFormPartial.cshtml");
        }

        public ActionResult HandleSubmit(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                var contactFormContent = Services.ContentService.Create(
                    $"{contactForm.Name}-{DateTime.Now.ToString()}",
                    CurrentPage.Id,
                    "contactFormContent"
                    );
                contactFormContent.SetValue("contactFormName", contactForm.Name);
                contactFormContent.SetValue("contactFormEmail", contactForm.Email);
                contactFormContent.SetValue("contactFormMessage", contactForm.Message);                  
                Services.ContentService.SaveAndPublish(contactFormContent);
                TempData["ContactUsSuccess"] = true;
                SendMailSecondWay(contactForm);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendMailFirstWay(ContactForm contactForm)
        {
            MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["fromAddress"]);
            string fromPassword = ConfigurationManager.AppSettings["fromPassword"];
            MailAddress toAddress = new MailAddress(ConfigurationManager.AppSettings["toAddress"]);
            string subject = $"New message from {contactForm.Email} | ubraco.learning";
            string body =
                $"---------------------------------------------- \n" +
                $"FROM: {contactForm.Name} | {contactForm.Email} \n" +
                $"MESSAGE: {contactForm.Message} \n" +
                $"----------------------------------------------";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }

        private void SendMailSecondWay(ContactForm contactForm)
        {
            MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["fromAddress"]);
            MailAddress toAddress = new MailAddress(ConfigurationManager.AppSettings["toAddress"]);
            string subject = $"New message from {contactForm.Email} | ubraco.learning";
            string body =
                $"---------------------------------------------- \n" +
                $"FROM: {contactForm.Name} | {contactForm.Email} \n" +
                $"MESSAGE: {contactForm.Message} \n" +
                $"----------------------------------------------";
            MailMessage message = new MailMessage(fromAddress.Address, toAddress.Address, subject, body)
            {
                Subject = subject,
                Body = body
            };
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}