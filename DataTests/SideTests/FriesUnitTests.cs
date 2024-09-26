/* Author: Jess Barrett
* File; FriesUnitTests.cs
*/

using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Drinks;

namespace BuildYourBowl.DataTests.SideTests
{
    /// <summary>
    /// The definition of the FriesUnitTests class
    /// </summary>
    public class FriesUnitTests
    {
        /// <summary>
        /// Tests that the default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            Fries f = new();

            Assert.Equal(Size.Medium, f.Size);
            Assert.False(f.Curly);
            Assert.Equal(3.50m, f.Price);
            Assert.Equal(350u, f.Calories);
            Assert.All(new string[] { "Medium" }, prepInfo => Assert.Contains(prepInfo, f.PreparationInformation));
            Assert.Equal(new string[] { "Medium" }.Length, f.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the price is correct based on the given information
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="c">If the fries are curly</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(Size.Small, true, 3.00)]
        [InlineData(Size.Medium, true, 3.50)]
        [InlineData(Size.Large, false, 4.25)]
        [InlineData(Size.Kids, false, 2.50)]
        [InlineData(Size.Small, false, 3.00)]
        [InlineData(Size.Medium, false, 3.50)]
        [InlineData(Size.Large, true, 4.25)]
        [InlineData(Size.Kids, true, 2.50)]
        public void PriceTest(Size s, bool c, decimal expectedPrice)
        {
            Fries f = new();

            f.Size = s;
            f.Curly = c;

            Assert.Equal(expectedPrice, f.Price);
        }


        /// <summary>
        /// Tests that the calorie amount is correct based on the given information
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="c">If the fries are curly</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(Size.Small, true, 262)]
        [InlineData(Size.Medium, true, 350)]
        [InlineData(Size.Large, false, 525)]
        [InlineData(Size.Kids, false, 210)]
        [InlineData(Size.Small, false, 262)]
        [InlineData(Size.Medium, false, 350)]
        [InlineData(Size.Large, true, 525)]
        [InlineData(Size.Kids, true, 210)]
        public void CaloriesTest(Size s, bool c, uint expectedCals)
        {
            Fries f = new();

            f.Size = s;
            f.Curly = c;

            Assert.Equal(expectedCals, f.Calories);
        }


        /// <summary>
        /// Tests that the preparation information is correct based on the given information
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="c">If the fries are curly</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(Size.Small, true, new string[]
            { "Small", "Curly" })]
        [InlineData(Size.Medium, true, new string[]
            { "Medium", "Curly" })]
        [InlineData(Size.Large, false, new string[]
            { "Large" })]
        [InlineData(Size.Kids, false, new string[]
            { "Kids" })]
        [InlineData(Size.Small, false, new string[]
            { "Small" })]
        [InlineData(Size.Medium, false, new string[]
            { "Medium" })]
        [InlineData(Size.Large, true, new string[]
            { "Large", "Curly" })]
        [InlineData(Size.Kids, true, new string[]
            { "Kids", "Curly" })]
        public void PrepInfoTest(Size s, bool c, string[] expectedPrepInfo)
        {
            Fries f = new();

            f.Size = s;
            f.Curly = c;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, f.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, f.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            Fries f = new();

            Assert.IsAssignableFrom<IMenuItem>(f);
            Assert.IsAssignableFrom<Side>(f);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Fries f = new();

            Assert.Equal("Fries", f.ToString());
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
            Fries item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing curly notifies a property change
        /// </summary>
        /// <param name="curly">If the fries are curly</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "Curly")]
        [InlineData(false, "Curly")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCurlyShouldNotifyPropertyChange(bool curly, string propertyName)
        {
            Fries item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Curly = curly;
            });
        }
    }
}