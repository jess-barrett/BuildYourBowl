/* Author: Jess Barrett
* File: MockDrink.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.DataTests.MockClasses
{
    /// <summary>
    /// The definition of the MockDrink class
    /// </summary>
    internal class MockDrink : Drink
    {
        /// <summary>
        /// The name of the mock drink
        /// </summary>
        public override string Name => "Mock Drink";

        /// <summary>
        /// The description of the mock drink
        /// </summary>
        public override string Description => "A mock drink";

        /// <summary>
        /// The price of the mock drink
        /// </summary>
        public override decimal Price => 0;

        /// <summary>
        /// The amount of calories in the mock drink
        /// </summary>
        public override uint Calories => GetCalories(100u);

        /// <summary>
        /// Backing field for Size
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The size of the mock drink
        /// </summary>
        public override Size Size
        {
            get => _size;
            set
            {
                _size = value;

                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The preparation information for the mock drink
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                return new List<string>() { Size.ToString() };
            }
        }
    }
}