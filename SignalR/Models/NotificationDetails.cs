using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    [Table("NotificationDetails")]
    public class NotificationDetails
    {
        [Key]
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool? IsSeen { get; set; }
    }
}