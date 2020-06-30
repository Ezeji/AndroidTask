using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AndroidTask.Model
{
    public class RegisterUser
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Required, System.ComponentModel.DataAnnotations.MaxLength(40)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [Ignore]
        public string Password { get; set; }

        public string EncryptedPassword { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string ClientID { get; set; }

        [Required]
        public string Company { get; set; }

        public string UserID { get; set; }

        
    }
}
