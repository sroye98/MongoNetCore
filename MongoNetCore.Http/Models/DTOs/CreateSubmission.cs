using System;
using System.ComponentModel.DataAnnotations;

namespace MongoNetCore.Http.Models.DTOs
{
    public class CreateSubmission
    {
        public CreateSubmission()
        {
        }

        [Required, DataType(DataType.MultilineText), Display(Name = "Content")]
        public string Content { get; set; }
    }
}
