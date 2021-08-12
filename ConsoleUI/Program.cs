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
            ProductManager productManager = new ProductManager(new EfProductDal(),
                new CategoryManager(new EfCategoryDal()));

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            // ProductTest(productManager);

            //CategoryTest(categoryManager);

            viewTest(productManager);

        }

        private static void viewTest(ProductManager productManager)
        {
            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach(var view in result.Data)
            {   // biraz çorba ama anlarsın
                    Console.WriteLine("product id: " + view.Id +
                        "\t" + view.ProductName +
                        "\t in stock: " + view.UnitsInStock +
                        "\t category name: " + view.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryTest(CategoryManager categoryManager)
        {
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.Id + " " + category.CategoryName);
            }
        }

        private static void ProductTest(ProductManager productManager)
        {
            foreach (var product in productManager.GetByUnitPrice(50, 200).Data)
            {
                Console.WriteLine(product.CategoryId + "  " + product.ProductName + " \t " + product.UnitPrice + " $");
            }
        }
    }
}
