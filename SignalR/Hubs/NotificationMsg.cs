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
using System.Threading;

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
            var touser = UserHandler.chatusers.Where(x => x.connID == to).FirstOrDefault();

         //   string connectionString = @"Data Source=DOTNETSERVER\SQLEXPRESS;Initial Catalog=SignalRDemo;  user id=sa;password=C1tytech;  ";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlDependencyConfig"].ConnectionString;
            string sqlQueue = @"NamesQueue";
            //Listener query restrictions: http://msdn.microsoft.com/en-us/library/aewzkxxh.aspx
            string listenerQuery = "SELECT [NotificationId],[UserId],[NotificationMessage],[CreatedDateTime],[IsSeen] FROM[dbo].[NotificationDetails] ";
            SqlWatcher w = new SqlWatcher(connectionString, sqlQueue, listenerQuery);
            w.Start();

            NotificationService _ns = new NotificationService();

            NotificationDetails nd = new NotificationDetails() {
                UserId = _ns.GetuserIdBYSignalRId(touser.connID),
                NotificationMessage = msg,               
                CreatedDateTime = DateTime.Now
            };
            
               _ns.SaveNotification(nd);
             
            Clients.Client(touser.connID).sendMessage(from, msg);
            Clients.Caller.notifyMessageDelivered(touser.name);
            
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

            UserDetails ud = new UserDetails()
            {                 
                LoginId = name,
                Name = name,
                Pswd ="1234",
                SignalrId = connID
            };

            NotificationService _ns = new NotificationService();
            _ns.SaveUserDetails(ud);

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