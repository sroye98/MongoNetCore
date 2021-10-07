using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Http2.Models.DTOs
{
    public class CreateItem
    {
        public CreateItem()
        {
        }

        [Required]
        public string ListId { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, DataType(DataType.MultilineText), Display(Name = "Description")]
        public string Description { get; set; }
    }
}
