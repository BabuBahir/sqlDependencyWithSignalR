using GenericRepository;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Data
{
    public class UserDAL
    {
        NotificationContext db = new NotificationContext();
        public List<UserDetails> GetAllUsers()
        {
            try
            {
                using (UnitOfWork<UserDetails> UOW = new UnitOfWork<UserDetails>(db))
                {
                    return UOW.ModelRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public UserDetails GetUserDetailById(int id)
        {

            try
            {
                using (UnitOfWork<UserDetails> UOW = new UnitOfWork<UserDetails>(db))
                {
                    return UOW.ModelRepository.GetById(id);
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


    }
}