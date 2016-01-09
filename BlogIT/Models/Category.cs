using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogIT.Models
{
    public class Category : BaseModel
    {
        public Category() : base() { }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}