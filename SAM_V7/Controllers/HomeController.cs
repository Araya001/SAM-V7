using SAM_V7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAM_V7.Controllers
{
    public class HomeController : Controller
    {
        private SAM_V7Context db = new SAM_V7Context();
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

        [HttpPost]
        public ActionResult Login(string PSUPassport, string Password)
        {
            if (PSUPassport != "" || Password != "")
            {
                var User = db.Staffs.Where(b => b.PSUPassport.Equals(PSUPassport)).FirstOrDefault();
                var User1 = db.Users.Where(b => b.PSUPassport.Equals(PSUPassport)).FirstOrDefault();
                var User2 = db.Approvers.Where(b => b.PSUPassport.Equals(PSUPassport)).FirstOrDefault();



                if (PSUPassport != null && PSUPassport.Equals("admin") && Password.Equals("1234"))
                {
                    Session["PSUPassport"] = "admin";
                    Session["Position"] = "admin";
                    Session["Name"] = "admin";


                    return RedirectToAction("index", "Staffs");

                }

                if (User != null && User1 == null && User2 == null)
                {
                    if (PSUPassport != null && PSUPassport.Equals(User.PSUPassport))
                    {
                        Session["PSUPassport"] = User.PSUPassport.ToString();
                        Session["Position"] = User.Position.ToString();
                        Session["OrganName"] = User.OrganName.ToString();
                        Session["Name"] = (User.StaffName + " " + User.StaffLastName).ToString();

                        return RedirectToAction("index", "Proposals");
                    }
                }

                if (User == null && User1 != null && User2 == null)
                {
                    if (PSUPassport != null && PSUPassport.Equals(User1.PSUPassport))
                    {
                        Session["PSUPassport"] = User1.PSUPassport;
                        Session["Position"] = User1.Position;
                        Session["OrganName"] = User1.OrganName.ToString();
                        Session["Name"] = (User1.Name + " " + User1.LastName).ToString();

                        return RedirectToAction("index", "Proposals");
                    }
                }

                if (User == null && User1 == null && User2 != null)
                {
                    if (PSUPassport != null && PSUPassport.Equals(User2.PSUPassport))
                    {
                        Session["PSUPassport"] = User2.PSUPassport;
                        Session["Position"] = User2.Position;
                        Session["OrganName"] = User2.OrganName.ToString();
                        Session["Name"] = (User2.Name + " " + User2.LastName).ToString();

                        return RedirectToAction("index", "Proposals");
                    }

                }

            }
            else
                return Redirect("/Home/Index");
            return View();
        }

        public ActionResult Logout()
        {

            Session.Abandon(); // it will clear the session at the end of request
            Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}