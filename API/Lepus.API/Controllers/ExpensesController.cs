using Lepus.API.Domain.Entities;
using Lepus.API.Domain.Enums;
using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Services;
using Lepus.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly ITransactionService _expenseService;

        public ExpensesController(ExpensesService expensesService)
        {
             _expenseService = expensesService;
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            try
            {
                return new ObjectResult(await _expenseService.Get(userName, year, month));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Transaction expense)
        {
            try
            {
                expense.TransactionType = TransactionType.Expense; 
                await _expenseService.Post(expense);
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

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> Put(string expenseId, [FromBody]Transaction expense)
        {
            try
            {
                expense.TransactionType = TransactionType.Expense;
                await _expenseService.Put(expenseId, expense);
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

        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> Delete(string expenseId)
        {
            try
            {
                await _expenseService.Delete(expenseId);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}