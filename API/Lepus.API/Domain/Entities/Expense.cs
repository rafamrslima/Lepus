using System;

namespace Lepus.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public string Description { get; set; }

        public decimal Value { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string UserName { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Description))
                throw new Exception("It's necessary to inform the description.");

            if (Description.Length > 50)
                throw new Exception("The maximum allowed for the description is 50 characters.");

            if (Month < 1 || Month > 12)
                throw new Exception("The month has to be between 1 and 12.");

            if (Year < DateTime.Now.Year)
                throw new Exception($"The should be greater than equal or greater than {DateTime.Now.Year}.");

            if (Value <= 0 || Value > 9999999)
                throw new Exception("The value should be greater than 0 and less than 9999999.");

            if (string.IsNullOrWhiteSpace(UserName))
                throw new Exception("It's necessary to inform the user name.");

            if (UserName.Length > 25)
                throw new Exception("The maximum allowed for the user name is 25 characters.");
        }
    }
}
