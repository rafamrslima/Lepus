using Lepus.API.Domain.Enums;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lepus.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{type}/{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(int type, string userName, int year, int month)
        {
            return new ObjectResult(await _transactionService.Get(userName, year, month, (TransactionType)type));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto transactionDto)
        {
            await _transactionService.Post(transactionDto);
            return Ok();
        }

        [HttpPut("{transactionId}")]
        public async Task<IActionResult> Put(string transactionId, [FromBody]TransactionDto transactionDto)
        {
            await _transactionService.Put(transactionId, transactionDto.Value, transactionDto.Description);
            return Ok();
        }

        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> Delete(string transactionId)
        {
            await _transactionService.Delete(transactionId);
            return Ok();
        }

    }
}
