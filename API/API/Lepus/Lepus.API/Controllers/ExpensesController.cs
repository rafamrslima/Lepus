using Lepus.Domain.Entities;
using Lepus.Infra.Data.Context;
using Lepus.Service.Services;
using Lepus.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly BaseService<Expense> _service;
        public ExpensesController(MongoDbContext mongoDbContext)
        {
            _service = new BaseService<Expense>(mongoDbContext.Expenses);
        }

        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IActionResult> Get(string userName, int year, int month)
        {
            try
            {
                return new ObjectResult(await _service.Get(userName, year, month));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Expense expense)
        {
            try
            {
                await _service.Post<ExpenseValidator>(expense);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> Put(string expenseId, [FromBody]Expense expense)
        {
            try
            {
                await _service.Put<ExpenseValidator>(expenseId, expense);

                return Ok(); 

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> Delete(string expenseId)
        {
            try
            { 
                await _service.Delete(expenseId);

                return new NoContentResult();

            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}