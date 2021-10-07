using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Http2.Models.DTOs
{
    public class CreateList
    {
        public CreateList()
        {
        }

        [Required, Display(Name = "List Name")]
        public string Name { get; set; }
    }
}
