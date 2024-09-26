using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// A static menu class
    /// </summary>
    public static class Menu
    {
        static Menu() { }

        /// <summary>
        /// The entrees on the menu
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
                List<IMenuItem> list = new()
                {
                    new Bowl(),
                    new Nachos(),
                    new GreenChickenBowl(),
                    new CarnitasBowl(),
                    new SpicySteakBowl(),
                    new ClassicNachos(),
                    new ChickenFajitasNachos()
                };

                return list;
            }
        }

        /// <summary>
        /// The sides on the menu
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> list = new()
                {
                    new Fries() { Size = Size.Kids, Curly = true },
                    new Fries() { Size = Size.Small, Curly = true },
                    new Fries() { Size = Size.Medium, Curly = true },
                    new Fries() { Size = Size.Large, Curly = true },
                    new Fries() { Size = Size.Kids, Curly = false },
                    new Fries() { Size = Size.Small, Curly = false },
                    new Fries() { Size = Size.Medium, Curly = false },
                    new Fries() { Size = Size.Large, Curly = false },
                    new RefriedBeans() { Size = Size.Kids, CheddarCheese = true, Onions = true },
                    new RefriedBeans() { Size = Size.Small, CheddarCheese = true, Onions = true },
                    new RefriedBeans() { Size = Size.Medium, CheddarCheese = true, Onions = true },
                    new RefriedBeans() { Size = Size.Large, CheddarCheese = true, Onions = true },
                    new RefriedBeans() { Size = Size.Kids, CheddarCheese = true, Onions = false },
                    new RefriedBeans() { Size = Size.Small, CheddarCheese = true, Onions = false },
                    new RefriedBeans() { Size = Size.Medium, CheddarCheese = true, Onions = false },
                    new RefriedBeans() { Size = Size.Large, CheddarCheese = true, Onions = false },
                    new RefriedBeans() { Size = Size.Kids, CheddarCheese = false, Onions = true },
                    new RefriedBeans() { Size = Size.Small, CheddarCheese = false, Onions = true },
                    new RefriedBeans() { Size = Size.Medium, CheddarCheese = false, Onions = true },
                    new RefriedBeans() { Size = Size.Large, CheddarCheese = false, Onions = true },
                    new RefriedBeans() { Size = Size.Kids, CheddarCheese = false, Onions = false },
                    new RefriedBeans() { Size = Size.Small, CheddarCheese = false, Onions = false },
                    new RefriedBeans() { Size = Size.Medium, CheddarCheese = false, Onions = false },
                    new RefriedBeans() { Size = Size.Large, CheddarCheese = false, Onions = false },
                    new StreetCorn() { Size = Size.Kids, Cilantro = true, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Small, Cilantro = true, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Medium, Cilantro = true, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Large, Cilantro = true, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Kids, Cilantro = true, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Small, Cilantro = true, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Medium, Cilantro = true, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Large, Cilantro = true, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Kids, Cilantro = false, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Small, Cilantro = false, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Medium, Cilantro = false, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Large, Cilantro = false, CotijaCheese = true },
                    new StreetCorn() { Size = Size.Kids, Cilantro = false, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Small, Cilantro = false, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Medium, Cilantro = false, CotijaCheese = false },
                    new StreetCorn() { Size = Size.Large, Cilantro = false, CotijaCheese = false }
                };

                return list;
            }
        }

        /// <summary>
        /// The drinks on the menu
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<IMenuItem> list = new()
                {
                    new Milk() { Size = Size.Kids, Chocolate = true },
                    new Milk() { Size = Size.Kids, Chocolate = false },
                    new AguaFresca() { Size = Size.Kids, Flavor = Flavor.Cucumber },
                    new AguaFresca() { Size = Size.Small, Flavor = Flavor.Cucumber },
                    new AguaFresca() { Size = Size.Medium, Flavor = Flavor.Cucumber },
                    new AguaFresca() { Size = Size.Large, Flavor = Flavor.Cucumber },
                    new AguaFresca() { Size = Size.Kids, Flavor = Flavor.Lime },
                    new AguaFresca() { Size = Size.Small, Flavor = Flavor.Lime },
                    new AguaFresca() { Size = Size.Medium, Flavor = Flavor.Lime },
                    new AguaFresca() { Size = Size.Large, Flavor = Flavor.Lime },
                    new AguaFresca() { Size = Size.Kids, Flavor = Flavor.Limonada },
                    new AguaFresca() { Size = Size.Small, Flavor = Flavor.Limonada },
                    new AguaFresca() { Size = Size.Medium, Flavor = Flavor.Limonada },
                    new AguaFresca() { Size = Size.Large, Flavor = Flavor.Limonada },
                    new AguaFresca() { Size = Size.Kids, Flavor = Flavor.Strawberry },
                    new AguaFresca() { Size = Size.Small, Flavor = Flavor.Strawberry },
                    new AguaFresca() { Size = Size.Medium, Flavor = Flavor.Strawberry },
                    new AguaFresca() { Size = Size.Large, Flavor = Flavor.Strawberry },
                    new AguaFresca() { Size = Size.Kids, Flavor = Flavor.Tamarind },
                    new AguaFresca() { Size = Size.Small, Flavor = Flavor.Tamarind },
                    new AguaFresca() { Size = Size.Medium, Flavor = Flavor.Tamarind },
                    new AguaFresca() { Size = Size.Large, Flavor = Flavor.Tamarind },
                    new Horchata() { Size = Size.Kids },
                    new Horchata() { Size = Size.Small },
                    new Horchata() { Size = Size.Medium },
                    new Horchata() { Size = Size.Large }
                };

                return list;
            }
        }

        /// <summary>
        /// The kids meals on the menu
        /// </summary>
        public static IEnumerable<IMenuItem> KidsMeals
        {
            get
            {
                List<IMenuItem> list = new();

                foreach (IMenuItem s in Sides)
                {
                    foreach (IMenuItem d in Drinks)
                    {
                        if (((Side)s).Size == Size.Kids && ((Drink)d).Size == Size.Kids)
                        {
                            list.Add(new ChickenNuggetsMeal() { SideChoice = (Side)s, DrinkChoice = (Drink)d });
                            list.Add(new CornDogBitesMeal() { SideChoice = (Side)s, DrinkChoice = (Drink)d });
                            list.Add(new SlidersMeal() { SideChoice = (Side)s, DrinkChoice = (Drink)d, AmericanCheese = true });
                            list.Add(new SlidersMeal() { SideChoice = (Side)s, DrinkChoice = (Drink)d, AmericanCheese = false });
                        }
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// All the items on the menu
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> list = new();

                list.AddRange(Entrees);
                list.AddRange(Sides);
                list.AddRange(Drinks);
                list.AddRange(KidsMeals);

                return list;
            }
        }

        /// <summary>
        /// The ingredients options available to put on a bowl/nachos
        /// </summary>
        public static IEnumerable<IngredientItem> Ingredients
        {
            get
            {
                List<IngredientItem> list = new()
                {
                    new IngredientItem(Ingredient.BlackBeans),
                    new IngredientItem(Ingredient.Carnitas),
                    new IngredientItem(Ingredient.CheddarCheese),
                    new IngredientItem(Ingredient.Chicken),
                    new IngredientItem(Ingredient.Chips),
                    new IngredientItem(Ingredient.Cilantro),
                    new IngredientItem(Ingredient.CotijaCheese),
                    new IngredientItem(Ingredient.Guacamole),
                    new IngredientItem(Ingredient.Onions),
                    new IngredientItem(Ingredient.PintoBeans),
                    new IngredientItem(Ingredient.Queso),
                    new IngredientItem(Ingredient.Rice),
                    new IngredientItem(Ingredient.Salsa),
                    new IngredientItem(Ingredient.SourCream),
                    new IngredientItem(Ingredient.Steak),
                    new IngredientItem(Ingredient.Veggies)
                };

                return list;
            }
        }

        /// <summary>
        /// The salsa options available
        /// </summary>
        public static IEnumerable<Salsa> Salsas
        {
            get
            {
                List<Salsa> list = new()
                {
                    Salsa.Green,
                    Salsa.Hot,
                    Salsa.Medium,
                    Salsa.Mild,
                    Salsa.None
                };

                return list;
            }
        }

        /// <summary>
        /// Filters the menu by the search terms
        /// </summary>
        /// <param name="terms">The terms to filter by</param>
        /// <returns>The filtered menu</returns>
        public static IEnumerable<IMenuItem> Search(IEnumerable<IMenuItem> menu, string? terms)
        {
            if (terms == null) return menu;

            List<string> termsList = terms.Split().ToList();

            List<IMenuItem> filteredMenu = new();

            foreach (IMenuItem item in menu)
            {
                int i = termsList.Count();

                foreach (string term in termsList)
                {
                    if (item.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase))
                    {
                        i--;
                    }
                    else if (item.PreparationInformation.Any(prepInfo => prepInfo.Contains(term, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        i--;
                    }
                    else if (item is Entree e && e.Ingredients.Values.Any(ingredient => ingredient.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        i--;
                    }
                }

                if (i == 0)
                {
                    filteredMenu.Add(item);
                }
            }

            return filteredMenu;
        }

        /// <summary>
        /// Filters the menu by the given price
        /// </summary>
        /// <param name="menu">The menu to filter</param>
        /// <param name="max">The max price</param>
        /// <param name="min">The min price</param>
        /// <returns>The filtered menu</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> menu, decimal? max, decimal? min)
        {
            if (min == null && max == null) return menu;

            if (min == null)
            {
                return menu.Where(item => item.Price <= max);
            }

            if (max == null)
            {
                return menu.Where(item => item.Price >= min);
            }

            return menu.Where(item => item.Price >= min && item.Price <= max);
        }

        /// <summary>
        /// Filters the menu by the given price
        /// </summary>
        /// <param name="menu">The menu to filter</param>
        /// <param name="max">The max price</param>
        /// <param name="min">The min price</param>
        /// <returns>The filtered menu</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> menu, uint? max, uint? min)
        {
            if (min == null && max == null) return menu;

            if (min == null)
            {
                return menu.Where(item => item.Calories <= max);
            }

            if (max == null)
            {
                return menu.Where(item => item.Calories >= min);
            }

            return menu.Where(item => item.Calories >= min && item.Calories <= max);
        }
    }
}
