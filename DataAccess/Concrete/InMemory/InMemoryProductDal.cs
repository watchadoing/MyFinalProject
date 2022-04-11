using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory //bellekte databasede değil

{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        //classın içinde ama metodların dışında tanımladık
        //YAZIM KURALI: global değişlen denir ve _products olarak isimlendirilir.
        public InMemoryProductDal() //ctor tab tab yapıp yazdık constructor 
        {
            _products = new List<Product> { //içinde bir çok ürün barındırır
                new Product {ProductId= 1, CategoryId=1, ProductName= "Bardak", UnitPrice=15, UnitsInStock=15},
                // süslü praantezin içinde ctrl+space yapınca alanlar gelir.
                new Product {ProductId=2, CategoryId=1, ProductName= "Kamera", UnitPrice=500, UnitsInStock=3},
                new Product {ProductId=3, CategoryId=2, ProductName= "Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product {ProductId=4, CategoryId=2, ProductName= "Klavye", UnitPrice=150, UnitsInStock=65},
                new Product {ProductId=5, CategoryId=2, ProductName= "Fare", UnitPrice=85, UnitsInStock=1}
                //arkaplanda bellekte bir ürün listesi yani array ı oluşturduk.

                };
        }
        public void Add(Product product) //business ten gonderilen ürünü alıp veritabanına ekliyor.
        {
            _products.Add(product);
            //throw new NotImplementedException(); içinde ilk bu yazıyordu sildik
        }

        public void Delete(Product product)
        {

            //throw new NotImplementedException(); içinde ilk bu yazıyordu sildik

            // _products.Remove(product); yazarsak!!!
            //bu şekilde yazarsan çalışmaz. cünkü listedeki ürünlerin referans numaraları  100 101 102... 
            //ama aşağıda new yazıldığı için referans no 200 oldu belki de yani heap-stack değer ve referans tip konusu!

            //iki ürünü birbirinden ayıran şey Primary Key dir isimleri aynı olabilir ama Id her zaman farklı
            //yani Id yi kullanarak yukarıda eşleşen Id yi bulup o REFERANS ı bulacaz
            //yani link yapacağız

            //lINQsiz metod         //hata vermemesi için null yazdık
            //Language Integrated Query
            Product productToDelete;
            //= foreach için null yapılır.
            //new Product(); SEKTÖRDE YANLIŞ, böyle yazılmaz gereksiz kaynak kullanır. boş yere 201 de ref açar

            //         foreach (var p in _products) //p takma ad //alttaki kodu yazdığımız için foreach a gerek yok.
            //tek tek ürünleri dolaşıyor.
            //        {
            //          if (product.ProductID == p.ProductID)
            //        {
            //          productToDelete = p; //aslında bir product oluşturup referansı ona atıyoruz.
            //    }
            // }
            //LINQ Metodu                               //=> LAMBDA işareti p
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //bu kod foreachın yaptığını yapıyor.

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll() //veritabanındaki datayı business e veriyoruz
        {
            return _products;
            //throw new NotImplementedException();
        }



        public void Update(Product product)
        {
            //throw new NotImplementedException();
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //gönderdiğim ürün id sine sahip olan lsitedeki ürünü bul
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            //içindeki şarta uyan bütün elemanları yeni liste haline getirir onu döndürür.
            
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product GetT(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
            


        




