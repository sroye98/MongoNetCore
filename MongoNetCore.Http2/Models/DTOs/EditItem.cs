using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Http2.Models.DTOs
{
    public class EditItem
    {
        public EditItem()
        {
        }

        [Required, DataType(DataType.Text), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, DataType(DataType.MultilineText), Display(Name = "Description")]
        public string Description { get; set; }

        [Required, Display(Name = "Is Completed")]
        public bool Completed { get; set; }
    }
}
