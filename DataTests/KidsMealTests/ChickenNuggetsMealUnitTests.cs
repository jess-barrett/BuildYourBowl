/* Author: Jess Barrett
* File: ChickenNuggetsMealUnitTests.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Sides;
using NuGet.Frameworks;
using BuildYourBowl.DataTests.MockClasses;
using BuildYourBowl.Data.Entrees;

namespace BuildYourBowl.DataTests.KidsMealTests
{
    /// <summary>
    /// The definition for the ChickenNuggetsMealUnitTests class
    /// </summary>
    public class ChickenNuggetsMealUnitTests
    {
        /// <summary>
        /// Tests if the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            ChickenNuggetsMeal cnm = new();

            Assert.Equal(5u, cnm.Count);
            Assert.True(cnm.DrinkChoice is Milk);
            Assert.Equal(Size.Kids, cnm.DrinkChoice.Size);
            Assert.True(cnm.SideChoice is Fries);
            Assert.Equal(Size.Kids, cnm.SideChoice.Size);
            Assert.DoesNotContain("Curly", cnm.SideChoice.PreparationInformation);
            Assert.Equal(5.99m, cnm.Price);
            Assert.Equal(710u, cnm.Calories);
            Assert.All(new string[] { "Nuggets: 5", "Drink Choice: Milk", "\tKids", "Side Choice: Fries", "\tKids" }, prepInfo => Assert.Contains(prepInfo, cnm.PreparationInformation));
            Assert.Equal(new string[] { "Nuggets: 5", "Drink Choice: Milk", "\tKids", "Side Choice: Fries", "\tKids" }.Length, cnm.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that the count stays within its constraints
        /// </summary>
        /// <param name="c">The count to change to</param>
        /// <param name="expectedCount">The expected count after the attempted change</param>
        [Theory]
        [InlineData(4, 5)]
        [InlineData(0, 5)]
        [InlineData(9, 5)]
        [InlineData(50, 5)]
        public void ConstraintTest(uint c, uint expectedCount)
        {
            ChickenNuggetsMeal cnm = new();

            cnm.Count = c;

            Assert.Equal(expectedCount, cnm.Count);
        }

        /// <summary>
        /// Tests that the price is correct based on the given information
        /// </summary>
        /// <param name="c">The number of nuggets in the meal<param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, 5.99)]
        [InlineData(5, Size.Small, Size.Small, 6.99)]
        [InlineData(5, Size.Small, Size.Medium, 7.49)]
        [InlineData(5, Size.Medium, Size.Large, 8.49)]
        [InlineData(6, Size.Large, Size.Kids, 8.24)]
        [InlineData(7, Size.Medium, Size.Small, 8.99)]
        [InlineData(8, Size.Kids, Size.Medium, 9.24)]
        [InlineData(8, Size.Large, Size.Large, 11.24)]
        public void PriceTest(uint c, Size ds, Size ss, decimal expectedPrice)
        {
            ChickenNuggetsMeal cnm = new ChickenNuggetsMeal();

            cnm.Count = c;
            cnm.DrinkChoice = new MockDrink() { Size = ds };
            cnm.SideChoice = new MockSide() { Size = ss };

            Assert.Equal(expectedPrice, cnm.Price);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given values
        /// </summary>
        /// <param name="c">The number of nuggets in the meal</param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, 420)]
        [InlineData(5, Size.Small, Size.Small, 450)]
        [InlineData(5, Size.Small, Size.Medium, 475)]
        [InlineData(5, Size.Medium, Size.Large, 550)]
        [InlineData(6, Size.Large, Size.Kids, 570)]
        [InlineData(7, Size.Medium, Size.Small, 595)]
        [InlineData(8, Size.Kids, Size.Medium, 640)]
        [InlineData(8, Size.Large, Size.Large, 780)]
        public void CaloriesTest(uint c, Size ds, Size ss, uint expectedCals)
        {
            ChickenNuggetsMeal cnm = new();

            cnm.Count = c;
            cnm.DrinkChoice = new MockDrink() { Size = ds };
            cnm.SideChoice = new MockSide() { Size = ss };

            Assert.Equal(expectedCals, cnm.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="c">The number of nuggets in the meal</param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, new string[] { "Nuggets: 5", "Drink Choice: Mock Drink", "\tKids", "Side Choice: Mock Side", "\tKids" })]
        [InlineData(5, Size.Small, Size.Small, new string[] { "Nuggets: 5", "Drink Choice: Mock Drink", "\tSmall", "Side Choice: Mock Side", "\tSmall" })]
        [InlineData(5, Size.Small, Size.Medium, new string[] { "Nuggets: 5", "Drink Choice: Mock Drink", "\tSmall", "Side Choice: Mock Side", "\tMedium" })]
        [InlineData(5, Size.Medium, Size.Large, new string[] { "Nuggets: 5", "Drink Choice: Mock Drink", "\tMedium", "Side Choice: Mock Side", "\tLarge" })]
        [InlineData(6, Size.Large, Size.Kids, new string[] { "Nuggets: 6", "Drink Choice: Mock Drink", "\tLarge", "Side Choice: Mock Side", "\tKids" })]
        [InlineData(7, Size.Medium, Size.Small, new string[] { "Nuggets: 7", "Drink Choice: Mock Drink", "\tMedium", "Side Choice: Mock Side", "\tSmall" })]
        [InlineData(8, Size.Kids, Size.Medium, new string[] { "Nuggets: 8", "Drink Choice: Mock Drink", "\tKids", "Side Choice: Mock Side", "\tMedium" })]
        [InlineData(8, Size.Large, Size.Large, new string[] { "Nuggets: 8", "Drink Choice: Mock Drink", "\tLarge", "Side Choice: Mock Side", "\tLarge" })]
        public void PrepInfoTest(uint c, Size ds, Size ss, string[] expectedPrepInfo)
        {
            ChickenNuggetsMeal cnm = new();

            cnm.Count = c;
            cnm.DrinkChoice = new MockDrink() { Size = ds };
            cnm.SideChoice = new MockSide() { Size = ss };

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, cnm.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, cnm.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            ChickenNuggetsMeal cn = new();

            Assert.IsAssignableFrom<IMenuItem>(cn);
            Assert.IsAssignableFrom<KidsMeal>(cn);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            ChickenNuggetsMeal cnm = new();

            Assert.Equal("Chicken Nuggets Kids Meal", cnm.ToString());
        }

        /// <summary>
        /// Tests that changing the count notifies a property change
        /// </summary>
        /// <param name="count">The count to change to</param>
        /// <param name="propertyName">The property that is changing</param>
        [Theory]
        [InlineData(5, "Count")]
        [InlineData(5, "Calories")]
        [InlineData(5, "Price")]
        [InlineData(5, "PreparationInformation")]
        [InlineData(6, "Count")]
        [InlineData(7, "Calories")]
        [InlineData(8, "Price")]
        [InlineData(8, "PreparationInformation")]
        public void ChangingCountShouldNotifyPropertyChange(uint count, string propertyName)
        {
            ChickenNuggetsMeal item = new();
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
            ChickenNuggetsMeal item = new();
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
            ChickenNuggetsMeal item = new();
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
            ChickenNuggetsMeal item = new();
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
            ChickenNuggetsMeal item = new();
            item.DrinkChoice = new MockDrink();
            Assert.PropertyChanged(item, propertyName, () => {
                item.DrinkChoice.Size = size;
            });
        }
    }
}