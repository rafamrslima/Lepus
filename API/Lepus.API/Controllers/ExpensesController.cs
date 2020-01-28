using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using Lepus.API.Service.Services;
using Lepus.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly TransactionService _transactionService;
            
        public ExpensesController(MongoDbContext mongoDbContext)
        {
            _transactionService = new TransactionService(mongoDbContext.Expenses);
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            return new ObjectResult(await _transactionService.Get(userName, year, month));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto expenseDto)
        {
            var expense = new Transaction(expenseDto.Description, expenseDto.Value, expenseDto.Month, expenseDto.Year, expenseDto.UserName);
            await _transactionService.Post(expense);
            return Ok();
        }

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> Put(string expenseId, [FromBody]TransactionDto expenseDto)
        {
            await _transactionService.Put(expenseId, expenseDto.Value, expenseDto.Description);
            return Ok();
        }

        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> Delete(string expenseId)
        {
            await _transactionService.Delete(expenseId);
            return new NoContentResult();
        }
    }
}