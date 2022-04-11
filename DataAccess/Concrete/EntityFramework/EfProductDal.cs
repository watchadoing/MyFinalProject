using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal

    {
        public void Add(Product entity)
        {   //IDisposable pattern implemation of c# 
            // northwind i normal newlesende çalışır ama using performanslıdır.
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //veri kaynağı ile iliskilendirdim demek
                addedEntity.State = EntityState.Added; //ilişkilendirdiğimiz seyi ne yapacağımız
                context.SaveChanges();  //yap

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //veri kaynağı ile iliskilendirdim demek
                deletedEntity.State = EntityState.Deleted; //ilişkilendirdiğimiz seyi ne yapacağımız
                context.SaveChanges();

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext()) 
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
                //select * from products demek
                //: değilse demek
                //burada filtre olarak göndereceğimiz şey lambda


            }
        }

        public Product GetT(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {   //tabloyu liste gibi getir dedik
                return context.Set<Product>().SingleOrDefault(filter);
            }//bu standart koddur product için yazdık customer için aynı yani generic code haline gelecek

        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //veri kaynağı ile iliskilendirdim demek
                updatedEntity.State = EntityState.Modified; //ilişkilendirdiğimiz seyi ne yapacağımız
                context.SaveChanges();

            };
        }// ilerleyen aşamalarda base entityframework repositoryleri eklenecek
        //çünkü burda kendini tekrar etme var. do not repeat yourself
    }
}
