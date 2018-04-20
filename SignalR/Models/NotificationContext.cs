using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class NotificationContext:DbContext
    {
        public NotificationContext() : base("DB") { }

        public virtual DbSet<NotificationDetails> NotificationDetails { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}