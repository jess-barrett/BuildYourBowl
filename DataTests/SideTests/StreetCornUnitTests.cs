/* Author: Jess Barrett
* File: StreetCornUnitTests.cs
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
    /// The definition of the StreetCornUnitTests class
    /// </summary>
    public class StreetCornUnitTests
    {
        /// <summary>
        /// Tests that the default values are correct
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            StreetCorn sc = new();

            Assert.Equal(Size.Medium, sc.Size);
            Assert.True(sc.CotijaCheese);
            Assert.True(sc.Cilantro);
            Assert.Equal(4.50m, sc.Price);
            Assert.Equal(300u, sc.Calories);
            Assert.All(new string[] { "Medium" }, prepInfo => Assert.Contains(prepInfo, sc.PreparationInformation));
            Assert.Equal(new string[] { "Medium" }.Length, sc.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the price is correct based on the given information
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="cc">If there is cotija cheese</param>
        /// <param name="c">If there is cilantro</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(Size.Small, true, false, 3.75)] // Required test
        [InlineData(Size.Medium, true, false, 4.50)]
        [InlineData(Size.Large, true, false, 5.50)]
        [InlineData(Size.Kids, true, false, 3.25)]
        [InlineData(Size.Small, false, true, 3.75)]
        [InlineData(Size.Medium, false, false, 4.50)]
        [InlineData(Size.Large, false, true, 5.50)]
        [InlineData(Size.Kids, true, true, 3.25)]
        public void PriceTest(Size s, bool cc, bool c, decimal expectedPrice)
        {
            StreetCorn sc = new();

            sc.Size = s;
            sc.CotijaCheese = cc;
            sc.Cilantro = c;

            Assert.Equal(expectedPrice, sc.Price);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given information
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="cc">If there is cotija cheese</param>
        /// <param name="c">If there is cilantro</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(Size.Small, true, false, 221)] // Required test
        [InlineData(Size.Medium, true, false, 295)]
        [InlineData(Size.Large, true, false, 442)]
        [InlineData(Size.Kids, true, false, 177)]
        [InlineData(Size.Small, false, true, 165)]
        [InlineData(Size.Medium, false, false, 215)]
        [InlineData(Size.Large, false, true, 330)]
        [InlineData(Size.Kids, true, true, 180)]
        public void CalorieTest(Size s, bool cc, bool c, uint expectedCals)
        {
            StreetCorn sc = new();

            sc.Size = s;
            sc.CotijaCheese = cc;
            sc.Cilantro = c;

            Assert.Equal(expectedCals, sc.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="s">The size of the side</param>
        /// <param name="cc">If there is cotija cheese</param>
        /// <param name="c">If there is cilantro</param>
        /// <param name="expectedCals">The expected preparation information</param>
        [Theory]
        [InlineData(Size.Small, true, false, new string[]
            { "Small", "Hold Cilantro" })] // Required test
        [InlineData(Size.Medium, true, false, new string[]
            { "Medium", "Hold Cilantro" })]
        [InlineData(Size.Large, true, false, new string[]
            { "Large", "Hold Cilantro" })]
        [InlineData(Size.Kids, true, false, new string[]
            { "Kids", "Hold Cilantro" })]
        [InlineData(Size.Small, false, true, new string[]
            { "Small", "Hold Cotija Cheese" })]
        [InlineData(Size.Medium, false, false, new string[]
            { "Medium", "Hold Cotija Cheese", "Hold Cilantro" })]
        [InlineData(Size.Large, false, true, new string[]
            { "Large", "Hold Cotija Cheese" })]
        [InlineData(Size.Kids, true, true, new string[]
            { "Kids" })]
        public void PrepInfoTest(Size s, bool cc, bool c, string[] expectedPrepInfo)
        {
            StreetCorn sc = new();

            sc.Size = s;
            sc.CotijaCheese = cc;
            sc.Cilantro = c;

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, sc.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, sc.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            StreetCorn sc = new();

            Assert.IsAssignableFrom<IMenuItem>(sc);
            Assert.IsAssignableFrom<Side>(sc);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            StreetCorn sc = new();

            Assert.Equal("Street Corn", sc.ToString());
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
            StreetCorn item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing cotija cheese notifies a property change
        /// </summary>
        /// <param name="cotijaCheese">If there is cotija cheese or not</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "CotijaCheese")]
        [InlineData(false, "CotijaCheese")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCotijaCheeseShouldNotifyPropertyChange(bool cotijaCheese, string propertyName)
        {
            StreetCorn item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.CotijaCheese = cotijaCheese;
            });
        }

        /// <summary>
        /// Tests that changing cilantro notifies a property change
        /// </summary>
        /// <param name="cilantro">If there is cilantro or not</param>
        /// <param name="propertyName">The property that is being notified is changing</param>
        [Theory]
        [InlineData(true, "Cilantro")]
        [InlineData(false, "Cilantro")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCilantroShouldNotifyPropertyChange(bool cilantro, string propertyName)
        {
            StreetCorn item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Cilantro = cilantro;
            });
        }
    }
}