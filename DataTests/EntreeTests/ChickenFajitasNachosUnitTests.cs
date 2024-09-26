/* Author: Jess Barrett
* File: ChickenFajitasNachosUnitTests.cs
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
    /// The definition for the ChickenFajitasNachosUnitTests class
    /// </summary>
    public class ChickenFajitasNachosUnitTests
    {
        /// <summary>
        /// Tests is the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            ChickenFajitasNachos cfn = new();

            Assert.True(cfn.Ingredients[Ingredient.Chicken].Included);
            Assert.True(cfn.Ingredients[Ingredient.Veggies].Included);
            Assert.True(cfn.Ingredients[Ingredient.Queso].Included);
            Assert.False(cfn.Ingredients[Ingredient.Guacamole].Included);
            Assert.True(cfn.Ingredients[Ingredient.SourCream].Included);
            Assert.True(cfn.Ingredients[Ingredient.Salsa].Included);

            Assert.Equal(Salsa.Medium, cfn.Salsa);
            Assert.Equal(10.99m, cfn.Price);
            Assert.Equal(650u, cfn.Calories);
            Assert.All(new string[] { }, prepInfo => Assert.Contains(prepInfo, cfn.PreparationInformation));
            Assert.Equal(new string[] { }.Length, cfn.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the amount of calories is correct based on the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, 380)] // Required test
        [InlineData(true, true, true, true, true, Salsa.Medium, 800)]
        [InlineData(false, false, false, false, false, Salsa.None, 250)]
        [InlineData(true, false, true, false, true, Salsa.Medium, 630)]
        [InlineData(true, true, false, false, true, Salsa.Medium, 540)]
        [InlineData(false, true, false, true, false, Salsa.None, 420)]
        [InlineData(false, false, true, true, false, Salsa.Medium, 530)]
        [InlineData(true, true, true, false, false, Salsa.Medium, 550)]
        public void CaloriesTest(bool c, bool v, bool q, bool g, bool sc, Salsa s, uint expectedCals)
        {
            ChickenFajitasNachos cfn = new();

            cfn.Ingredients[Ingredient.Chicken].Included = c;
            cfn.Ingredients[Ingredient.Veggies].Included = v;
            cfn.Ingredients[Ingredient.Queso].Included = q;
            cfn.Ingredients[Ingredient.Guacamole].Included = g;
            cfn.Ingredients[Ingredient.SourCream].Included = sc;
            cfn.Salsa = s;
            cfn.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedCals, cfn.Calories);
        }

        /// <summary>
        /// Tests that the price is correct based off the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, 10.99)] // Required test
        [InlineData(true, true, true, true, true, Salsa.Medium, 11.99)]
        [InlineData(false, false, false, false, false, Salsa.None, 10.99)]
        [InlineData(true, false, true, false, true, Salsa.Medium, 10.99)]
        [InlineData(true, true, false, false, true, Salsa.Medium, 10.99)]
        [InlineData(false, true, false, true, false, Salsa.None, 11.99)]
        [InlineData(false, false, true, true, false, Salsa.Medium, 11.99)]
        [InlineData(true, true, true, false, false, Salsa.Medium, 10.99)]
        public void PriceTest(bool c, bool v, bool q, bool g, bool sc, Salsa s, decimal expectedPrice)
        {
            ChickenFajitasNachos cfn = new();

            cfn.Ingredients[Ingredient.Chicken].Included = c;
            cfn.Ingredients[Ingredient.Veggies].Included = v;
            cfn.Ingredients[Ingredient.Queso].Included = q;
            cfn.Ingredients[Ingredient.Guacamole].Included = g;
            cfn.Ingredients[Ingredient.SourCream].Included = sc;
            cfn.Salsa = s;
            cfn.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedPrice, cfn.Price);
        }

        /// <summary>
        /// Tests that the preparation information is correct based off the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(false, false, true, false, false, Salsa.Hot, new string[]
            { "Hold Chicken", "Hold Veggies", "Hold Sour Cream", "Swap Hot Salsa" })] // Required test
        [InlineData(true, true, true, true, true, Salsa.Medium, new string[]
            { "Add Guacamole" })]
        [InlineData(false, false, false, false, false, Salsa.None, new string[]
            { "Hold Chicken", "Hold Veggies", "Hold Queso", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(true, false, true, false, true, Salsa.Medium, new string[]
            { "Hold Veggies" })]
        [InlineData(true, true, false, false, true, Salsa.Medium, new string[]
            { "Hold Queso" })]
        [InlineData(false, true, false, true, false, Salsa.None, new string[]
            { "Hold Chicken", "Hold Queso", "Add Guacamole", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(false, false, true, true, false, Salsa.Medium, new string[]
            { "Hold Chicken", "Hold Veggies", "Add Guacamole", "Hold Sour Cream" })]
        [InlineData(true, true, true, false, false, Salsa.Medium, new string[]
            { "Hold Sour Cream" })]
        public void PrepInfoTest(bool c, bool v, bool q, bool g, bool sc, Salsa s, string[] expectedPrepInfo)
        {
            ChickenFajitasNachos cfn = new();

            cfn.Ingredients[Ingredient.Chicken].Included = c;
            cfn.Ingredients[Ingredient.Veggies].Included = v;
            cfn.Ingredients[Ingredient.Queso].Included = q;
            cfn.Ingredients[Ingredient.Guacamole].Included = g;
            cfn.Ingredients[Ingredient.SourCream].Included = sc;
            cfn.Salsa = s;
            cfn.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, cfn.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, cfn.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            ChickenFajitasNachos cfn = new();

            Assert.IsAssignableFrom<IMenuItem>(cfn);
            Assert.IsAssignableFrom<Nachos>(cfn);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            ChickenFajitasNachos cfn = new();

            Assert.Equal("Spicy Fajitas Nachos", cfn.ToString());
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
            ChickenFajitasNachos item = new();
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
            ChickenFajitasNachos item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ingredients[i].Included = included;
            });
        }
    }
}