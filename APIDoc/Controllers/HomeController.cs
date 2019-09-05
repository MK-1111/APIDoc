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
                ViewBag.Message = TempData["flag"];
            ViewBag.Color = TempData["color"];
            return View();
        }

        public async Task<ActionResult> VMadd()
        {
            APIpost postAC = new APIpost();
            bool x=await postAC.VMAdd(TempData["Token"]);
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

            return RedirectToAction("Index");


        }
    }
}