/* Author: Jess Barrett
* File: ClassicNachosUnitTests.cs
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
    /// The definition for the ClassicNachosUnitTests class
    /// </summary>
    public class ClassicNachosUnitTests
    {
        /// <summary>
        /// Tests is the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            ClassicNachos cn = new();

            Assert.True(cn.Ingredients[Ingredient.Steak].Included);
            Assert.True(cn.Ingredients[Ingredient.Chicken].Included);
            Assert.True(cn.Ingredients[Ingredient.Queso].Included);
            Assert.False(cn.Ingredients[Ingredient.Guacamole].Included);
            Assert.True(cn.Ingredients[Ingredient.SourCream].Included);
            Assert.True(cn.Ingredients[Ingredient.Salsa].Included);

            Assert.Equal(Salsa.Medium, cn.Salsa);
            Assert.Equal(12.99m, cn.Price);
            Assert.Equal(710u, cn.Calories);
            Assert.All(new string[] { }, prepInfo => Assert.Contains(prepInfo, cn.PreparationInformation));
            Assert.Equal(new string[] { }.Length, cn.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the amount of calories is correct based on the given values
        /// </summary>
        /// <param name="st">If there is steak</param>
        /// <param name="c">If there is chicken</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Medium, 280)]
        [InlineData(true, true, true, true, true, Salsa.Medium, 860)]
        [InlineData(false, false, false, false, false, Salsa.None, 150)]
        [InlineData(true, false, true, false, true, Salsa.Medium, 560)]
        [InlineData(true, true, false, false, true, Salsa.Medium, 600)]
        [InlineData(false, true, false, true, false, Salsa.None, 450)]
        [InlineData(false, false, true, true, false, Salsa.Medium, 430)]
        [InlineData(true, true, true, false, false, Salsa.Medium, 610)]
        public void CaloriesTest(bool st, bool c, bool q, bool g, bool sc, Salsa s, uint expectedCals)
        {
            ClassicNachos cn = new();

            cn.Ingredients[Ingredient.Steak].Included = st;
            cn.Ingredients[Ingredient.Chicken].Included = c;
            cn.Ingredients[Ingredient.Queso].Included = q;
            cn.Ingredients[Ingredient.Guacamole].Included = g;
            cn.Ingredients[Ingredient.SourCream].Included = sc;
            cn.Salsa = s;
            cn.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedCals, cn.Calories);
        }

        /// <summary>
        /// Tests that the price is correct based off the given values
        /// </summary>
        /// <param name="st">If there is steak</param>
        /// <param name="c">If there is chicken</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, 12.99)]
        [InlineData(true, true, true, true, true, Salsa.Medium, 13.99)]
        [InlineData(false, false, false, false, false, Salsa.None, 12.99)]
        [InlineData(true, false, true, false, true, Salsa.Medium, 12.99)]
        [InlineData(true, true, false, false, true, Salsa.Medium, 12.99)]
        [InlineData(false, true, false, true, false, Salsa.None, 13.99)]
        [InlineData(false, false, true, true, false, Salsa.Medium, 13.99)]
        [InlineData(true, true, true, false, false, Salsa.Medium, 12.99)]
        public void PriceTest(bool st, bool c, bool q, bool g, bool sc, Salsa s, decimal expectedPrice)
        {
            ClassicNachos cn = new();

            cn.Ingredients[Ingredient.Steak].Included = st;
            cn.Ingredients[Ingredient.Chicken].Included = c;
            cn.Ingredients[Ingredient.Queso].Included = q;
            cn.Ingredients[Ingredient.Guacamole].Included = g;
            cn.Ingredients[Ingredient.SourCream].Included = sc;
            cn.Salsa = s;
            cn.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedPrice, cn.Price);
        }

        /// <summary>
        /// Tests that the preparation information is correct based off the given values
        /// </summary>
        /// <param name="st">If there is steak</param>
        /// <param name="c">If there is chicken</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Medium, new string[]
            { "Hold Steak", "Hold Chicken", "Hold Sour Cream" })]
        [InlineData(true, true, true, true, true, Salsa.Medium, new string[]
            { "Add Guacamole" })]
        [InlineData(false, false, false, false, false, Salsa.None, new string[]
            { "Hold Steak", "Hold Chicken", "Hold Queso", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(true, false, true, false, true, Salsa.Medium, new string[]
            { "Hold Chicken" })]
        [InlineData(true, true, false, false, true, Salsa.Medium, new string[]
            { "Hold Queso" })]
        [InlineData(false, true, false, true, false, Salsa.None, new string[]
            { "Hold Steak", "Hold Queso", "Add Guacamole", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(false, false, true, true, false, Salsa.Medium, new string[]
            { "Hold Steak", "Hold Chicken", "Add Guacamole", "Hold Sour Cream" })]
        [InlineData(true, true, true, false, false, Salsa.Medium, new string[]
            { "Hold Sour Cream" })]
        public void PrepInfoTest(bool st, bool c, bool q, bool g, bool sc, Salsa s, string[] expectedPrepInfo)
        {
            ClassicNachos cn = new();

            cn.Ingredients[Ingredient.Steak].Included = st;
            cn.Ingredients[Ingredient.Chicken].Included = c;
            cn.Ingredients[Ingredient.Queso].Included = q;
            cn.Ingredients[Ingredient.Guacamole].Included = g;
            cn.Ingredients[Ingredient.SourCream].Included = sc;
            cn.Salsa = s;
            cn.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, cn.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, cn.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            ClassicNachos cn = new();

            Assert.IsAssignableFrom<IMenuItem>(cn);
            Assert.IsAssignableFrom<Nachos>(cn);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            ClassicNachos cn = new();

            Assert.Equal("Classic Nachos", cn.ToString());
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
            ClassicNachos item = new();
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
            ClassicNachos item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ingredients[i].Included = included;
            });
        }
    }
}