using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Application.DTOs
{
    public class LoginUser
    {
        public LoginUser()
        {
        }

        [Required, DataType(DataType.Text), Display(Name = "Email Address or User Name")]
        public string Identifier { get; set; }

        [Required, MinLength(4), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
    }
}
