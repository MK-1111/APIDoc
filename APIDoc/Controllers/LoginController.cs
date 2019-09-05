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

        [HttpPost]
        public async Task<ActionResult> SubmitID(string username,string password,string tenant_id)
        {
            var s= new Loginpost();
            string result=await s.GetToken(username, password, tenant_id,1);
            Session["VMurl"]= await s.GetToken(username, password, tenant_id, 2);
            Session["Mailurl"] = await s.GetToken(username, password, tenant_id, 3);
            Session["DNSurl"] = await s.GetToken(username, password, tenant_id, 4);
            if (result == "none")
            {
                TempData["alert"]= "Failed";
                return RedirectToAction("Index", "Login");
            }
            else {
                Session["Token"] = result;
                Session["User"] = username;
                Session["Pass"] = password;
                Session["Tenant"] = tenant_id;
                return RedirectToAction("Index","Home");
            }
            
        }
    }
}