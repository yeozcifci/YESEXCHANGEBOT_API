using Core.Utilities.Result.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Dtos;

namespace Business.ExchangeBots.OkexBots
{
    public interface IOkexExchangeBotService
    {
        Task<IResult> CreateNewExchangeBot(CreateNewStrategyDto strategyDto);
    }
}
