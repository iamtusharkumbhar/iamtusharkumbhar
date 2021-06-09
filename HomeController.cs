using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using TusharPortfolio.Models;

namespace TusharPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Email email)
        {
            string from = email.Fromemail;
            string name = email.Name;
            string subject = email.subject;
            string message = email.message;
            string to = "kumbharamrutaa@gmail.com";
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = message;
            mm.From = new MailAddress(from);
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gamil.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("kumbharamrutaa@gmailcom", "amruta@tshar");
            smtp.Send(mm);
            ViewBag.message = "Mail has been send....!";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Subscription()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
