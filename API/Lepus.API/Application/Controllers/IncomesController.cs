using Lepus.API.Domain.Enums;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lepus.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        readonly ITransactionService _transactionService;

        public IncomesController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            return new ObjectResult(await _transactionService.Get(userName, year, month, TransactionType.Income));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto incomeDto)
        {
            await _transactionService.Post(incomeDto, TransactionType.Income);
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