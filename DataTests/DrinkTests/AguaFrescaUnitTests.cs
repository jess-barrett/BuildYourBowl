/* Author: Jess Barrett
* File: AguaFrescaUnitTests.cs
*/

using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests.DrinkTests
{
    /// <summary>
    /// The definition for the AguaFrescaUnitTests class
    /// </summary>
    public class AguaFrescaUnitTests
    {
        /// <summary>
        /// Tests if the dafault values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            AguaFresca af = new();

            Assert.Equal(Flavor.Limonada, af.Flavor);
            Assert.Equal(Size.Medium, af.Size);
            Assert.True(af.Ice);
            Assert.Equal(3, af.Price);
            Assert.Equal(125u, af.Calories);
            Assert.All(new string[] { "Medium", "Limonada" }, prepInfo => Assert.Contains(prepInfo, af.PreparationInformation));
            Assert.Equal(new string[] { "Medium", "Limonada" }.Length, af.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the price is correct based off the given values
        /// </summary>
        /// <param name="df">The drink flavor</param>
        /// <param name="ds">The drink size</param>
        /// <param name="i">If there is ice</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(Flavor.Tamarind, Size.Large, false, 4.25)] // Required test
        [InlineData(Flavor.Limonada, Size.Small, true, 2.50)]
        [InlineData(Flavor.Strawberry, Size.Medium, true, 3.00)]
        [InlineData(Flavor.Lime, Size.Kids, true, 2.00)]
        [InlineData(Flavor.Cucumber, Size.Large, false, 3.75)]
        [InlineData(Flavor.Limonada, Size.Medium, true, 3.00)]
        [InlineData(Flavor.Strawberry, Size.Small, true, 2.50)]
        [InlineData(Flavor.Tamarind, Size.Medium, true, 3.50)]
        public void PriceTest(Flavor df, Size ds, bool i, decimal expectedPrice)
        {
            AguaFresca af = new();

            af.Flavor = df;
            af.Size = ds;
            af.Ice = i;

            Assert.Equal(expectedPrice, af.Price);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based off the given values
        /// </summary>
        /// <param name="df">The drink flavor</param>
        /// <param name="ds">The drink size</param>
        /// <param name="i">If there is ice</param>
        /// <param name="expectedPrice">The expected calorie amount</param>
        [Theory]
        [InlineData(Flavor.Tamarind, Size.Large, false, 240)] // Required test
        [InlineData(Flavor.Limonada, Size.Small, true, 93)]
        [InlineData(Flavor.Strawberry, Size.Medium, true, 150)]
        [InlineData(Flavor.Lime, Size.Kids, true, 75)]
        [InlineData(Flavor.Cucumber, Size.Large, false, 127)]
        [InlineData(Flavor.Limonada, Size.Medium, true, 125)]
        [InlineData(Flavor.Strawberry, Size.Small, true, 112)]
        [InlineData(Flavor.Tamarind, Size.Medium, true, 150)]
        public void CaloriesTest(Flavor df, Size ds, bool i, uint expectedCals)
        {
            AguaFresca af = new();

            af.Flavor = df;
            af.Size = ds;
            af.Ice = i;

            Assert.Equal(expectedCals, af.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based off the given values
        /// </summary>
        /// <param name="df">The drink flavor</param>
        /// <param name="ds">The drink size</param>
        /// <param name="i">If there is ice</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(Flavor.Tamarind, Size.Large, false, new string[]
            { "Large", "Tamarind", "Hold Ice" })] // Required test
        [InlineData(Flavor.Limonada, Size.Small, true, new string[]
            { "Small", "Limonada" })]
        [InlineData(Flavor.Strawberry, Size.Medium, true, new string[]
            { "Medium", "Strawberry" })]
        [InlineData(Flavor.Lime, Size.Kids, true, new string[]
            { "Kids", "Lime" })]
        [InlineData(Flavor.Cucumber, Size.Large, false, new string[]
            { "Large", "Cucumber", "Hold Ice" })]
        [InlineData(Flavor.Limonada, Size.Medium, true, new string[]
            { "Medium", "Limonada" })]
        [InlineData(Flavor.Strawberry, Size.Small, true, new string[]
            { "Small", "Strawberry" })]
        [InlineData(Flavor.Tamarind, Size.Medium, true, new string[]
            { "Medium", "Tamarind" })]
        public void PrepInfoTest(Flavor df, Size ds, bool i, string[] expectedPrepInfo)
        {
            AguaFresca af = new();

            af.Flavor = df;
            af.Size = ds;
            af.Ice = i;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, af.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, af.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            AguaFresca af = new();

            Assert.IsAssignableFrom<IMenuItem>(af);
            Assert.IsAssignableFrom<Drink>(af);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            AguaFresca af = new();

            Assert.Equal("Agua Fresca", af.ToString());
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
            AguaFresca item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing the flavor notifies a property change
        /// </summary>
        /// <param name="flavor">The flavor to change to</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(Flavor.Cucumber, "Flavor")]
        [InlineData(Flavor.Lime, "Flavor")]
        [InlineData(Flavor.Limonada, "Flavor")]
        [InlineData(Flavor.Strawberry, "Flavor")]
        [InlineData(Flavor.Tamarind, "Flavor")]
        [InlineData(Flavor.Cucumber, "Price")]
        [InlineData(Flavor.Lime, "Price")]
        [InlineData(Flavor.Limonada, "Price")]
        [InlineData(Flavor.Strawberry, "Price")]
        [InlineData(Flavor.Tamarind, "Price")]
        [InlineData(Flavor.Cucumber, "Calories")]
        [InlineData(Flavor.Lime, "Calories")]
        [InlineData(Flavor.Limonada, "Calories")]
        [InlineData(Flavor.Strawberry, "Calories")]
        [InlineData(Flavor.Tamarind, "Calories")]
        [InlineData(Flavor.Cucumber, "PreparationInformation")]
        [InlineData(Flavor.Lime, "PreparationInformation")]
        [InlineData(Flavor.Limonada, "PreparationInformation")]
        [InlineData(Flavor.Strawberry, "PreparationInformation")]
        [InlineData(Flavor.Tamarind, "PreparationInformation")]
        public void ChangingFlavorShouldNotifyPropertyChange(Flavor flavor, string propertyName)
        {
            AguaFresca item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Flavor = flavor;
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
            AguaFresca item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Ice = ice;
            });
        }
    }
}