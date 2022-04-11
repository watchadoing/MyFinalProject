using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
//business üstü sağ tık add>project reference dedik ve business ve entities i ekledik

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        //yani tüm ürünleri listele dedik
        List<Product> GetAllByCategoryId(int Id);
        //yani kategoriId ye göre listele dedik
        List<Product> GetAllByPrice(decimal min, decimal max);
        //yani şu fiyat aralığında olan ürünleri getir dedik
    }
}
