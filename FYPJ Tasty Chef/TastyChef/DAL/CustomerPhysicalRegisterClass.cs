using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class CustomerPhysicalRegisterClass
    {

        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string activity { get; set; }
        public decimal calories { get; set; }
        public decimal bmi { get; set; }
        public decimal bmr { get; set; }

        public CustomerPhysicalRegisterClass()
        {

        }

        public CustomerPhysicalRegisterClass(decimal h, decimal w, string a, decimal c, decimal b, decimal br)
        {
            this.height = h;
            this.weight = w;
            this.activity = a;
            this.calories = c;
            this.bmi = b;
            this.bmr = br;
        }


       

      

       

    }
}