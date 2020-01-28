using Lepus.API.Domain.Enums;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lepus.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly ITransactionService _transactionService;
            
        public ExpensesController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            return new ObjectResult(await _transactionService.Get(userName, year, month, TransactionType.Expense));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto expenseDto)
        {
            await _transactionService.Post(expenseDto, TransactionType.Expense);
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