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
        IProductDal _ProductDal;

        public SubProductManager(ISubProductDal subProductDal,IProductDal productDal)
        {
            _SubProductDal = subProductDal;
            _ProductDal = productDal;
        }

        public IResult Add(SubProduct subproduct)
        {

            _SubProductDal.Add(subproduct);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IDataResult<List<SubProduct>> GetAll()
        {
            return new SuccessDataResult<List<SubProduct>>(_SubProductDal.GetAll(), Messages.SubProductsListed);
        }

        public IDataResult<List<SubProduct>> GetById(int Id)
        {
            return new SuccessDataResult<List<SubProduct>>(
                _SubProductDal.GetAll(p=> p.Product.Id == Id),
                Messages.ProductsListed
                
                );
        }
    }
}
