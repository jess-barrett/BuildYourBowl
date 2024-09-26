/* Author: Jess Barrett
* File: MockMenuItem.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// A mock menu item for testing
    /// </summary>
    internal class MockMenuItem : IMenuItem
    {
        /// <summary>
        /// The name of the mock menu item
        /// </summary>
        public string Name { get; set; } = "Mock Menu Item";

        /// <summary>
        /// The description of the mock menu item
        /// </summary>
        public string Description { get; set; } = "A mock menu item";

        /// <summary>
        /// The price of the mock menu item
        /// </summary>
        public decimal Price { get; set; } = 0;

        /// <summary>
        /// The amount of calories per each item
        /// </summary>
        public uint Calories { get; set; } = 0;

        /// <summary>
        /// The special instructions for the mock menu item
        /// </summary>
        public IEnumerable<string> PreparationInformation { get; set; }
    }
}