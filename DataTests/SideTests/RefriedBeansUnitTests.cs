/* Author: Jess Barrett
* File: RefriedBeansUnitTests.cs
*/

using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using BuildYourBowl.Data.Drinks;

namespace BuildYourBowl.DataTests.SideTests
{
    /// <summary>
    /// The definition of the RefriedBeansUnitTests class
    /// </summary>
    public class RefriedBeansUnitTests
    {
        /// <summary>
        /// Tests that the default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            RefriedBeans rb = new();

            Assert.Equal(Size.Medium, rb.Size);
            Assert.True(rb.Onions);
            Assert.True(rb.CheddarCheese);
            Assert.Equal(3.75m, rb.Price);
            Assert.Equal(300u, rb.Calories);
            Assert.All(new string[] { "Medium" }, prepInfo => Assert.Contains(prepInfo, rb.PreparationInformation));
            Assert.Equal(new string[] { "Medium" }.Length, rb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the price is correct based on the given values
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="o">If there are onions</param>
        /// <param name="cc">If there is cheddar cheese</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(Size.Small, true, false, 3.25)]
        [InlineData(Size.Medium, true, false, 3.75)]
        [InlineData(Size.Large, true, false, 4.50)]
        [InlineData(Size.Kids, true, false, 2.75)]
        [InlineData(Size.Small, false, true, 3.25)]
        [InlineData(Size.Medium, false, false, 3.75)]
        [InlineData(Size.Large, false, true, 4.50)]
        [InlineData(Size.Kids, true, true, 2.75)]
        public void PriceTest(Size s, bool o, bool cc, decimal expectedPrice)
        {
            RefriedBeans rb = new();

            rb.Size = s;
            rb.Onions = o;
            rb.CheddarCheese = cc;

            Assert.Equal(expectedPrice, rb.Price);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given values
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="o">If there are onions</param>
        /// <param name="cc">If there is cheddar cheese</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(Size.Small, true, false, 157)]
        [InlineData(Size.Medium, true, false, 210)]
        [InlineData(Size.Large, true, false, 315)]
        [InlineData(Size.Kids, true, false, 126)]
        [InlineData(Size.Small, false, true, 221)]
        [InlineData(Size.Medium, false, false, 205)]
        [InlineData(Size.Large, false, true, 442)]
        [InlineData(Size.Kids, true, true, 180)]
        public void CaloriesTest(Size s, bool o, bool cc, uint expectedCals)
        {
            RefriedBeans rb = new();

            rb.Size = s;
            rb.Onions = o;
            rb.CheddarCheese = cc;

            Assert.Equal(expectedCals, rb.Calories);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given values
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="o">If there are onions</param>
        /// <param name="cc">If there is cheddar cheese</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(Size.Small, true, false, new string[]
            { "Small", "Hold Cheddar Cheese" })]
        [InlineData(Size.Medium, true, false, new string[]
            { "Medium", "Hold Cheddar Cheese" })]
        [InlineData(Size.Large, true, false, new string[]
            { "Large", "Hold Cheddar Cheese" })]
        [InlineData(Size.Kids, true, false, new string[]
            { "Kids", "Hold Cheddar Cheese" })]
        [InlineData(Size.Small, false, true, new string[]
            { "Small", "Hold Onions" })]
        [InlineData(Size.Medium, false, false, new string[]
            { "Medium", "Hold Onions", "Hold Cheddar Cheese" })]
        [InlineData(Size.Large, false, true, new string[]
            { "Large", "Hold Onions" })]
        [InlineData(Size.Kids, true, true, new string[]
            { "Kids" })]
        public void PrepInfoTest(Size s, bool o, bool cc, string[] expectedPrepInfo)
        {
            RefriedBeans rb = new();

            rb.Size = s;
            rb.Onions = o;
            rb.CheddarCheese = cc;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, rb.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, rb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            RefriedBeans rb = new();

            Assert.IsAssignableFrom<IMenuItem>(rb);
            Assert.IsAssignableFrom<Side>(rb);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            RefriedBeans rb = new();

            Assert.Equal("Refried Beans", rb.ToString());
        }

        /// <summary>
        /// Tests that changing the size notifies a property change
        /// </summary>
        /// <param name="size">The size to change to</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Medium, "PreparationInformation")]
        [InlineData(Size.Large, "PreparationInformation")]
        public void ChangingSizeShouldNotifyOfPropertyChange(Size size, string propertyName)
        {
            RefriedBeans item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing onions notifies a property change
        /// </summary>
        /// <param name="onions">If there are onions or not</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "Onions")]
        [InlineData(false, "Onions")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingOnionsShouldNotifyPropertyChange(bool onions, string propertyName)
        {
            RefriedBeans item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Onions = onions;
            });
        }

        /// <summary>
        /// Tests that changing cheddar cheese notifies a property change
        /// </summary>
        /// <param name="onions">If there is cheddar cheese or not</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "CheddarCheese")]
        [InlineData(false, "CheddarCheese")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCheddarCheeseShouldNotifyPropertyChange(bool cheddarCheese, string propertyName)
        {
            RefriedBeans item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.CheddarCheese = cheddarCheese;
            });
        }
    }
}