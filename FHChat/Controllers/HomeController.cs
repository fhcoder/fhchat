using System;
using System.Web;
using System.Web.Mvc;

namespace FHChat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
            return View();
        }
        public ActionResult Chat()
        {
            if(Session["nick"]!=null)
            {
                ViewBag.Nick = Session["nick"];
                ViewBag.Id = Session["id"];
            }
            else
            {
                ViewBag.Nick = null;
                ViewBag.Id = null;
            }
            return View();
        }
        [HttpPost]
        public ActionResult NickNamePost(string nickname)
        {
            Session["nick"]= HttpUtility.HtmlEncode(nickname);
            Session["id"] = HttpUtility.HtmlEncode(nickname + new Random().Next().ToString());
            return RedirectToAction("Chat", "Home");
            
           
        }
        public ActionResult NickName()
        {
            return View();
        }
    }
}