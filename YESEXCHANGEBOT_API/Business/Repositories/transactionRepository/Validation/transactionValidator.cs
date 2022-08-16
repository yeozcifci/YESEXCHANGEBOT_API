using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.transactionRepository.Validation
{
    public class transactionValidator : AbstractValidator<transaction>
    {
        public transactionValidator()
        {
        }
    }
}
