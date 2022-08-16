using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.PairBuySellStrategyRepository.Validation
{
    public class PairBuySellStrategyValidator : AbstractValidator<PairBuySellStrategy>
    {
        public PairBuySellStrategyValidator()
        {
        }
    }
}
