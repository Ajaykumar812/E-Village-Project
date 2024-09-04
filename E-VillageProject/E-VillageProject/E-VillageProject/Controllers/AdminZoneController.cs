using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_VillageProject.Models;

namespace E_VillageProject.Controllers
{
    public class AdminZoneController : Controller
    {
        // GET: AdminZone
        DEMOVT24Entities db = new DEMOVT24Entities();
        public ActionResult Index()
        {
            if(Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('Login first then goto Next Zone');window.location.href='/Home/Login'</script>");
                
            }
            return View();
        }
        public ActionResult ContactUs()
        {
            List<tbl_contact>lst = null;
            lst = db.tbl_contact.ToList();
            return View(lst);
        }
        public ActionResult Registration()


        {
            List<tbl_registration> lst = null;
            lst = db.tbl_registration.ToList();
            return View(lst);
        }
        public ActionResult Login()
        {
            List<tbl_signup> lst = null;
            lst = db.tbl_signup.ToList();
            return View(lst);

    }
        public ActionResult Feedback()
        {
            List<tbl_feedback> lst = null;
            lst = db.tbl_feedback.ToList();
            return View(lst);

        }public  void Logout()
        {
            Session.Abandon();
            Response.Write("<script> alert('LogOut');window.location.href='/Home/Login'</script>");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpass,string newpass,string confirmpass)
        {
            if(newpass==confirmpass && newpass !=oldpass){
                string Email = Session["aid"].ToString();
                tbl_admin_login lg = db.tbl_admin_login.Where(x => x.Password == oldpass && x.Email == x.Email).SingleOrDefault();
                lg.Password = newpass;
                db.SaveChanges();
                Response.Write("<script> alert('Your password changed');window.location.href='/Home/Adminlogin'</script>");
            }
            else
            {
                Response.Write("<script> alert(' Please Enter Confirm Password')</script>");

            }
            return View();
        }public  void Delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                tbl_registration tbl = db.tbl_registration.SingleOrDefault( x => x.EmailID== m);
                db.tbl_registration.Remove(tbl);
                db.SaveChanges();
                Response.Write("<script> alert('Record Delete successfully');window.location.href='/AdminZone/Registration'</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Record Not Delete');window.location.href='/AdminZone/Registration'</script>");
            }
        }
        [HttpGet]
        public ActionResult UpdateRecord()
        {
            string aid = Request.QueryString["U"];
            tbl_registration reg = db.tbl_registration.SingleOrDefault(a => a.EmailID == aid);
            return View(reg);
        }
        [HttpPost]
        public void  UpdateRecord(tbl_registration reg,string EmailID )
        {
            tbl_registration rg=db.tbl_registration.SingleOrDefault(a=>a.EmailID ==EmailID);
            try
            {
                HttpPostedFileBase file = Request.Files["Profile"];
                if(file.FileName !="")
                {
                    rg.First_name = reg.First_name;
                    rg.Last_name = reg.Last_name;
                    rg.Father_name = reg.Father_name;
                    rg.Mothers_name = reg.Mothers_name;
                    rg.Address = reg.Address;
                    rg.Permanent_Address = reg.Permanent_Address;
                    rg.Gender = reg.Gender;
                    rg.DOB = reg.DOB;
                    rg.Contactno = reg.Contactno;
                    rg.Profile = reg.Profile;
                    rg.Password = reg.Password;
                    rg.ConfirmPassword = reg.ConfirmPassword;
                    rg.State = reg.State;
                    rg.City = reg.City;
                    rg.Regdate = reg.Regdate;
                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("../Content/images/" + file.FileName));
                    Response.Write("<script>alert('Record Updated Successfully');window.location.href='/AdminZone/Registration'</script>");
                }
                else
                {
                    tbl_registration dd = db.tbl_registration.SingleOrDefault(x => x.EmailID == EmailID);
                    dd.First_name = reg.First_name;
                    dd.Last_name = reg.Last_name;
                    dd.Father_name = reg.Father_name;
                    dd.Mothers_name = reg.Mothers_name;
                    dd.Address = reg.Address;
                    dd.Permanent_Address = reg.Permanent_Address;
                    dd.Gender = reg.Gender;
                    dd.DOB = reg.DOB;
                    dd.Contactno = reg.Contactno;
                    dd.Profile = reg.Profile;
                    dd.Password = reg.Password;
                    dd.ConfirmPassword = reg.ConfirmPassword;
                    dd.State = reg.State;
                    dd.City = reg.City;
                    dd.Regdate = reg.Regdate;
                    db.SaveChanges();
                    //file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
                    Response.Write("<script>alert('Record Updated Not Successfully');window.location.href='/AdminZone/Registration'</script>");

                }
            }
            catch
            {
                Response.Write("<script>alert('Record Updated Not Successfully');window.location.href='/AdminZone/Registration'</script>");

            }

        }
    }
}