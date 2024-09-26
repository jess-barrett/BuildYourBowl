using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.PointOfSale;

namespace BuildYourBowl.DataTests
{
    public class PaymentViewModelIntegrationTests
    {
        [Fact]
        public void PaymentViewModelIntegrationTest()
        {
            Order o = new();

            Assert.Equal(1, o.Number);

            o.Add(new SlidersMeal
            {
                Count = 3,
                AmericanCheese = false,
                SideChoice = new RefriedBeans { Size = Size.Medium, Onions = false },
                DrinkChoice = new AguaFresca { Size = Size.Large, Flavor = Flavor.Tamarind, Ice = false },

            });

            Bowl b = new();
            b.Ingredients[Ingredient.Steak].Included = true;
            b.Ingredients[Ingredient.Queso].Included = true;
            b.Ingredients[Ingredient.SourCream].Included = true;
            o.Add(b);

            ChickenFajitasNachos cfn = new();
            cfn.Ingredients[Ingredient.Guacamole].Included = true;
            cfn.Ingredients[Ingredient.SourCream].Included = false;
            cfn.Ingredients[Ingredient.Salsa].Included = false;
            o.Add(cfn);

            Assert.Equal(33.47m, o.Subtotal);
            Assert.Equal(3.06m, o.Tax);
            Assert.Equal(36.53m, o.Total);

            PaymentViewModel pvm = new(o);
            pvm.Paid = 40m;

            Assert.Equal(3.47m, pvm.Change);

            Order o2 = new();

            Assert.Equal(2, o2.Number);

            o2.Add(new StreetCorn
            {
                Size = Size.Large,
                Cilantro = false
            });

            o2.Add(new AguaFresca
            {
                Size = Size.Kids,
                Flavor = Flavor.Tamarind
            });

            Nachos n = new();
            n.Ingredients[Ingredient.BlackBeans].Included = true;
            n.Ingredients[Ingredient.PintoBeans].Included = true;
            n.Ingredients[Ingredient.Veggies].Included = true;
            n.Salsa = Salsa.Green;
            o2.Add(n);

            Assert.Equal(17.99m, o2.Subtotal);
            Assert.Equal(1.65m, o2.Tax);
            Assert.Equal(19.64m, o2.Total);

            PaymentViewModel pvm2 = new(o2);

            Assert.Throws<ArgumentException>(() => {
                pvm2.Paid = 15m;
            });

        }
    }
}
