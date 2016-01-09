using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogIT.Models
{
    public class Comment : BaseModel
    {
        public string ArticleId { get; set; }

        [Required]
        [DisplayName("Sender email")]
        public string EmailSender { get; set; }

        [Required]
        [DisplayName("Sender name")]
        public string NameSender { get; set; }

        [Required]
        public string Subject { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
    }
}