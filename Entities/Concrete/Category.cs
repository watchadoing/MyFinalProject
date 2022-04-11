using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete //işaretlemem lazım concrete klasöründeki classlar bir veritabanı tablosuna karşılık geliyor.

{
    public class Category: IEntity //işaretledik

    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
