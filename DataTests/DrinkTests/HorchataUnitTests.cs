/* Author: Jess Barrett
* File: HorchataUnitTests.cs
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
    /// The definition for the HorchataUnitTests class
    /// </summary>
    public class HorchataUnitTests
    {
        /// <summary>
        /// Tests if the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            Horchata h = new();

            Assert.Equal(Size.Medium, h.Size);
            Assert.True(h.Ice);
            Assert.Equal(3.50m, h.Price);
            Assert.Equal(380u, h.Calories);
            Assert.All(new string[] { "Medium" }, prepInfo => Assert.Contains(prepInfo, h.PreparationInformation));
            Assert.Equal(new string[] { "Medium" }.Length, h.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the price is correct based on the given values
        /// </summary>
        /// <param name="s">The drink size</param>
        /// <param name="i">If there is ice</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(Size.Medium, true, 3.50)]
        [InlineData(Size.Small, false, 3.00)]
        [InlineData(Size.Kids, true, 2.50)]
        [InlineData(Size.Large, false, 4.25)]
        [InlineData(Size.Medium, false, 3.50)]
        [InlineData(Size.Small, true, 3.00)]
        [InlineData(Size.Kids, false, 2.50)]
        [InlineData(Size.Large, true, 4.25)]
        public void PriceTest(Size s, bool i, decimal expectedPrice)
        {
            Horchata h = new();

            h.Size = s;
            h.Ice = i;

            Assert.Equal(expectedPrice, h.Price);
        }

        /// <summary>
        /// Tests that the price is correct based on the given values
        /// </summary>
        /// <param name="s">The drink size</param>
        /// <param name="i">If there is ice</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(Size.Medium, true, 380)]
        [InlineData(Size.Small, false, 307)]
        [InlineData(Size.Kids, true, 228)]
        [InlineData(Size.Large, false, 615)]
        [InlineData(Size.Medium, false, 410)]
        [InlineData(Size.Small, true, 285)]
        [InlineData(Size.Kids, false, 246)]
        [InlineData(Size.Large, true, 570)]
        public void CaloriesTest(Size s, bool i, uint expectedCals)
        {
            Horchata h = new();

            h.Size = s;
            h.Ice = i;

            Assert.Equal(expectedCals, h.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="s">The drink size</param>
        /// <param name="i">If there is ice</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(Size.Medium, true, new string[] { "Medium" })]
        [InlineData(Size.Small, false, new string[] { "Small", "Hold Ice" })]
        [InlineData(Size.Kids, true, new string[] { "Kids" })]
        [InlineData(Size.Large, false, new string[] { "Large", "Hold Ice" })]
        [InlineData(Size.Medium, false, new string[] { "Medium", "Hold Ice" })]
        [InlineData(Size.Small, true, new string[] { "Small" })]
        [InlineData(Size.Kids, false, new string[] { "Kids", "Hold Ice" })]
        [InlineData(Size.Large, true, new string[] { "Large" })]
        public void PrepInfoTest(Size s, bool i, string[] expectedPrepInfo)
        {
            Horchata h = new();

            h.Size = s;
            h.Ice = i;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, h.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, h.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            Horchata h = new();

            Assert.IsAssignableFrom<IMenuItem>(h);
            Assert.IsAssignableFrom<Drink>(h);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Horchata h = new();

            Assert.Equal("Horchata", h.ToString());
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
            Horchata item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing ice notifies a property change
        /// </summary>
        /// <param name="ice">If there is ice or not</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "Ice")]
        [InlineData(false, "Ice")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingIceShouldNotifyPropertyChange(bool ice, string propertyName)
        {
            Horchata item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ice = ice;
            });
        }
    }
}