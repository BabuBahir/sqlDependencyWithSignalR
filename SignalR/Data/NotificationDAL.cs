using GenericRepository;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Data
{
    public class NotificationDAL
    {
        NotificationContext db = new NotificationContext();
        public List<NotificationDetails> GetAllNotificationDetails()
        {
            try
            {
                using (UnitOfWork<NotificationDetails> UOW = new UnitOfWork<NotificationDetails>(db))
                {
                    return UOW.ModelRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public NotificationDetails GetAllNotificationDetailById(int id)
        {
            
            try
            {
                using (UnitOfWork<NotificationDetails> UOW = new UnitOfWork<NotificationDetails>(db))
                {
                    return UOW.ModelRepository.GetById(id);
                }
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
                using (UnitOfWork<NotificationDetails> UOW = new UnitOfWork<NotificationDetails>(db))
                {
                    return UOW.ModelRepository.FindBy(x => x.UserId == userId).ToList();
                }
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
                using (UnitOfWork<NotificationDetails> UOW = new UnitOfWork<NotificationDetails>(db))
                {
                    return UOW.ModelRepository.FindBy(x => x.UserId == userId && (x.IsSeen == null || !x.IsSeen.Value)).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}