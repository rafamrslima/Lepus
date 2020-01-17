using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Dtos;
using Lepus.API.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        readonly ITransactionService _incomeService;

        public IncomesController(IncomesService incomesService)
        {
            _incomeService = incomesService;
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            try
            {
                return new ObjectResult(await _incomeService.Get(userName, year, month));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransactionDto incomeDto)
        {
            try
            {
                var income = new Transaction(incomeDto.Description, incomeDto.Value, incomeDto.Month, incomeDto.Year, incomeDto.UserName);
                await _incomeService.Post(income);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{incomeId}")]
        public async Task<IActionResult> Put(string incomeId, [FromBody]TransactionDto incomeDto)
        {
            try
            {
                await _incomeService.Put(incomeId, incomeDto.Value, incomeDto.Description);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{IncomeId}")]
        public async Task<IActionResult> Delete(string incomeId)
        {
            try
            {
                await _incomeService.Delete(incomeId);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}