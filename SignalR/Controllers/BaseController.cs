using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
       public NotificationContext db = new NotificationContext();
    }
}