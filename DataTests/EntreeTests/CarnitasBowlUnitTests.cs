/* Author: Jess Barrett
* File: CarnitasBowlUnitTests.cs
*/

using BuildYourBowl.Data.Entrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Drinks;

namespace BuildYourBowl.DataTests.EntreeTests
{
    /// <summary>
    /// The definition for the CarnitasBowlUnitTests class
    /// </summary>
    public class CarnitasBowlUnitTests
    {
        /// <summary>
        /// Tests if the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            CarnitasBowl cb = new();

            Assert.True(cb.Ingredients[Ingredient.Carnitas].Included);
            Assert.False(cb.Ingredients[Ingredient.Veggies].Included);
            Assert.True(cb.Ingredients[Ingredient.Queso].Included);
            Assert.True(cb.Ingredients[Ingredient.PintoBeans].Included);
            Assert.False(cb.Ingredients[Ingredient.Guacamole].Included);
            Assert.False(cb.Ingredients[Ingredient.SourCream].Included);
            Assert.True(cb.Ingredients[Ingredient.Salsa].Included);
            Assert.Equal(Salsa.Medium, cb.Salsa);
            Assert.Equal(9.99m, cb.Price);
            Assert.Equal(680u, cb.Calories);
            Assert.All(new string[] { }, prepInfo => Assert.Contains(prepInfo, cb.PreparationInformation));
            Assert.Equal(new string[] { }.Length, cb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the amount of calories is correct based on the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="pb">If there are pinto beans</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(false, true, false, false, true, true, Salsa.Medium, 500)] // Required test
        [InlineData(true, true, true, true, true, true, Salsa.Medium, 950)]
        [InlineData(false, false, false, false, false, false, Salsa.None, 210)]
        [InlineData(true, false, true, false, true, false, Salsa.Medium, 700)]
        [InlineData(true, true, false, false, true, true, Salsa.Medium, 710)]
        [InlineData(false, true, false, true, false, true, Salsa.None, 460)]
        [InlineData(false, false, true, true, false, false, Salsa.Medium, 470)]
        [InlineData(true, true, true, false, false, false, Salsa.Medium, 570)]
        public void CaloriesTest(bool c, bool v, bool q, bool pb, bool g, bool sc, Salsa s, uint expectedCals)
        {
            CarnitasBowl cb = new();

            cb.Ingredients[Ingredient.Carnitas].Included = c;
            cb.Ingredients[Ingredient.Veggies].Included = v;
            cb.Ingredients[Ingredient.Queso].Included = q;
            cb.Ingredients[Ingredient.PintoBeans].Included = pb;
            cb.Ingredients[Ingredient.Guacamole].Included = g;
            cb.Ingredients[Ingredient.SourCream].Included = sc;
            cb.Salsa = s;
            cb.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedCals, cb.Calories);
        }

        /// <summary>
        /// Tests that the price is correct based off the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="pb">If there are pinto beans</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(false, true, false, false, true, true, Salsa.Medium, 10.99)] // Required test
        [InlineData(true, true, true, true, true, true, Salsa.Medium, 10.99)]
        [InlineData(false, false, false, false, false, false, Salsa.Medium, 9.99)]
        [InlineData(true, false, true, false, true, false, Salsa.Medium, 10.99)]
        [InlineData(true, true, false, false, true, true, Salsa.Medium, 10.99)]
        [InlineData(false, true, false, true, false, true, Salsa.None, 9.99)]
        [InlineData(false, false, true, true, false, false, Salsa.Medium, 9.99)]
        [InlineData(true, true, true, false, false, false, Salsa.Medium, 9.99)]
        public void PriceTest(bool c, bool v, bool q, bool pb, bool g, bool sc, Salsa s, decimal expectedPrice)
        {
            CarnitasBowl cb = new();

            cb.Ingredients[Ingredient.Carnitas].Included = c;
            cb.Ingredients[Ingredient.Veggies].Included = v;
            cb.Ingredients[Ingredient.Queso].Included = q;
            cb.Ingredients[Ingredient.PintoBeans].Included = pb;
            cb.Ingredients[Ingredient.Guacamole].Included = g;
            cb.Ingredients[Ingredient.SourCream].Included = sc;
            cb.Salsa = s;
            cb.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.Equal(expectedPrice, cb.Price);
        }

        /// <summary>
        /// Tests that the preparation information is correct based off the given values
        /// </summary>
        /// <param name="c">If there is chicken</param>
        /// <param name="v">If there are veggies</param>
        /// <param name="q">If there is queso</param>
        /// <param name="pb">If there are pinto beans</param>
        /// <param name="g">If there is guacamole</param>
        /// <param name="sc">If there is sour cream</param>
        /// <param name="s">The type of salsa</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(false, true, false, false, true, true, Salsa.Medium, new string[]
            { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Add Guacamole", "Add Sour Cream", "Add Veggies" })] // Required test
        [InlineData(true, true, true, true, true, true, Salsa.Medium, new string[]
            { "Add Veggies", "Add Sour Cream", "Add Guacamole" })]
        [InlineData(false, false, false, false, false, false, Salsa.Medium, new string[]
            { "Hold Carnitas", "Hold Queso", "Hold Pinto Beans" })]
        [InlineData(true, false, true, false, true, false, Salsa.Medium, new string[]
            { "Hold Pinto Beans", "Add Guacamole" })]
        [InlineData(true, true, false, false, true, true, Salsa.Medium, new string[]
            { "Hold Pinto Beans", "Hold Queso", "Add Guacamole", "Add Sour Cream", "Add Veggies" })]
        [InlineData(false, true, false, true, false, true, Salsa.None, new string[]
            { "Hold Carnitas", "Add Veggies", "Hold Queso", "Add Sour Cream", "Hold Salsa" })]
        [InlineData(false, false, true, true, false, false, Salsa.Medium, new string[]
            { "Hold Carnitas" })]
        [InlineData(true, true, true, false, false, false, Salsa.Medium, new string[]
            { "Add Veggies", "Hold Pinto Beans" })]
        public void PrepInfoTest(bool c, bool v, bool q, bool pb, bool g, bool sc, Salsa s, string[] expectedPrepInfo)
        {
            CarnitasBowl cb = new();

            cb.Ingredients[Ingredient.Carnitas].Included = c;
            cb.Ingredients[Ingredient.Veggies].Included = v;
            cb.Ingredients[Ingredient.Queso].Included = q;
            cb.Ingredients[Ingredient.PintoBeans].Included = pb;
            cb.Ingredients[Ingredient.Guacamole].Included = g;
            cb.Ingredients[Ingredient.SourCream].Included = sc;
            cb.Salsa = s;
            cb.Ingredients[Ingredient.Salsa].Included = s == Salsa.None ? false : true;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, cb.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, cb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            CarnitasBowl cb = new();

            Assert.IsAssignableFrom<IMenuItem>(cb);
            Assert.IsAssignableFrom<Bowl>(cb);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CarnitasBowl cb = new();

            Assert.Equal("Carnitas Bowl", cb.ToString());
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
            CarnitasBowl item = new();
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
        [InlineData(Ingredient.Carnitas, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        [InlineData(Ingredient.Queso, false, "Price")]
        [InlineData(Ingredient.Carnitas, true, "Calories")]
        [InlineData(Ingredient.Guacamole, false, "Calories")]
        [InlineData(Ingredient.Queso, false, "Calories")]
        [InlineData(Ingredient.Carnitas, true, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.Queso, false, "PreparationInformation")]
        public void ChangingIncludedShouldNotifyPropertyChange(Ingredient i, bool included, string propertyName)
        {
            CarnitasBowl item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ingredients[i].Included = included;
            });
        }
    }
}