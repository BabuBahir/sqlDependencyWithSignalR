using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalR.Models;
using GenericRepository;
using SignalR.Service;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalR.Hubs
{
    public class NotificationMsg : Hub
    {
        public void GetNotification()
        {
            List<NotificationDetails> msgs = new List<NotificationDetails>();
            Clients.All.NewMessage(msgs);
        }

        public void sendNotificationMsg(string from , string to , string msg)
        {              
            //List<NotificationDetails> msgs = NotificationService.GetAllNotificationDetails();
            //Clients.All.NewMessage(msgs);
            var touser = UserHandler.chatusers.Where(x => x.connID == to).FirstOrDefault();            
            Clients.Client(touser.connID).sendMessage(from, msg);
            Clients.Caller.notifyMessageDelivered(touser.name);
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

        public override Task OnConnected()
        {             
            UserHandler.chatusers.Add(new ChatUser { name = "", connID = Context.ConnectionId.ToString() });

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {             
            UserHandler.chatusers.RemoveAll(x => x.connID == Context.ConnectionId.ToString());
            var jsonObj = JsonConvert.SerializeObject(UserHandler.chatusers);
            Clients.All.updateActiveUsers(jsonObj);

            return base.OnDisconnected(stopCalled);
        }

        public void getActiveUsers( string name, string connID)
        {
            var index = UserHandler.chatusers.FindIndex(x => x.connID == connID);
            UserHandler.chatusers.ElementAt(index).name = name;

            var jsonObj = JsonConvert.SerializeObject(UserHandler.chatusers);
            Clients.All.updateActiveUsers(jsonObj);
        }


    }

    public static class UserHandler
    {         
        public static List<ChatUser> chatusers = new List<ChatUser>();
    }

    public class ChatUser
    {
        public string name { get; set; }
        public string connID { get; set; }
    }

}