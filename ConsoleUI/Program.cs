using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            /* product manager testi
            foreach (var product in productManager.GetByUnitPrice(50,200))
            {
                Console.WriteLine(product.CategoryId + "  " + product.ProductName + " \t " + product.UnitPrice + " $");
            }*/

            // ProductTest(productManager);

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryId+" "+category.CategoryName);
            }



        }

        private static void ProductTest(ProductManager productManager)
        {
            foreach (var product in productManager.GetByUnitPrice(50, 200))
            {
                Console.WriteLine(product.CategoryId + "  " + product.ProductName + " \t " + product.UnitPrice + " $");
            }
        }
    }
}
