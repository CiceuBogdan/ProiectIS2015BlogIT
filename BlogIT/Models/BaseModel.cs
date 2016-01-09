using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace BlogIT.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        public string Id { get; private set; }
    }
}