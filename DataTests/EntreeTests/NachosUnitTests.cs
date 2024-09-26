/* Author: Jess Barrett
* File: NachosUnitTests.cs
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
    /// The definition of the NachosUnitTests class
    /// </summary>
    public class NachosUnitTests
    {
        /// <summary>
        /// Tests that the default values are correct when a new Bowl is created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            Nachos s = new();

            Assert.Equal(7.99m, s.Price);
            Assert.Equal(270u, s.Calories);
            Assert.Equal(Salsa.Medium, s.Salsa);
            Assert.Equal(11, s.Ingredients.Count());
            Assert.Equal(new string[] { }.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the price is correct based on the given values
        /// </summary>
        /// <param name="ingredients">The ingredients to add</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(new Ingredient[] { Ingredient.Chicken }, 9.99)]
        [InlineData(new Ingredient[] { Ingredient.Steak }, 9.99)]
        [InlineData(new Ingredient[] { Ingredient.Carnitas }, 9.99)]
        [InlineData(new Ingredient[] { Ingredient.BlackBeans }, 8.99)]
        [InlineData(new Ingredient[] { Ingredient.PintoBeans }, 8.99)]
        [InlineData(new Ingredient[] { Ingredient.Queso }, 8.99)]
        [InlineData(new Ingredient[] { Ingredient.Guacamole }, 8.99)]
        [InlineData(new Ingredient[] { Ingredient.Steak, Ingredient.Queso }, 10.99)]
        public void PriceTest(Ingredient[] ingredients, decimal expectedPrice)
        {
            Nachos s = new();

            foreach (Ingredient i in ingredients)
            {
                s.Ingredients[i].Included = true;
            }

            Assert.Equal(expectedPrice, s.Price);
        }

        /// <summary>
        /// Tests that the amount of calories is correct for the given values
        /// </summary>
        /// <param name="ingredients">The list of ingredients to add</param>
        /// <param name="expectedCals">The expected amount of calories</param>
        [Theory]
        [InlineData(new Ingredient[] { Ingredient.Chicken }, 420)]
        [InlineData(new Ingredient[] { Ingredient.Steak }, 450)]
        [InlineData(new Ingredient[] { Ingredient.Carnitas }, 480)]
        [InlineData(new Ingredient[] { Ingredient.BlackBeans }, 400)]
        [InlineData(new Ingredient[] { Ingredient.PintoBeans }, 400)]
        [InlineData(new Ingredient[] { Ingredient.Queso }, 380)]
        [InlineData(new Ingredient[] { Ingredient.Guacamole }, 420)]
        [InlineData(new Ingredient[] { Ingredient.Steak, Ingredient.Queso }, 560)]
        public void CaloriesTest(Ingredient[] ingredients, uint expectedCals)
        {
            Nachos s = new();

            foreach (Ingredient i in ingredients)
            {
                s.Ingredients[i].Included = true;
            }

            Assert.Equal(expectedCals, s.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="ingredients">The ingredients to add</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(new Ingredient[] { Ingredient.Chicken }, new string[] { "Add Chicken" })]
        [InlineData(new Ingredient[] { Ingredient.Steak }, new string[] { "Add Steak" })]
        [InlineData(new Ingredient[] { Ingredient.Carnitas }, new string[] { "Add Carnitas" })]
        [InlineData(new Ingredient[] { Ingredient.BlackBeans }, new string[] { "Add Black Beans" })]
        [InlineData(new Ingredient[] { Ingredient.PintoBeans }, new string[] { "Add Pinto Beans" })]
        [InlineData(new Ingredient[] { Ingredient.Queso }, new string[] { "Add Queso" })]
        [InlineData(new Ingredient[] { Ingredient.Guacamole }, new string[] { "Add Guacamole" })]
        [InlineData(new Ingredient[] { Ingredient.Steak, Ingredient.Queso }, new string[] { "Add Steak", "Add Queso" })]
        public void PrepInfoTest(Ingredient[] ingredients, string[] expectedPrepInfo)
        {
            Nachos s = new();

            foreach (Ingredient i in ingredients)
            {
                s.Ingredients[i].Included = true;
            }

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, s.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that ingredients are added correctly
        /// </summary>
        /// <param name="ingredients">The ingredients to add</param>
        [Theory]
        [InlineData(new Ingredient[] { Ingredient.Chicken })]
        [InlineData(new Ingredient[] { Ingredient.Steak })]
        [InlineData(new Ingredient[] { Ingredient.Carnitas })]
        [InlineData(new Ingredient[] { Ingredient.BlackBeans })]
        [InlineData(new Ingredient[] { Ingredient.PintoBeans })]
        [InlineData(new Ingredient[] { Ingredient.Queso })]
        [InlineData(new Ingredient[] { Ingredient.Guacamole })]
        [InlineData(new Ingredient[] { Ingredient.Steak, Ingredient.Queso })]
        public void IngredientsTest(Ingredient[] ingredients)
        {
            Nachos s = new();

            foreach (Ingredient i in ingredients)
            {
                s.Ingredients[i].Included = true;
            }

            Assert.All(ingredients, item => Assert.True(s.Ingredients[item].Included = true));
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            Nachos s = new();

            Assert.IsAssignableFrom<IMenuItem>(s);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Nachos n = new();

            Assert.Equal("Build-Your-Own Nachos", n.ToString());
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
            Nachos item = new();
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
        [InlineData(Ingredient.BlackBeans, true, "Price")]
        [InlineData(Ingredient.Guacamole, false, "Price")]
        [InlineData(Ingredient.Queso, false, "Price")]
        [InlineData(Ingredient.PintoBeans, true, "Calories")]
        [InlineData(Ingredient.Guacamole, false, "Calories")]
        [InlineData(Ingredient.Queso, false, "Calories")]
        [InlineData(Ingredient.PintoBeans, true, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.Queso, false, "PreparationInformation")]
        public void ChangingIncludedShouldNotifyPropertyChange(Ingredient i, bool included, string propertyName)
        {
            Nachos item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ingredients[i].Included = included;
            });
        }
    }
}