using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement_MVC.Models;
using System.Data;
namespace StoreManagement_MVC.Controllers
{
    public class LoginDetailsController : Controller
    {
        // GET: LoginDetails
        public ActionResult LoginDetails()
        {
            return View();
        }

        //this method is used to validte the user name or password of the user after verfiying the both the control will  transfer to another page 
        public ActionResult Login(LoginDetails log)
        {

            LoginDetails obj_Login = new LoginDetails();
            String query = "select * from Admin where UsrName='" + log.UserName + "' and UsrPassword='" + log.UserPassword+ "'";
            DataTable tbl = new DataTable();
            tbl = obj_Login.SrchLogin(query);

            if (tbl.Rows.Count > 0)
            {

                return View("WorkingArea");
            }
            else
            {
                return View("Invalid");
            }

        }
    }
}