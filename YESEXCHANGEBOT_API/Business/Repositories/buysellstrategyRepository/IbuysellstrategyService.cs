using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.buysellstrategyRepository
{
    public interface IbuysellstrategyService
    {
        Task<IResult> Add(buysellstrategy buysellstrategy);
        Task<IResult> Update(buysellstrategy buysellstrategy);
        Task<IResult> Delete(buysellstrategy buysellstrategy);
        Task<IDataResult<List<buysellstrategy>>> GetList();
        Task<IDataResult<buysellstrategy>> GetById(int id);
    }
}
