using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.TradeHistoryRepository.Validation
{
    public class TradeHistoryValidator : AbstractValidator<tradehistory>
    {
        public TradeHistoryValidator()
        {
        }
    }
}
