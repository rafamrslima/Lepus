using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using LepusAPI.Models;
using LepusAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LepusAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        readonly ExpensesRepository _expensesRepository;
        public ExpensesController(ExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }
 
        [HttpGet("{userName}/{year}/{month}")]
        public async Task<IEnumerable<Expense>> Get(string userName, int year, int month)
        {
            return await _expensesRepository.Get(userName, year, month);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Expense expense)
        {
            await _expensesRepository.Post(expense);
            return Ok();
        }

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> Put(string expenseId, [FromBody]ExpenseDto expenseDto)
        {
            await _expensesRepository.Put(expenseId, expenseDto);
            return Ok();
        }

        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> Delete(string expenseId)
        {
            await _expensesRepository.Delete(expenseId);
            return Ok();
        }
    }
}