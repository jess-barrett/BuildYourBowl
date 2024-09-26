/* Author: Jess Barrett
* File: MilkUnitTests.cs
*/

using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.DrinkTests
{
    /// <summary>
    /// The definition for the MilkUnitTests class
    /// </summary>
    public class MilkUnitTests
    {
        /// <summary>
        /// Tests if the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            Milk m = new();

            Assert.Equal(Size.Kids, m.Size);
            Assert.False(m.Chocolate);
            Assert.Equal(2.50m, m.Price);
            Assert.Equal(200u, m.Calories);
            Assert.All(new string[] { "Kids" }, prepInfo => Assert.Contains(prepInfo, m.PreparationInformation));
            Assert.Equal(new string[] { "Kids" }.Length, m.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given values
        /// </summary>
        /// <param name="c">If it is chocolate milk</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(true, 270)]
        [InlineData(false, 200)]
        public void CaloriesTest(bool c, uint expectedCals)
        {
            Milk m = new();

            m.Chocolate = c;

            Assert.Equal(expectedCals, m.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="c">If it is chocolate milk</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(true, new string[] { "Kids", "Chocolate" })]
        [InlineData(false, new string[] { "Kids" })]
        public void PrepInfoTest(bool c, string[] expectedPrepInfo)
        {
            Milk m = new();

            m.Chocolate = c;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, m.PreparationInformation));
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            Milk m = new();

            Assert.IsAssignableFrom<IMenuItem>(m);
            Assert.IsAssignableFrom<Drink>(m);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Milk m = new();

            Assert.Equal("Milk", m.ToString());
        }

        /// <summary>
        /// Tests that changing chocolate notifies a property change
        /// </summary>
        /// <param name="chocolate">If the milk is chocolate</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "Chocolate")]
        [InlineData(false, "Chocolate")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingChocolateShouldNotifyPropertyChange(bool chocolate, string propertyName)
        {
            Milk item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Chocolate = chocolate;
            });
        }
    }
}