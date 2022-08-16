using Business.Repositories.StrategyTransactionRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategyTransactionsController : ControllerBase
    {
        private readonly IStrategyTransactionService _strategyTransactionService;

        public StrategyTransactionsController(IStrategyTransactionService strategyTransactionService)
        {
            _strategyTransactionService = strategyTransactionService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StrategyTransaction strategyTransaction)
        {
            var result = await _strategyTransactionService.Add(strategyTransaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StrategyTransaction strategyTransaction)
        {
            var result = await _strategyTransactionService.Update(strategyTransaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StrategyTransaction strategyTransaction)
        {
            var result = await _strategyTransactionService.Delete(strategyTransaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _strategyTransactionService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _strategyTransactionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
