using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// The class definition for MenuUnitTests
    /// </summary>
    public class MenuUnitTests
    {
        /// <summary>
        /// Tests that the number of entrees is correct
        /// </summary>
        [Fact]
        public void EntreesCountTest()
        {
            Assert.Equal(7, Menu.Entrees.Count());
        }

        /// <summary>
        /// Tests that the number of sides is correct
        /// </summary>
        [Fact]
        public void SidesCountTest()
        {
            Assert.Equal(4 * (2 + (2 * 2) + (2 * 2)), Menu.Sides.Count());
        }

        /// <summary>
        /// Tests that the number of drinks is correct
        /// </summary>
        [Fact]
        public void DrinksCountTest()
        {
            Assert.Equal((4 * (5 + 1)) + 2, Menu.Drinks.Count());
        }

        /// <summary>
        /// Tests that the number of kids meals is correct
        /// </summary>
        [Fact]
        public void KidsMealCountTest()
        {
            Assert.Equal(
                2 * ((Menu.Sides.Count() / 4) * (((Menu.Drinks.Count() - 2) / 4) + 2)) +
                1 * ((Menu.Sides.Count() / 4) * (((Menu.Drinks.Count() - 2) / 4) + 2) * 2),
                Menu.KidsMeals.Count()
            );
        }

        /// <summary>
        /// Tests that the total number of meals is correct
        /// </summary>
        [Fact]
        public void FullMenuCountTest()
        {
            Assert.Equal(
                Menu.Entrees.Count() + Menu.Sides.Count() + Menu.Drinks.Count() + Menu.KidsMeals.Count(),
                Menu.FullMenu.Count()
            );
        }

        /// <summary>
        /// Tests that the number of ingredients is correct
        /// </summary>
        [Fact]
        public void IngredientCountTest()
        {
            Assert.Equal(16, Menu.Ingredients.Count());
        }

        /// <summary>
        /// Tests that the number of salsa options is correct
        /// </summary>
        [Fact]
        public void SalsaCountTest()
        {
            Assert.Equal(5, Menu.Salsas.Count());
        }

        /// <summary>
        /// Tests that the entrees contains all possibilities
        /// </summary>
        [Fact]
        public void EntreeContainsTest()
        {
            List<Entree> entrees = new() {
                new Bowl(),
                new Nachos(),
                new GreenChickenBowl(),
                new SpicySteakBowl(),
                new CarnitasBowl(),
                new ClassicNachos(),
                new ChickenFajitasNachos()
            };

            foreach (Entree e in entrees)
            {
                Assert.Contains(Menu.Entrees, item => item.Name == e.Name);
            }
        }

        /// <summary>
        /// Tests that the sides contains all possibilities
        /// </summary>
        [Fact]
        public void SidesContainsTest()
        {
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                Assert.Contains(Menu.Sides, item => item is Fries f && f.Curly && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is Fries f && !f.Curly && f.Size == size);

                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && r.CheddarCheese && r.Onions && r.Size == size);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && !r.CheddarCheese && r.Onions && r.Size == size);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && r.CheddarCheese && !r.Onions && r.Size == size);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans r && !r.CheddarCheese && !r.Onions && r.Size == size);

                Assert.Contains(Menu.Sides, item => item is StreetCorn c && c.CotijaCheese && c.Cilantro && c.Size == size);
                Assert.Contains(Menu.Sides, item => item is StreetCorn c && !c.CotijaCheese && c.Cilantro && c.Size == size);
                Assert.Contains(Menu.Sides, item => item is StreetCorn c && c.CotijaCheese && !c.Cilantro && c.Size == size);
                Assert.Contains(Menu.Sides, item => item is StreetCorn c && !c.CotijaCheese && !c.Cilantro && c.Size == size);
            }
        }

        /// <summary>
        /// Tests that drinks contains all possibilities
        /// </summary>
        [Fact]
        public void DrinksContainsTest()
        {
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                Assert.Contains(Menu.Drinks, item => item is AguaFresca a && a.Flavor == Flavor.Cucumber && a.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca a && a.Flavor == Flavor.Lime && a.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca a && a.Flavor == Flavor.Limonada && a.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca a && a.Flavor == Flavor.Strawberry && a.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca a && a.Flavor == Flavor.Tamarind && a.Size == size);

                Assert.Contains(Menu.Drinks, item => item is Horchata h && h.Size == size);
            }

            Assert.Contains(Menu.Drinks, item => item is Milk m && m.Chocolate && m.Size == Size.Kids);
            Assert.Contains(Menu.Drinks, item => item is Milk m && !m.Chocolate && m.Size == Size.Kids);
        }

        /// <summary>
        /// Test that kids meals contains all possibilities
        /// </summary>
        [Fact]
        public void KidsMealsContainsTest()
        {
            List<KidsMeal> kidsMeals = new()
            {
                new ChickenNuggetsMeal(),
                new CornDogBitesMeal(),
                new SlidersMeal()
            };

            foreach (KidsMeal meal in kidsMeals)
            {
                foreach (IMenuItem side in Menu.Sides)
                {
                    foreach (IMenuItem drink in Menu.Drinks)
                    {
                        if (((Side)side).Size == Size.Kids && ((Drink)drink).Size == Size.Kids)
                        {
                            Assert.Contains(Menu.KidsMeals, item =>
                                item is KidsMeal m &&
                                m.SideChoice.Equals(side) &&
                                m.DrinkChoice.Equals(drink)
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tests that full menu contains all possibilities
        /// </summary>
        [Fact]
        public void FullMenuContainsTest()
        {
            foreach (IMenuItem entree in Menu.Entrees)
            {
                Assert.Contains(Menu.FullMenu, item =>
                    item.Name == entree.Name
                );
            }

            foreach (IMenuItem side in Menu.Sides)
            {
                Assert.Contains(Menu.FullMenu, item => 
                    item is Side i &&
                    side is Side s &&
                    s.Equals(i)
                );
            }

            foreach (IMenuItem drink in Menu.Drinks)
            {
                Assert.Contains(Menu.FullMenu, item =>
                    item is Drink i &&
                    drink is Drink d &&
                    i.Equals(d)
                );
            }

            foreach (IMenuItem meal in Menu.KidsMeals)
            {
                Assert.Contains(Menu.FullMenu, item =>
                    item is KidsMeal i &&
                    meal is KidsMeal m &&
                    i.Equals(m)
                );
            }
        }

        /// <summary>
        /// Tests that the price filter works correctly
        /// </summary>
        /// <param name="max">The max price</param>
        /// <param name="min">The min price</param>
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, 5)]
        [InlineData(5, null)]
        [InlineData(3, 6)]
        [InlineData(6, 3)]
        public void PriceFilterTest(int? max, int? min)
        {
            IEnumerable<IMenuItem> fullMenu = Menu.FullMenu;

            decimal? maxD = max == null ? null : (decimal)max;

            decimal? minD = min == null ? null : (decimal)min;

            IEnumerable<IMenuItem> filteredMenu = Menu.FilterByPrice(fullMenu, maxD, minD);

            if (max == null && min == null)
            {
                Assert.Equal(fullMenu, filteredMenu);
            }
            else
            {
                Assert.All(filteredMenu, item =>
                {
                    Assert.True((max == null || item.Price <= max) && (min == null || item.Price >= min));
                });

                IEnumerable<IMenuItem> itemsWithinRange = fullMenu.Where(item => (max == null || item.Price <= max) && (min == null || item.Price >= min));
                Assert.All(itemsWithinRange, item =>
                {
                    Assert.Contains(item, filteredMenu);
                });

            }
        }

        /// <summary>
        /// Tests that the calories filter works correctly
        /// </summary>
        /// <param name="max">The max calories</param>
        /// <param name="min">The min calories</param>
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, 5u)]
        [InlineData(5u, null)]
        [InlineData(3u, 6u)]
        [InlineData(6u, 3u)]
        public void CaloriesFilterTest(uint? max, uint? min)
        {
            IEnumerable<IMenuItem> fullMenu = Menu.FullMenu;

            IEnumerable<IMenuItem> filteredMenu = Menu.FilterByCalories(fullMenu, max, min);

            if (max == null && min == null)
            {
                Assert.Equal(fullMenu, filteredMenu);
            }
            else
            {
                Assert.All(filteredMenu, item =>
                {
                    Assert.True((max == null || item.Calories <= max) && (min == null || item.Calories >= min));
                });

                IEnumerable<IMenuItem> itemsWithinRange = fullMenu.Where(item => (max == null || item.Calories <= max) && (min == null || item.Calories >= min));
                Assert.All(itemsWithinRange, item =>
                {
                    Assert.Contains(item, filteredMenu);
                });

            }
        }

        /// <summary>
        /// Tests that the keyword filter works correctly
        /// </summary>
        /// <param name="keywords">The keywords to filter by</param>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Chicken")]
        [InlineData("Fries")]
        [InlineData("Fries Curly")]
        [InlineData("Fries Steak Beans")]
        [InlineData("STREET CORN")]
        [InlineData("AgUa FrEsCa")]
        public void KeywordFilterTest(string? keywords)
        {
            List<IMenuItem> menu = new()
            {
                new GreenChickenBowl(),
                new ChickenNuggetsMeal(),
                new Fries() { Curly = true },
                new AguaFresca() { Flavor = Flavor.Lime },
                new StreetCorn() { Size = Size.Large },
                new ClassicNachos()
            };

            IEnumerable<IMenuItem> filteredMenu = Menu.Search(menu, keywords);

            if (string.IsNullOrEmpty(keywords))
            {
                Assert.Equal(menu, filteredMenu);
            }
            else
            {
                string[] keywordsArr = keywords.ToLower().Split();


                Assert.All(filteredMenu, item =>
                {
                    string itemName = item.Name.ToLower();
                    IEnumerable<string> preparationInfo = item.PreparationInformation.Select(prepInfo => prepInfo.ToLower());
                    IEnumerable<string> ingredientNames = item is Entree entree ? entree.Ingredients.Select(i => i.Value.Name.ToLower()) : Enumerable.Empty<string>();

                    bool containsAllKeywords = keywordsArr.All(k =>
                        itemName.Contains(k) ||
                        preparationInfo.Any(pi => pi.Contains(k)) ||
                        ingredientNames.Any(i => i.Contains(k))
                    );

                    Assert.True(containsAllKeywords);
                });
            }
        }

    }
}
