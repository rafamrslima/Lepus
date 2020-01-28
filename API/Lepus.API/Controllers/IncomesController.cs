using Lepus.API.Domain.Entities;
using Lepus.API.Service.Dtos;
using Lepus.API.Service.Services;
using Lepus.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        readonly TransactionService _transactionService;

        public IncomesController(MongoDbContext mongoDbContext)
        {
            _transactionService = new TransactionService(mongoDbContext.Incomes);
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            return new ObjectResult(await _transactionService.Get(userName, year, month));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto incomeDto)
        {
            var income = new Transaction(incomeDto.Description, incomeDto.Value, incomeDto.Month, incomeDto.Year, incomeDto.UserName);
            await _transactionService.Post(income);
            return Ok();
        }

        [HttpPut("{incomeId}")]
        public async Task<IActionResult> Put(string incomeId, [FromBody]TransactionDto incomeDto)
        {
            await _transactionService.Put(incomeId, incomeDto.Value, incomeDto.Description);
            return Ok();
        }

        [HttpDelete("{IncomeId}")]
        public async Task<IActionResult> Delete(string incomeId)
        {
            await _transactionService.Delete(incomeId);
            return new NoContentResult();
        }
    }
}