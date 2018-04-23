using GenericRepository;
using SignalR.Models;
using SignalR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notification()
        {
            UnitOfWork<UserDetails> UOW = new UnitOfWork<UserDetails>(db);

            string connectionString = @"Data Source=DOTNETSERVER\SQLEXPRESS;Initial Catalog=SignalRDemo;  user id=sa;password=C1tytech;  ";
            string sqlQueue = @"NamesQueue";
            //Listener query restrictions: http://msdn.microsoft.com/en-us/library/aewzkxxh.aspx
            string listenerQuery = " select Name from [dbo].[UserDetails]";
            SqlWatcher w = new SqlWatcher(connectionString, sqlQueue, listenerQuery);
            w.Start();
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
    }
}