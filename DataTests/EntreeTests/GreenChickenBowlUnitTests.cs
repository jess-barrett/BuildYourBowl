/* Author: Jess Barrett
* File: GreenChickenBowlUnitTests.cs
*/

using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.EntreeTests
{
    /// <summary>
    /// The definition for the GreenChickenBowlUnitTests class
    /// </summary>
    public class GreenChickenBowlUnitTests
    {
        /// <summary>
        /// Tests is the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            GreenChickenBowl gcb = new();

            Assert.True(gcb.Ingredients[Ingredient.Chicken].Included);
            Assert.True(gcb.Ingredients[Ingredient.Veggies].Included);
            Assert.True(gcb.Ingredients[Ingredient.Queso].Included);
            Assert.True(gcb.Ingredients[Ingredient.BlackBeans].Included);
            Assert.True(gcb.Ingredients[Ingredient.Guacamole].Included);
            Assert.True(gcb.Ingredients[Ingredient.SourCream].Included);
            Assert.True(gcb.Ingredients[Ingredient.Salsa].Included);

            Assert.Equal(Salsa.Green, gcb.Salsa);
            Assert.Equal(9.99m, gcb.Price);
            Assert.Equal(890u, gcb.Calories);
            Assert.All(new string[] { }, prepInfo => Assert.Contains(prepInfo, gcb.PreparationInformation));
            Assert.Equal(new string[] { }.Length, gcb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the amount of calories is correct based on the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="bb">If there are black beans</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(false, true, false, false, true, true, Salsa.Green, 500)]
        [InlineData(true, true, true, true, true, true, Salsa.Green, 890)]
        [InlineData(false, false, false, false, false, false, Salsa.None, 210)]
        [InlineData(true, false, true, false, true, false, Salsa.Green, 640)]
        [InlineData(true, true, false, false, true, true, Salsa.Green, 650)]
        [InlineData(false, true, false, true, false, true, Salsa.None, 460)]
        [InlineData(false, false, true, true, false, false, Salsa.Green, 470)]
        [InlineData(true, true, true, false, false, false, Salsa.Green, 510)]
        public void CaloriesTest(bool c, bool v, bool q, bool bb, bool g, bool sc, Salsa s, uint expectedCals)
        {
            GreenChickenBowl gcb = new();

            gcb.Ingredients[Ingredient.Chicken].Included = c;
            gcb.Ingredients[Ingredient.Veggies].Included = v;
            gcb.Ingredients[Ingredient.Queso].Included = q;
            gcb.Ingredients[Ingredient.BlackBeans].Included = bb;
            gcb.Ingredients[Ingredient.Guacamole].Included = g;
            gcb.Ingredients[Ingredient.SourCream].Included = sc;
            gcb.Salsa = s;
            gcb.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedCals, gcb.Calories);
        }

        /// <summary>
        /// Tests that the price is correct based off the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="bb">If there are black beans</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(false, true, false, false, true, true, Salsa.Green, 9.99)]
        [InlineData(true, true, true, true, true, true, Salsa.Green, 9.99)]
        [InlineData(false, false, false, false, false, false, Salsa.None, 9.99)]
        [InlineData(true, false, true, false, true, false, Salsa.Green, 9.99)]
        [InlineData(true, true, false, false, true, true, Salsa.Green, 9.99)]
        [InlineData(false, true, false, true, false, true, Salsa.None, 9.99)]
        [InlineData(false, false, true, true, false, false, Salsa.Green, 9.99)]
        [InlineData(true, true, true, false, false, false, Salsa.Green, 9.99)]
        public void PriceTest(bool c, bool v, bool q, bool bb, bool g, bool sc, Salsa s, decimal expectedPrice)
        {
            GreenChickenBowl gcb = new();

            gcb.Ingredients[Ingredient.Chicken].Included = c;
            gcb.Ingredients[Ingredient.Veggies].Included = v;
            gcb.Ingredients[Ingredient.Queso].Included = q;
            gcb.Ingredients[Ingredient.BlackBeans].Included = bb;
            gcb.Ingredients[Ingredient.Guacamole].Included = g;
            gcb.Ingredients[Ingredient.SourCream].Included = sc;
            gcb.Salsa = s;
            gcb.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedPrice, gcb.Price);
        }

        /// <summary>
        /// Tests that the preparation information is correct based off the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="bb">If there are black beans</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(false, true, false, false, true, true, Salsa.Green, new string[]
            { "Hold Chicken", "Hold Queso", "Hold Black Beans" })]
        [InlineData(true, true, true, true, true, true, Salsa.Green, new string[] { })]
        [InlineData(false, false, false, false, false, false, Salsa.None, new string[]
            { "Hold Chicken", "Hold Veggies", "Hold Queso", "Hold Black Beans", "Hold Guacamole", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(true, false, true, false, true, false, Salsa.Green, new string[]
            { "Hold Veggies", "Hold Black Beans", "Hold Sour Cream" })]
        [InlineData(true, true, false, false, true, true, Salsa.Green, new string[]
            { "Hold Queso", "Hold Black Beans" })]
        [InlineData(false, true, false, true, false, true, Salsa.None, new string[]
            { "Hold Chicken", "Hold Queso", "Hold Guacamole", "Hold Salsa" })]
        [InlineData(false, false, true, true, false, false, Salsa.Green, new string[]
            { "Hold Chicken", "Hold Veggies", "Hold Guacamole", "Hold Sour Cream" })]
        [InlineData(true, true, true, false, false, false, Salsa.Green, new string[]
            { "Hold Black Beans", "Hold Guacamole", "Hold Sour Cream" })]
        public void PrepInfoTest(bool c, bool v, bool q, bool bb, bool g, bool sc, Salsa s, string[] expectedPrepInfo)
        {
            GreenChickenBowl gcb = new();

            gcb.Ingredients[Ingredient.Chicken].Included = c;
            gcb.Ingredients[Ingredient.Veggies].Included = v;
            gcb.Ingredients[Ingredient.Queso].Included = q;
            gcb.Ingredients[Ingredient.BlackBeans].Included = bb;
            gcb.Ingredients[Ingredient.Guacamole].Included = g;
            gcb.Ingredients[Ingredient.SourCream].Included = sc;
            gcb.Salsa = s;
            gcb.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, gcb.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, gcb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            GreenChickenBowl gcb = new();

            Assert.IsAssignableFrom<IMenuItem>(gcb);
            Assert.IsAssignableFrom<Bowl>(gcb);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            GreenChickenBowl gcb = new();

            Assert.Equal("Green Chicken Bowl", gcb.ToString());
        }

        /// <summary>
        /// Tests that changing salsa notifies a property change
        /// </summary>
        /// <param name="salsa">If the milk is chocolate</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(Salsa.Green, "Salsa")]
        [InlineData(Salsa.Hot, "Salsa")]
        [InlineData(Salsa.Medium, "Salsa")]
        [InlineData(Salsa.Mild, "Salsa")]
        [InlineData(Salsa.None, "Salsa")]
        [InlineData(Salsa.Green, "Calories")]
        [InlineData(Salsa.Hot, "Calories")]
        [InlineData(Salsa.Medium, "Calories")]
        [InlineData(Salsa.Mild, "Calories")]
        [InlineData(Salsa.None, "Calories")]
        [InlineData(Salsa.Green, "PreparationInformation")]
        [InlineData(Salsa.Hot, "PreparationInformation")]
        [InlineData(Salsa.Medium, "PreparationInformation")]
        [InlineData(Salsa.Mild, "PreparationInformation")]
        [InlineData(Salsa.None, "PreparationInformation")]
        public void ChangingSalsaShouldNotifyPropertyChange(Salsa salsa, string propertyName)
        {
            GreenChickenBowl item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Salsa = salsa;
            });
        }

        /// <summary>
        /// Tests that changing included notifies a property change
        /// </summary>
        /// <param name="i">The ingredient to include or not</param>
        /// <param name="included">If the ingredient is included</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(Ingredient.Chicken, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        [InlineData(Ingredient.Queso, false, "Price")]
        [InlineData(Ingredient.Chicken, true, "Calories")]
        [InlineData(Ingredient.Guacamole, false, "Calories")]
        [InlineData(Ingredient.Queso, false, "Calories")]
        [InlineData(Ingredient.Chicken, true, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.Queso, false, "PreparationInformation")]
        public void ChangingIncludedShouldNotifyPropertyChange(Ingredient i, bool included, string propertyName)
        {
            GreenChickenBowl item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ingredients[i].Included = included;
            });
        }
    }
}