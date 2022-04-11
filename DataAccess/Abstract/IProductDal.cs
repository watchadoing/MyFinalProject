using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
        //yani product ile ilgili veritabanında yapacağım operasyonalrı ekle sil güncelle vs içeren interfacedir.
        //gereic repositoy desing ile ekle isl güncelleyi iptal ettik gerek yok 


    {//interface metodları default olarak publictir!
       



    }
}
