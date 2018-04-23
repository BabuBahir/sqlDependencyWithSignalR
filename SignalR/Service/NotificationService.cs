using GenericRepository;
using SignalR.Data;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Service
{
    public class NotificationService
    {
        

        public static List<NotificationDetails> GetAllNotificationDetails()
        {
            try
            {
                NotificationDAL notificationDAL = new NotificationDAL();
                return notificationDAL.GetAllNotificationDetails();
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public NotificationDetails GetAllNotificationDetailById(int id)
        {
            try
            {
                NotificationDAL notificationDAL = new NotificationDAL();
                return notificationDAL.GetAllNotificationDetailById(id);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<NotificationDetails> GetAllNotificationDetailByUser(int userId)
        {
            try
            {
                NotificationDAL notificationDAL = new NotificationDAL();
                return notificationDAL.GetAllNotificationDetailByUser(userId);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<NotificationDetails> GetAllUnseenNotificationDetailByUser(int userId)
        {
            try
            {
                NotificationDAL notificationDAL = new NotificationDAL();
                return notificationDAL.GetAllUnseenNotificationDetailByUser(userId);
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        #region notification
        public void SaveNotification(NotificationDetails nd)
        {
            NotificationDAL notificationDAL = new NotificationDAL();
            notificationDAL.SaveNotification(nd);
        }
        #endregion

        #region user detail
        public void SaveUserDetails(UserDetails ud)
        {
            NotificationDAL notificationDAL = new NotificationDAL();
            notificationDAL.SaveUserDetails(ud);
        }
        #endregion

    }
}



//https://stackoverflow.com/questions/20503286/using-sqldependency-with-named-queues?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa