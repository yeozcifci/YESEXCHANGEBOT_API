using Business.Repositories.PairBuySellStrategyRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairBuySellStrategiesController : ControllerBase
    {
        private readonly IPairBuySellStrategyService _pairBuySellStrategyService;

        public PairBuySellStrategiesController(IPairBuySellStrategyService pairBuySellStrategyService)
        {
            _pairBuySellStrategyService = pairBuySellStrategyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(PairBuySellStrategy pairBuySellStrategy)
        {
            var result = await _pairBuySellStrategyService.Add(pairBuySellStrategy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(PairBuySellStrategy pairBuySellStrategy)
        {
            var result = await _pairBuySellStrategyService.Update(pairBuySellStrategy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(PairBuySellStrategy pairBuySellStrategy)
        {
            var result = await _pairBuySellStrategyService.Delete(pairBuySellStrategy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _pairBuySellStrategyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pairBuySellStrategyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
