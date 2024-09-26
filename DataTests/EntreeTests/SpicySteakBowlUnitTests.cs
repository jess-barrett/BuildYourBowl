/* Author: Jess Barrett
* File: SpicySteakBowlUnitTests.cs
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
    /// The definition for the SpicySteakBowlUnitTests class
    /// </summary>
    public class SpicySteakBowlUnitTests
    {
        /// <summary>
        /// Tests is the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            SpicySteakBowl ss = new();

            Assert.True(ss.Ingredients[Ingredient.Steak].Included);
            Assert.False(ss.Ingredients[Ingredient.Veggies].Included);
            Assert.True(ss.Ingredients[Ingredient.Queso].Included);
            Assert.False(ss.Ingredients[Ingredient.Guacamole].Included);
            Assert.True(ss.Ingredients[Ingredient.SourCream].Included);
            Assert.True(ss.Ingredients[Ingredient.Salsa].Included);

            Assert.Equal(Salsa.Hot, ss.Salsa);
            Assert.Equal(10.99m, ss.Price);
            Assert.Equal(620u, ss.Calories);
            Assert.All(new string[] { }, prepInfo => Assert.Contains(prepInfo, ss.PreparationInformation));
            Assert.Equal(new string[] { }.Length, ss.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the amount of calories is correct based on the given values
        /// </summary>
        /// <param name="c">If there is steak</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, 340)]
        [InlineData(true, true, true, true, true, Salsa.Hot, 790)]
        [InlineData(false, false, false, false, false, Salsa.None, 210)]
        [InlineData(true, false, true, false, true, Salsa.Hot, 620)]
        [InlineData(true, true, false, false, true, Salsa.Hot, 530)]
        [InlineData(false, true, false, true, false, Salsa.None, 380)]
        [InlineData(false, false, true, true, false, Salsa.Hot, 490)]
        [InlineData(true, true, true, false, false, Salsa.Hot, 540)]
        public void CaloriesTest(bool c, bool v, bool q, bool g, bool sc, Salsa s, uint expectedCals)
        {
            SpicySteakBowl ss = new();

            ss.Ingredients[Ingredient.Steak].Included = c;
            ss.Ingredients[Ingredient.Veggies].Included = v;
            ss.Ingredients[Ingredient.Queso].Included = q;
            ss.Ingredients[Ingredient.Guacamole].Included = g;
            ss.Ingredients[Ingredient.SourCream].Included = sc;
            ss.Salsa = s;
            ss.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedCals, ss.Calories);
        }

        /// <summary>
        /// Tests that the price is correct based off the given values
        /// </summary>
        /// <param name="c">If there is Steak</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, 10.99)] // Required test
        [InlineData(true, true, true, true, true, Salsa.Hot, 11.99)]
        [InlineData(false, false, false, false, false, Salsa.None, 10.99)]
        [InlineData(true, false, true, false, true, Salsa.Hot, 10.99)]
        [InlineData(true, true, false, false, true, Salsa.Hot, 10.99)]
        [InlineData(false, true, false, true, false, Salsa.None, 11.99)]
        [InlineData(false, false, true, true, false, Salsa.Hot, 11.99)]
        [InlineData(true, true, true, false, false, Salsa.Hot, 10.99)]
        public void PriceTest(bool c, bool v, bool q, bool g, bool sc, Salsa s, decimal expectedPrice)
        {
            SpicySteakBowl ss = new();

            ss.Ingredients[Ingredient.Steak].Included = c;
            ss.Ingredients[Ingredient.Veggies].Included = v;
            ss.Ingredients[Ingredient.Queso].Included = q;
            ss.Ingredients[Ingredient.Guacamole].Included = g;
            ss.Ingredients[Ingredient.SourCream].Included = sc;
            ss.Salsa = s;
            ss.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedPrice, ss.Price);
        }

        /// <summary>
        /// Tests that the preparation information is correct based off the given values
        /// </summary>
        /// <param name="c">If there is Steak</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, new string[]
            { "Hold Steak", "Hold Sour Cream" })]
        [InlineData(true, true, true, true, true, Salsa.Hot, new string[]
            { "Add Veggies", "Add Guacamole" })]
        [InlineData(false, false, false, false, false, Salsa.None, new string[]
            { "Hold Steak", "Hold Queso", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(true, false, true, false, true, Salsa.Hot, new string[] { })]
        [InlineData(true, true, false, false, true, Salsa.Hot, new string[]
            { "Add Veggies", "Hold Queso" })]
        [InlineData(false, true, false, true, false, Salsa.None, new string[]
            { "Hold Steak", "Add Veggies", "Hold Queso", "Add Guacamole", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(false, false, true, true, false, Salsa.Hot, new string[]
            { "Hold Steak", "Add Guacamole", "Hold Sour Cream" })]
        [InlineData(true, true, true, false, false, Salsa.Hot, new string[]
            { "Add Veggies", "Hold Sour Cream" })]
        public void PrepInfoTest(bool c, bool v, bool q, bool g, bool sc, Salsa s, string[] expectedPrepInfo)
        {
            SpicySteakBowl ss = new();

            ss.Ingredients[Ingredient.Steak].Included = c;
            ss.Ingredients[Ingredient.Veggies].Included = v;
            ss.Ingredients[Ingredient.Queso].Included = q;
            ss.Ingredients[Ingredient.Guacamole].Included = g;
            ss.Ingredients[Ingredient.SourCream].Included = sc;
            ss.Salsa = s;
            ss.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, ss.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, ss.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            SpicySteakBowl ss = new();

            Assert.IsAssignableFrom<IMenuItem>(ss);
            Assert.IsAssignableFrom<Bowl>(ss);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            SpicySteakBowl ss = new();

            Assert.Equal("Spicy Steak Bowl", ss.ToString());
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
            SpicySteakBowl item = new();
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
        [InlineData(Ingredient.Steak, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        [InlineData(Ingredient.Queso, false, "Price")]
        [InlineData(Ingredient.Steak, true, "Calories")]
        [InlineData(Ingredient.Guacamole, false, "Calories")]
        [InlineData(Ingredient.Queso, false, "Calories")]
        [InlineData(Ingredient.Steak, true, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.Queso, false, "PreparationInformation")]
        public void ChangingIncludedShouldNotifyPropertyChange(Ingredient i, bool included, string propertyName)
        {
            SpicySteakBowl item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ingredients[i].Included = included;
            });
        }
    }
}