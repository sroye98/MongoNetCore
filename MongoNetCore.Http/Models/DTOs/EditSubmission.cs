using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Http.Models.DTOs
{
    public class EditSubmission
    {
        public EditSubmission()
        {
        }

        [Required, DataType(DataType.Text)]
        public string Id { get; set; }

        [Required, DataType(DataType.MultilineText), Display(Name = "Content")]
        public string Content { get; set; }
    }
}
