using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Application.DTOs
{
    public class CreateUser
    {
        public CreateUser()
        {
        }

        [Required, DataType(DataType.Text), Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required, MinLength(4), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
    }
}
