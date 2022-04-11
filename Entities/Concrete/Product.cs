using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product: IEntity

  //public bu klasa diğer katmanlarda ulaşabilsin demek
  //çünkü data access ürünü ekliycek, business kontrol edecek, console ürünü gösterecek
  //internal demek sadece entities erişebilir demek olur

    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
}
