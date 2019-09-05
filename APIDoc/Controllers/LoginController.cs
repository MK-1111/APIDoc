using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APIDoc.Models;
using System.Threading.Tasks;

namespace APIDoc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.Alert = TempData["alert"];

            return View();
        }

        public async Task<ActionResult> SubmitID(string username,string password,string tenant_id)
        {
            var s= new Loginpost();
            var result=await s.GetToken(username, password, tenant_id);
            if (result == null)
            {
                TempData["alert"]= "Failed";
                return RedirectToAction("Index", "Login");
            }
            else {
                TempData["Token"] = result;
                TempData["User"] = username;
                TempData["Pass"] = password;
                return RedirectToAction("Index","Home");
            }
            
        }
    }
}