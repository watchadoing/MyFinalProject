using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IEnumerable<Product> GetAll() //burayı return etmezsen calismaz!!!
        {
            // var list = new List<Product>()
            //{
            //    new Product { ProductName ="TEST"}
            //};
            // return list;
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int Id)
        {
            return _productDal.GetAll(p=>p.CategoryId==Id);
            //her p için p nin olurda category id si benim gönderdiğim id ye eşitse onları filtrele demek

        }

        public List<Product> GetAllByPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
            //iki fiyat aralığında olan datayı getir dedik
        }

        //ne entityframework ne de inmemory GEÇEMEZ. direk soyut nesne ile bağlantı kuruyoruz.
        List<Product> IProductService.GetAll()
        {
            //iş kodları

            return _productDal.GetAll();

        }
    }
}
