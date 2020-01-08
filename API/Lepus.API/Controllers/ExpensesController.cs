using Lepus.API.Domain.Interfaces;
using Lepus.API.Service.Services;
using Lepus.Domain.Entities;
using Lepus.Domain.Interfaces;
using Lepus.Infra.Data.Context;
using Lepus.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lepus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        readonly IBaseService<Expense> _baseService;
        readonly IExpensesService _expenseService;

        public ExpensesController(MongoDbContext mongoDbContext)
        {
            _baseService = new BaseService<Expense>(mongoDbContext.Expenses);
            _expenseService = new ExpensesService(mongoDbContext.Expenses);
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
        public async Task<IActionResult> Post([FromBody]Expense expense)
        {
            try
            {
                await _baseService.Post(expense); 
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
        public async Task<IActionResult> Put(string expenseId, [FromBody]Expense expense)
        {
            try
            {
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
                await _baseService.Delete(expenseId); 
                return new NoContentResult(); 
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            } 
        }
    }
}