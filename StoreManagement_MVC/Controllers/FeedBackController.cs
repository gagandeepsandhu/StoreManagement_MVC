using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement_MVC.Models;
namespace StoreManagement_MVC.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        public ActionResult feedBack()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMsg(feedBack log)
        {
            //object of the feed back class that is used to passs  the record in the table by using the class of the controller or model class and using the getter setter method of the class
            feedBack obj_Feed= new feedBack();
            //passin the query to the controller of the main class that is used to insert the reocrd
            String query = "insert into Contact(Name,Email,Msg) values('" + log.Name + "','" + log.Email + "','" + log.Message + "')";
            //calling the method of the model class
            obj_Feed.send(query);
            //redirecting the user to the feed back page after giving the feed back to the user 
            return View("return_Feed");


        }
    }
}