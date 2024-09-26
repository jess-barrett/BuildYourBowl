/* Author: Jess Barrett
* File: MockSide.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Sides;

namespace BuildYourBowl.DataTests.MockClasses
{
    /// <summary>
    /// The definition of the MockSide class
    /// </summary>
    internal class MockSide : Side
    {
        /// <summary>
        /// The name of the mock side
        /// </summary>
        public override string Name => "Mock Side";

        /// <summary>
        /// The description of the mock side
        /// </summary>
        public override string Description => "A mock side";

        /// <summary>
        /// The price of the mock menu side
        /// </summary>
        public override decimal Price => 0;

        /// <summary>
        /// The amount of calories in the mock side
        /// </summary>
        public override uint Calories => GetCalories(100u);

        /// <summary>
        /// The special instructions for the mock side
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