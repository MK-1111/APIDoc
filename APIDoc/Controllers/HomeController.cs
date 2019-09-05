using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using APIDoc.Models;

namespace APIDoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.VMurl = Session["VMurl"];
            ViewBag.Mailurl = Session["Mailurl"];
            ViewBag.DNSurl = Session["DNSurl"];
            ViewBag.Message = TempData["flag"];
            ViewBag.Color = TempData["color"];
            ViewBag.Tenant = Session["Tenant"];
            return View();
        }

        public async Task<ActionResult> VMadd()
        {
            APIpost postAC = new APIpost();
            bool x=await postAC.VMAdd(Session["Token"].ToString(),Session["Tenant"].ToString());
            if (x == true)
            {
                TempData["flag"] = "Successful";
                TempData["color"] = "text-success";
            }
            else if (x == false)
            {
                TempData["flag"] = "Failed";
                TempData["color"] = "text-danger";
            }

            return RedirectToAction("Index","Home");


        }
    }
}