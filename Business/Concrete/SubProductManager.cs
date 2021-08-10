using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
 
    public class SubProductManager : ISubProductService
    {
        ISubProductDal _SubProductDal;

        public SubProductManager(ISubProductDal subProductDal)
        {
            _SubProductDal = subProductDal;
        }

        public IDataResult<List<SubProduct>> GetAll()
        {
            return new SuccessDataResult<List<SubProduct>>(_SubProductDal.GetAll(), Messages.SubProductsListed);
        }
    }
}
