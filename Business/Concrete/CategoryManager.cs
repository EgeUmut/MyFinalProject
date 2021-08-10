using Business.Abstract;
using Core.Aspects.Autofac.Caching;
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
    public class CategoryManager : ICategoryService
    {
        // iş kodlarının yazıldığı yerler
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            // business codes
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Category> GetById(int categoryId)
        {
            // select * from categories where categoryId = 3
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId));
        }
    }
}
