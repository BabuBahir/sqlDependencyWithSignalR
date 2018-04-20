using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    [Table("UserDetails")]
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string Pswd { get; set; }
    }
}