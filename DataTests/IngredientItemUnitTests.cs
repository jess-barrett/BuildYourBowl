using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    public class IngredientItemUnitTests
    {
        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void BlackBeansDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.BlackBeans);

            Assert.Equal("Black Beans", item.Name);
            Assert.Equal(130u, item.Calories);
            Assert.Equal(1.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void PintoBeansDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.PintoBeans);

            Assert.Equal("Pinto Beans", item.Name);
            Assert.Equal(130u, item.Calories);
            Assert.Equal(1.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void QuesoDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Queso);

            Assert.Equal("Queso", item.Name);
            Assert.Equal(110u, item.Calories);
            Assert.Equal(1.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void VeggiesDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Veggies);

            Assert.Equal("Veggies", item.Name);
            Assert.Equal(20u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void SourCreamDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.SourCream);

            Assert.Equal("Sour Cream", item.Name);
            Assert.Equal(100u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void GuacamoleDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Guacamole);

            Assert.Equal("Guacamole", item.Name);
            Assert.Equal(150u, item.Calories);
            Assert.Equal(1.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void ChickenDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Chicken);

            Assert.Equal("Chicken", item.Name);
            Assert.Equal(150u, item.Calories);
            Assert.Equal(2.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void SteakDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Steak);

            Assert.Equal("Steak", item.Name);
            Assert.Equal(180u, item.Calories);
            Assert.Equal(2.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void CarnitasDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Carnitas);

            Assert.Equal("Carnitas", item.Name);
            Assert.Equal(210u, item.Calories);
            Assert.Equal(2.00m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void RiceDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Rice);

            Assert.Equal("Rice", item.Name);
            Assert.Equal(210u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void ChipsDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Chips);

            Assert.Equal("Chips", item.Name);
            Assert.Equal(250u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void CotijaCheeseDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.CotijaCheese);

            Assert.Equal("Cotija Cheese", item.Name);
            Assert.Equal(80u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void CilantroDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Cilantro);

            Assert.Equal("Cilantro", item.Name);
            Assert.Equal(5u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void OnionsDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Onions);

            Assert.Equal("Onions", item.Name);
            Assert.Equal(5u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void CheddarCheeseDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.CheddarCheese);

            Assert.Equal("Cheddar Cheese", item.Name);
            Assert.Equal(90u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        /// <summary>
        /// Tests the default values of the IngredientItem's properties
        /// </summary>
        [Fact]
        public void SalsaDefaultValuesTest()
        {
            IngredientItem item = new(Ingredient.Salsa);

            Assert.Equal("Salsa", item.Name);
            Assert.Equal(20u, item.Calories);
            Assert.Equal(0m, item.UnitCost);
            Assert.False(item.Included);
            Assert.False(item.Default);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ChangingIncludedShouldNotifyPropetyChange(bool included)
        {
            IngredientItem item = new(Ingredient.Chicken);
            Assert.PropertyChanged(item, "Included", () => {
                item.Included = included;
            });
        }
    }
}
