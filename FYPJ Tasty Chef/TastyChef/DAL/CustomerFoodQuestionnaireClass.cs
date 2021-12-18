using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class CustomerFoodQuestionnaireClass
    {
        public string diet { get; set; }
        public string allergies { get; set; }
        public string avoidance { get; set; }
        public int meal { get; set; }
        public int snack { get; set; }

        public CustomerFoodQuestionnaireClass()
        {

        }

        public CustomerFoodQuestionnaireClass(string a)
        {
            this.allergies = a;
        }

        public CustomerFoodQuestionnaireClass(string d, string allergy, string a, int mealfrequency, int snackfrequency)
        {
            this.diet = d;
            this.allergies = allergy;
            this.avoidance = a;
            this.meal = mealfrequency;
            this.snack = snackfrequency;
        }
    }
}