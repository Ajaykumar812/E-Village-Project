using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_VillageProject.Models;
namespace E_VillageProject.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        DEMOVT24Entities db=new DEMOVT24Entities();
        private object dateTime;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutVillage()
        {
            return View();
        }
        public ActionResult PhotoGallery()
        {
            return View();
        }
       
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(tbl_registration reg)
        {
            {
                try
                {
                    HttpPostedFileBase file = Request.Files["Profile"];
                    reg.Profile = file.FileName;
                    reg.Regdate = DateTime.Now.ToString();
                    file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
                    db.tbl_registration.Add(reg);
                    db.SaveChanges();
                    Response.Write("<script>alert('Record Save Succesfully')</script>");

                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('Record not Save')</script>");
                }
            }
            return View();
        }
        public ActionResult Schemes()
        {
            return View();
        }
      
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_signup con)
        {
            try
            {
                con.signdate = DateTime.Now.ToString();
                db.tbl_signup.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Record save successfully.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('Record not saved .')</script>");
            }

            return View();
        }
      
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUS(tbl_contact con,string hdn1,string ct1)
        {
            try
            {
                if (hdn1==ct1)
                {
                    con.Contactdate = DateTime.Now.ToString();
                    db.tbl_contact.Add(con);
                    db.SaveChanges();
                    Response.Write("<script>alert('Record save successfully.')</script>");
                }
                else
                {
                    Response.Write("<Script>alert('Invalid Captcha code .')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('Record not saved .')</script>");
            }
            return View();
        }

        public ActionResult Feedback()
        {

            return View();
        }    
        [HttpPost]
        public ActionResult Feedback(tbl_feedback con)
        {
            try
            {
                con.feedbackdate = DateTime.Now.ToString();
                db.tbl_feedback.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Record save successfully.')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<Script>alert('Record not saved .')</script>");
            }
            return View();
        }
      
        public ActionResult CurrentSituation()
        {
            return View();
        }
        public ActionResult Overview()
        {
            return View();
        }
        public ActionResult AimObjective()
        {
            return View();
        }
        public ActionResult Goals()
        {
            return View();
        }
        public ActionResult Leadership()
        {
            return View();
        }
        public ActionResult IndustrialAnalysis()
        {
            return View();
        }
        public ActionResult SurveyDate()
        {
            return View();
        }
        public ActionResult Perspective()
        {
            return View();
        }
        public ActionResult Sponsorship()
        {
            return View();
        }
        public ActionResult Epilogue()
        {
            return View();
        }
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(tbl_admin_login lg)
        {
            try
            {
                tbl_admin_login t1 = db.tbl_admin_login.Where(x => x.Email == lg.Email && x.Password == lg.Password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["aid"] = lg.Email;// SET OF SESSION
                    Response.Write("<script>alert(' Welcome to Admin Zone  '); window.location.href='/AdminZone/index' </script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Email ID or Password ! ')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('There are Error in code !  ! ')</script>");
            }

            return View();
        }
    }
}