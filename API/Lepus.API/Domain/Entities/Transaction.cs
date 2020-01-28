using Lepus.API.Domain.Enums;
using Lepus.Domain.Entities;
using System;

namespace Lepus.API.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(string description, decimal value, int month, int year, string userName, TransactionType transactionType)
        {
            Validate(description, value, month, year, userName);

            Description = description;
            Value = value;
            Month = month;
            Year = year;
            UserName = userName;
            TransactionType = transactionType;
        }

        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public int Month { get; private set; }

        public int Year { get; private set; }

        public string UserName { get; private set; }

        public TransactionType TransactionType { get; set; }

        public void Validate(string description, decimal value, int month, int year, string userName)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("It's necessary to inform the description.");

            if (description.Length > 50)
                throw new ArgumentException("The maximum allowed for the description is 50 characters.");

            if (month < 1 || month > 12)
                throw new ArgumentException("The month has to be between 1 and 12.");

            if (year < DateTime.Now.Year)
                throw new ArgumentException($"The year should be equal or greater than {DateTime.Now.Year}.");

            if (value < 1 || value > 9999999)
                throw new ArgumentException("The value should be greater than 0 and less than 9999999.");

            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("It's necessary to inform the user name.");

            if (userName.Length > 25)
                throw new ArgumentException("The maximum allowed for the user name is 25 characters.");
        }

        public void Update(decimal value, string description)
        {
            if (value < 1 || value > 9999999)
                throw new ArgumentException("The value should be greater than 0 and less than 9999999.");
             
            if (description.Length > 50)
                throw new ArgumentException("The maximum allowed for the description is 50 characters.");

            Value = value;
            Description = description;
        }
    }
}
