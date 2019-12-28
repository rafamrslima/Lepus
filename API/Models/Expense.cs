using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LepusAPI.Models
{
    public class Expense {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Description { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public int Status { get; set; }
        
        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; } 

        [Required]
        public string userName { get; set; }
    }
}