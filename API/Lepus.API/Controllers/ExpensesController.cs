using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using Lepus.API.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly ITransactionService _expenseService;
        readonly ITransactionService _transactionService;

        public ExpensesController(ExpensesService expensesService)
        {
            _expenseService = expensesService;
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            return new ObjectResult(await _expenseService.Get(userName, year, month));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto expenseDto)
        {
            var expense = new Transaction(expenseDto.Description, expenseDto.Value, expenseDto.Month, expenseDto.Year, expenseDto.UserName);
            await _expenseService.Post(expense);
            return Ok();
        }

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> Put(string expenseId, [FromBody]TransactionDto expenseDto)
        {
            await _expenseService.Put(expenseId, expenseDto.Value, expenseDto.Description);
            return Ok();
        }

        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> Delete(string expenseId)
        {
            await _expenseService.Delete(expenseId);
            return new NoContentResult();
        }
    }
}