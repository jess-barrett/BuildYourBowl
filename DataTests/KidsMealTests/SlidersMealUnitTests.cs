/* Author: Jess Barrett
* File: SlidersMealUnitTests.cs
*/

using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.DataTests.MockClasses;

namespace BuildYourBowl.DataTests.KidsMealTests
{
    /// <summary>
    /// The definition of the SlidersMealUnitTests class
    /// </summary>
    public class SlidersMealUnitTests
    {
        /// <summary>
        /// Tests if the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            SlidersMeal sm = new();

            Assert.Equal(2u, sm.Count);
            Assert.True(sm.DrinkChoice is Milk);
            Assert.Equal(Size.Kids, sm.DrinkChoice.Size);
            Assert.True(sm.SideChoice is Fries);
            Assert.Equal(Size.Kids, sm.SideChoice.Size);
            Assert.DoesNotContain("Curly", sm.SideChoice.PreparationInformation);
            Assert.True(sm.AmericanCheese);
            Assert.Equal(5.99m, sm.Price);
            Assert.Equal(710u, sm.Calories);
            Assert.All(new string[] { "Sliders: 2", "Drink Choice: Milk", "\tKids", "Side Choice: Fries", "\tKids" }, prepInfo => Assert.Contains(prepInfo, sm.PreparationInformation));
            Assert.Equal(new string[] { "Sliders: 2", "Drink Choice: Milk", "\tKids", "Side Choice: Fries", "\tKids" }.Length, sm.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the count stays within its constraints
        /// </summary>
        /// <param name="c">The count to change to</param>
        /// <param name="expectedCount">The expected count after the attempted change</param>
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 2)]
        [InlineData(5, 2)]
        [InlineData(50, 2)]
        public void ConstraintTest(uint c, uint expectedCount)
        {
            SlidersMeal sm = new();

            sm.Count = c;

            Assert.Equal(expectedCount, sm.Count);
        }

        /// <summary>
        /// Tests that the price is correct based on the given information
        /// </summary>
        /// <param name="c">The number of sliders in the meal<param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(3, false, Size.Kids, Size.Large, 9.49)] // Required test
        [InlineData(2, false, Size.Small, Size.Small, 6.99)]
        [InlineData(2, true, Size.Medium, Size.Medium, 7.99)]
        [InlineData(2, false, Size.Large, Size.Large, 8.99)]
        [InlineData(3, true, Size.Large, Size.Kids, 9.49)]
        [InlineData(4, false, Size.Medium, Size.Small, 11.49)]
        [InlineData(3, true, Size.Small, Size.Medium, 9.49)]
        [InlineData(4, false, Size.Kids, Size.Large, 11.49)]
        public void PriceTest(uint c, bool cheese, Size ds, Size ss, decimal expectedPrice)
        {
            SlidersMeal sm = new();

            sm.Count = c;
            sm.AmericanCheese = cheese;
            sm.DrinkChoice = new MockDrink() { Size = ds };
            sm.SideChoice = new MockSide() { Size = ss };

            Assert.Equal(expectedPrice, sm.Price);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given values
        /// </summary>
        /// <param name="c">The number of sliders in the meal</param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(3, false, Size.Kids, Size.Large, 540)] // Required test
        [InlineData(2, false, Size.Small, Size.Small, 370)]
        [InlineData(2, true, Size.Medium, Size.Medium, 500)]
        [InlineData(2, false, Size.Large, Size.Large, 520)]
        [InlineData(3, true, Size.Large, Size.Kids, 660)]
        [InlineData(4, false, Size.Medium, Size.Small, 615)]
        [InlineData(3, true, Size.Small, Size.Medium, 625)]
        [InlineData(4, false, Size.Kids, Size.Large, 650)]
        public void CaloriesTest(uint c, bool cheese, Size ds, Size ss, uint expectedCals)
        {
            SlidersMeal sm = new();

            sm.Count = c;
            sm.AmericanCheese = cheese;
            sm.DrinkChoice = new MockDrink() { Size = ds };
            sm.SideChoice = new MockSide() { Size = ss };

            Assert.Equal(expectedCals, sm.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="c">The number of sliders in the meal</param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(3, false, Size.Kids, Size.Large, new string[]
            { "Sliders: 3", "Drink Choice: Mock Drink", "\tKids", "Side Choice: Mock Side", "\tLarge", "Hold American Cheese" })] // Required test
        [InlineData(2, true, Size.Small, Size.Small, new string[]
            { "Sliders: 2", "Drink Choice: Mock Drink", "\tSmall", "Side Choice: Mock Side", "\tSmall" })]
        [InlineData(2, true, Size.Medium, Size.Medium, new string[]
            { "Sliders: 2", "Drink Choice: Mock Drink", "\tMedium", "Side Choice: Mock Side", "\tMedium" })]
        [InlineData(2, true, Size.Large, Size.Large, new string[]
            { "Sliders: 2", "Drink Choice: Mock Drink", "\tLarge", "Side Choice: Mock Side", "\tLarge" })]
        [InlineData(3, false, Size.Large, Size.Kids, new string[]
            { "Sliders: 3", "Drink Choice: Mock Drink", "\tLarge", "Side Choice: Mock Side", "\tKids", "Hold American Cheese" })]
        [InlineData(4, false, Size.Medium, Size.Small, new string[]
            { "Sliders: 4", "Drink Choice: Mock Drink", "\tMedium", "Side Choice: Mock Side", "\tSmall", "Hold American Cheese" })]
        [InlineData(3, false, Size.Small, Size.Medium, new string[]
            { "Sliders: 3", "Drink Choice: Mock Drink", "\tSmall", "Side Choice: Mock Side", "\tMedium", "Hold American Cheese" })]
        [InlineData(4, false, Size.Kids, Size.Large, new string[]
            { "Sliders: 4", "Drink Choice: Mock Drink", "\tKids", "Side Choice: Mock Side", "\tLarge", "Hold American Cheese" })]
        public void PrepInfoTest(uint c, bool cheese, Size ds, Size ss, string[] expectedPrepInfo)
        {
            SlidersMeal sm = new();

            sm.Count = c;
            sm.AmericanCheese = cheese;
            sm.DrinkChoice = new MockDrink() { Size = ds };
            sm.SideChoice = new MockSide() { Size = ss };

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, sm.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, sm.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            SlidersMeal sm = new();

            Assert.IsAssignableFrom<IMenuItem>(sm);
            Assert.IsAssignableFrom<KidsMeal>(sm);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            SlidersMeal sm = new();

            Assert.Equal("Sliders Kids Meal", sm.ToString());
        }

        /// <summary>
        /// Tests that changing the count notifies a property change
        /// </summary>
        /// <param name="count">The count to change to</param>
        /// <param name="propertyName">The property that is changing</param>
        [Theory]
        [InlineData(2, "Count")]
        [InlineData(2, "Calories")]
        [InlineData(2, "Price")]
        [InlineData(2, "PreparationInformation")]
        [InlineData(3, "Count")]
        [InlineData(4, "Calories")]
        [InlineData(3, "Price")]
        [InlineData(4, "PreparationInformation")]
        public void ChangingCountShouldNotifyPropertyChange(uint count, string propertyName)
        {
            SlidersMeal item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.Count = count;
            });
        }

        /// <summary>
        /// Tests that changing the side notifies a property change
        /// </summary>
        /// <param name="propertyName">The property that is changing</param>
        [Theory]
        [InlineData("SideChoice")]
        [InlineData("Calories")]
        [InlineData("Price")]
        [InlineData("PreparationInformation")]
        public void ChangingSideChoiceShouldNotifyPropertyChange(string propertyName)
        {
            SlidersMeal item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.SideChoice = new MockSide();
            });
        }

        /// <summary>
        /// Tests that changing the drink notifies a property change
        /// </summary>
        /// <param name="propertyName">The property that is changing</param>
        [Theory]
        [InlineData("DrinkChoice")]
        [InlineData("Calories")]
        [InlineData("Price")]
        [InlineData("PreparationInformation")]
        public void ChangingDrinkChoiceShouldNotifyPropertyChange(string propertyName)
        {
            SlidersMeal item = new();
            Assert.PropertyChanged(item, propertyName, () => {
                item.DrinkChoice = new MockDrink();
            });
        }

        /// <summary>
        /// Tests that changing the side's size notifies a property change
        /// </summary>
        /// <param name="propertyName">The property that is changing</param>
        [Theory]
        [InlineData(Size.Kids, "SideChoice")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "PreparationInformation")]
        [InlineData(Size.Large, "SideChoice")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Kids, "PreparationInformation")]
        public void ChangingSideChoiceSizeShouldNotifyPropertyChange(Size size, string propertyName)
        {
            SlidersMeal item = new();
            item.SideChoice = new MockSide();
            Assert.PropertyChanged(item, propertyName, () => {
                item.SideChoice.Size = size;
            });
        }

        /// <summary>
        /// Tests that changing the side notifies a property change
        /// </summary>
        /// <param name="propertyName">The property that is changing</param>
        [Theory]
        [InlineData(Size.Kids, "DrinkChoice")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "PreparationInformation")]
        [InlineData(Size.Large, "DrinkChoice")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Kids, "PreparationInformation")]
        public void ChangingDrinkChoiceSizeShouldNotifyPropertyChange(Size size, string propertyName)
        {
            SlidersMeal item = new();
            item.DrinkChoice = new MockDrink();
            Assert.PropertyChanged(item, propertyName, () => {
                item.DrinkChoice.Size = size;
            });
        }
    }
}