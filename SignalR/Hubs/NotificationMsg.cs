using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalR.Models;
using GenericRepository;
using SignalR.Service;

namespace SignalR.Hubs
{
    public class NotificationMsg : Hub
    {
        public void GetNotification()
        {
            List<NotificationDetails> msgs = new List<NotificationDetails>();
            Clients.All.NewMessage(msgs);
        }

        public void GetNotificationMsg()
        {
            List<NotificationDetails> msgs = NotificationService.GetAllNotificationDetails();
            Clients.All.NewMessage(msgs);

            //NotificationContext db = new NotificationContext();
            //UnitOfWork<NotificationDetails> UOW = new UnitOfWork<NotificationDetails>(db);
            //try
            //{
            //    int maxid = UOW.ModelRepository.GetAll().Max(f => f.NotificationId);
            //    var msg = UOW.ModelRepository.GetById(maxid);
            //    UOW.Dispose();
            //    Clients.All.NewMessage(msg);
            //}
            //catch(Exception ex)
            //{

            //}
        }

        
    }
}