using Lepus.API.Domain.Enums;
using Lepus.Domain.Entities;
using System;

namespace Lepus.API.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string Description { get; set; }

        public decimal Value { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string UserName { get; set; }

        public TransactionType TransactionType { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("It's necessary to inform the description.");

            if (Description.Length > 50)
                throw new ArgumentException("The maximum allowed for the description is 50 characters.");

            if (Month < 1 || Month > 12)
                throw new ArgumentException("The month has to be between 1 and 12.");

            if (Year < DateTime.Now.Year)
                throw new ArgumentException($"The year should be equal or greater than {DateTime.Now.Year}.");

            if (Value < 1 || Value > 9999999)
                throw new ArgumentException("The value should be greater than 0 and less than 9999999.");

            if (string.IsNullOrWhiteSpace(UserName))
                throw new ArgumentException("It's necessary to inform the user name.");

            if (UserName.Length > 25)
                throw new ArgumentException("The maximum allowed for the user name is 25 characters.");
        }
    }
}
