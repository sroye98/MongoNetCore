using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Http2.Models.DTOs
{
    public class EditList
    {
        public EditList()
        {
        }

        [Required]
        public string ListId { get; set; }

        [Required, Display(Name = "List Name")]
        public string Name { get; set; }
    }
}
