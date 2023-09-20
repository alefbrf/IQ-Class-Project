﻿using System.ComponentModel.DataAnnotations;

namespace IQ_Class.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password_hash { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime? last_acess { get; set; }
        [MaxLength(6)]
        public string verification_code { get; set; } = "000000";
        public bool verification_code_active { get; set; }
        public bool online { get; set; }
        public int? schoolid { get; set; }
        public virtual School? school { get; set; }
        public virtual ICollection<UserRole> user_roles { get; set; }
        public virtual ICollection<UserClass> user_classes { get; set; }
    }
}
