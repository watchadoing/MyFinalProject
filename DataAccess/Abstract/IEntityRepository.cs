using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity, new() // t yazarak dedik ki bana çalışacağım tipi söyle. product dersem rpoduct olcak order dersem order olacak
        //ben bu T yi sınırlandırmak istiyorum. herkes T yazamasın. T olarak entities deki concrete ler gelebilsin.
        //yani GENERIC CONSTRAINT kullanıyoruz.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); 
        //add reference entities demem gerek. product u görmeyecek! referanslamam lazım. ampülden referansla
        //business deki product managerdeki getall() ı kullanabilmek için bu expression u kullandık

        //tek bir şeyi getirmesi için kullanılan filter vermek ZORUNLU
        T GetT(Expression<Func<T, bool>> filter);

        //ampülden çıkmadıysa DataAccess e sağ tık Add > service reference
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //caregoryId göre filtrele demek
        //List<T> GetAllByCategory(int categoryId); artık bu koda asla gerek yok 

    }
}
