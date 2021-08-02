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

            // ProductTest(productManager);

            //CategoryTest(categoryManager);

            //viewTest(productManager);

        }

        private static void viewTest(ProductManager productManager)
        {
            foreach (var view in productManager.GetProductDetails())
            {   // biraz çorba ama anlarsın
                Console.WriteLine("product id: " + view.ProductId +
                    "\t" + view.ProductName +
                    "\t in stock: " + view.UnitsInStock +
                    "\t category name: " + view.CategoryName);
            }
        }

        private static void CategoryTest(CategoryManager categoryManager)
        {
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryId + " " + category.CategoryName);
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
