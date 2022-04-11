using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

//aradan zaman geçti siteye yeni bir şey ekliyoruz.

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public string CustomerId { get; set; } //northvind de customer ıd string dir.
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }


    }
}
