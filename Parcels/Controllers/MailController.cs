using Microsoft.AspNetCore.Mvc;
using Parcels.Models;
using System.Collections.Generic;

namespace Parcels.Controllers
{
  public class MailsController : Controller
  {

    [HttpGet("/mails")]
    public ActionResult Index()
    {
      List<Mail> allMails = Mail.GetAll();
      return View(allMails);
    }

    [HttpGet("/mails/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/mails")]
    public ActionResult Create(string description, int weight, int length, int width, int height)
    {
      Mail myMail = new Mail(description, weight, length, width, height);
      myMail.GetVolume(length, width, height);
      myMail.GetCost(weight, length, width, height);
      return RedirectToAction("Index");
    }

    // [HttpPost("/mails/checkout")]
    // public ActionResult Checkout(string description, int weight, int length, int width, int height)
    // {
    //   Mail checkedMail = new Mail(description, weight, length, width, height);
    //   checkedMail.Volume(length, width, height);
    //   return View(checkedMail);
    // }

    // [HttpGet("/mails/checkout")]
    // public ActionResult Checkout()
    // {
    //   return View();
    // }

  }
}