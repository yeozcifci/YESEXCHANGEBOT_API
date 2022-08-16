using Business.ExchangeBots.OkexBots;
using Business.Repositories.buysellstrategyRepository;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BotController : Controller
    {
        private readonly IOkexExchangeBotService _okexExchangeBotService;

        public BotController(IOkexExchangeBotService okexExchangeBotService)
        {
            _okexExchangeBotService = okexExchangeBotService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewBot([FromForm] CreateNewStrategyDto strategyDto)
        {
            var result = await _okexExchangeBotService.CreateNewExchangeBot(strategyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
