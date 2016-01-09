using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogIT.Models
{
    public class Article : BaseModel
    {
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [Required]
        public DateTime Date { get; set; }
    }
}