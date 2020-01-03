using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lepus.Domain.Entities
{
    public class Income : BaseEntity
    {
        public string Description { get; set; }

        public decimal Value { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string UserName { get; set; }
    }
}
