using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.transactionorderRepository.Validation
{
    public class transactionorderValidator : AbstractValidator<transactionorder>
    {
        public transactionorderValidator()
        {
        }
    }
}
