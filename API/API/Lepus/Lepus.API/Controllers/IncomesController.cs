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
    public class IncomesController : ControllerBase
    {
        readonly BaseService<Income> _service;

        public IncomesController(MongoDbContext mongoDbContext)
        {
            _service = new BaseService<Income>(mongoDbContext.Incomes);
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
        public async Task<IActionResult> Post([FromBody]Income income)
        {
            try
            {
                await _service.Post<IncomeValidator>(income);

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

        [HttpPut("{incomeId}")]
        public async Task<IActionResult> Put(string incomeId, [FromBody]Income income)
        {
            try
            {
                await _service.Put<IncomeValidator>(incomeId, income);

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

        [HttpDelete("{IncomeId}")]
        public async Task<IActionResult> Delete(string incomeId)
        {
            try
            {
                await _service.Delete(incomeId);

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