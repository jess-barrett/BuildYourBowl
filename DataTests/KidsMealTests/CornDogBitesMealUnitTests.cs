/* Author: Jess Barrett
* File: CornDogBitesMealUnitTests.cs
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
    /// The definition of the CornDogBitesMealUnitTests class
    /// </summary>
    public class CornDogBitesMealUnitTests
    {
        /// <summary>
        /// Tests if the default values are correct when created
        /// </summary>
        [Fact]
        public void DefaultValuesTest()
        {
            CornDogBitesMeal cdb = new();

            Assert.Equal(5u, cdb.Count);
            Assert.True(cdb.DrinkChoice is Milk);
            Assert.Equal(Size.Kids, cdb.DrinkChoice.Size);
            Assert.True(cdb.SideChoice is Fries);
            Assert.Equal(Size.Kids, cdb.SideChoice.Size);
            Assert.DoesNotContain("Curly", cdb.SideChoice.PreparationInformation);
            Assert.Equal(5.99m, cdb.Price);
            Assert.Equal(660u, cdb.Calories);
            Assert.All(new string[] { "Corn Dog Bites: 5", "Drink Choice: Milk", "\tKids", "Side Choice: Fries", "\tKids" }, prepInfo => Assert.Contains(prepInfo, cdb.PreparationInformation));
            Assert.Equal(new string[] { "Corn Dog Bites: 5", "Drink Choice: Milk", "\tKids", "Side Choice: Fries", "\tKids" }.Length, cdb.PreparationInformation.Count());
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
            CornDogBitesMeal cdb = new();

            cdb.Count = c;

            Assert.Equal(expectedCount, cdb.Count);
        }

        /// <summary>
        /// Tests that the price is correct based on the given information
        /// </summary>
        /// <param name="c">The number of bites in the meal<param>
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
            CornDogBitesMeal cdb = new();

            cdb.Count = c;
            cdb.DrinkChoice = new MockDrink() { Size = ds };
            cdb.SideChoice = new MockSide() { Size = ss };

            Assert.Equal(expectedPrice, cdb.Price);
        }

        /// <summary>
        /// Tests that the calorie amount is correct based on the given values
        /// </summary>
        /// <param name="c">The number of bites in the meal</param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedCals">The expected calorie amount</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, 370)]
        [InlineData(5, Size.Small, Size.Small, 400)]
        [InlineData(5, Size.Small, Size.Medium, 425)]
        [InlineData(5, Size.Medium, Size.Large, 500)]
        [InlineData(6, Size.Large, Size.Kids, 510)]
        [InlineData(7, Size.Medium, Size.Small, 525)]
        [InlineData(8, Size.Kids, Size.Medium, 560)]
        [InlineData(8, Size.Large, Size.Large, 700)]
        public void CaloriesTest(uint c, Size ds, Size ss, uint expectedCals)
        {
            CornDogBitesMeal cdb = new();

            cdb.Count = c;
            cdb.DrinkChoice = new MockDrink() { Size = ds };
            cdb.SideChoice = new MockSide() { Size = ss };

            Assert.Equal(expectedCals, cdb.Calories);
        }

        /// <summary>
        /// Tests that the preparation information is correct based on the given values
        /// </summary>
        /// <param name="c">The number of bites in the meal</param>
        /// <param name="ds">The size of the drink</param>
        /// <param name="ss">The size of the side</param>
        /// <param name="expectedPrepInfo">The expected preparation information</param>
        [Theory]
        [InlineData(5, Size.Kids, Size.Kids, new string[] { "Corn Dog Bites: 5", "Drink Choice: Mock Drink", "\tKids", "Side Choice: Mock Side", "\tKids" })]
        [InlineData(5, Size.Small, Size.Small, new string[] { "Corn Dog Bites: 5", "Drink Choice: Mock Drink", "\tSmall", "Side Choice: Mock Side", "\tSmall" })]
        [InlineData(5, Size.Small, Size.Medium, new string[] { "Corn Dog Bites: 5", "Drink Choice: Mock Drink", "\tSmall", "Side Choice: Mock Side", "\tMedium" })]
        [InlineData(5, Size.Medium, Size.Large, new string[] { "Corn Dog Bites: 5", "Drink Choice: Mock Drink", "\tMedium", "Side Choice: Mock Side", "\tLarge" })]
        [InlineData(6, Size.Large, Size.Kids, new string[] { "Corn Dog Bites: 6", "Drink Choice: Mock Drink", "\tLarge", "Side Choice: Mock Side", "\tKids" })]
        [InlineData(7, Size.Medium, Size.Small, new string[] { "Corn Dog Bites: 7", "Drink Choice: Mock Drink", "\tMedium", "Side Choice: Mock Side", "\tSmall" })]
        [InlineData(8, Size.Kids, Size.Medium, new string[] { "Corn Dog Bites: 8", "Drink Choice: Mock Drink", "\tKids", "Side Choice: Mock Side", "\tMedium" })]
        [InlineData(8, Size.Large, Size.Large, new string[] { "Corn Dog Bites: 8", "Drink Choice: Mock Drink", "\tLarge", "Side Choice: Mock Side", "\tLarge" })]
        public void PrepInfoTest(uint c, Size ds, Size ss, string[] expectedPrepInfo)
        {
            CornDogBitesMeal cdb = new();

            cdb.Count = c;
            cdb.DrinkChoice = new MockDrink() { Size = ds };
            cdb.SideChoice = new MockSide() { Size = ss };

            Assert.All(expectedPrepInfo, prepInfo => Assert.Contains(prepInfo, cdb.PreparationInformation));
            Assert.Equal(expectedPrepInfo.Length, cdb.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests that this can be cast to the base class types
        /// </summary>
        [Fact]
        public void CastableTest()
        {
            CornDogBitesMeal cdb = new();

            Assert.IsAssignableFrom<IMenuItem>(cdb);
            Assert.IsAssignableFrom<KidsMeal>(cdb);
        }

        /// <summary>
        /// Tests the ToString method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CornDogBitesMeal cdb = new();

            Assert.Equal("Corn Dog Bites Kids Meal", cdb.ToString());
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
            CornDogBitesMeal item = new();
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
            CornDogBitesMeal item = new();
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
            CornDogBitesMeal item = new();
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
            CornDogBitesMeal item = new();
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
            CornDogBitesMeal item = new();
            item.DrinkChoice = new MockDrink();
            Assert.PropertyChanged(item, propertyName, () => {
                item.DrinkChoice.Size = size;
            });
        }
    }
}