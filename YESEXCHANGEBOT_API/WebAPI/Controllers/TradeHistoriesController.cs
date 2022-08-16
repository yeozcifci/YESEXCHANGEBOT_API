using Business.Repositories.TradeHistoryRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeHistoriesController : ControllerBase
    {
        private readonly ITradeHistoryService _tradeHistoryService;

        public TradeHistoriesController(ITradeHistoryService tradeHistoryService)
        {
            _tradeHistoryService = tradeHistoryService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(tradehistory tradeHistory)
        {
            var result = await _tradeHistoryService.Add(tradeHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(tradehistory tradeHistory)
        {
            var result = await _tradeHistoryService.Update(tradeHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(tradehistory tradeHistory)
        {
            var result = await _tradeHistoryService.Delete(tradeHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _tradeHistoryService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tradeHistoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
