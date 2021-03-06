﻿using GenericRepository;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public  void SaveNotification(NotificationDetails nd)
        { 
            try
            {
                db.NotificationDetails.Add(nd);
                db.SaveChanges();
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        #region user detail
        public void SaveUserDetails(UserDetails ud)
        {
            try
            {
                db.UserDetails.Add(ud);
                db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public int GetuserIdBYSignalRId(string signalRID)
        {
            try
            {
               var user = db.UserDetails.Where(x => x.SignalrId.Equals(signalRID)).FirstOrDefault();
                return user.UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}