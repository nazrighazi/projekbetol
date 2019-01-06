using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekbetol.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities3 context = new Database1Entities3();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Statistics()
        {
            int Borrow = context.IssueBooks.Where(x => x.StatusId == 1).Count();
            int Return = context.IssueBooks.Where(x => x.StatusId == 2).Count();

            Ratio obj = new Ratio();
            obj.Borrow = Borrow;
            obj.Return = Return;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            public int Borrow { get; set; }

            public int Return { get; set; }
        }

        public ActionResult Graph()
        {
            
            return View();
        }
    }
}