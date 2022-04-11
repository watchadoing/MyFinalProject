using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Linq;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            hepsini getir
            foreach (Entities.Concrete.Product product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);

            }
            //KategoriId ye göre getir
            foreach (Entities.Concrete.Product product in productManager.GetAllByCategoryId (2))
            {
                Console.WriteLine(product.ProductName);

            }
            //ürün fiyatına göre getir
            foreach (Entities.Concrete.Product product in productManager.GetAllByPrice(40,100))
            {
                Console.WriteLine(product.ProductName);

            }
        }
    }
}
 