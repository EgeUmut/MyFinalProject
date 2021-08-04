using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;
        ICategoryService _CategoryService;
        

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _ProductDal = productDal;
            _CategoryService = categoryService;
            
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //validation ve business code aynı şey değildir
            //validation-doğrulama 

            //Eski validation yöntemimiz direk attribute olarak yapacaksın bunları
            //ValidationTool.Validate(new ProductValidator(), product);

            //if (product.ProductName.Length<2)
            //{
            //    // magic strings
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}  validations a bak orda yapman lazım bunları

            //bir kategoride en fazla 10 ürün olabilir test. aşağıda method olarak ekledik
            // iş kurallarını kontrol eden kısım
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckProductNameDifference(product.ProductName),
                CheckCategoryCount()
                );

            if (result != null)
            {
                return result;
            }

                    _ProductDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları - yetkisi var mı , if kodları etc.
            //bunu da validation da yapman lazım ama kalsın şimdilik örnek olarak.
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_ProductDal.Get(p => p.ProductId == productId),Messages.GetByIdListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailDto>>(_ProductDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {   // select (*) from products where product.CategoryId == categoryId
            var result = _ProductDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountExceedError);
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckProductNameDifference(string productName)
        {
            var result = _ProductDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckCategoryCount()
        {
            var result = _CategoryService.GetAll();

            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
