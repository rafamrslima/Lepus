namespace Lepus.API.Service.Dtos
{
    public class TransactionDto
    {
        public string Description { get; set; }

        public decimal Value { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string UserName { get; set; }
    }
}
