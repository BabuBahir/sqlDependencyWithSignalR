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
    }
}