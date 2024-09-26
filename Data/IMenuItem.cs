/* Author: Jess Barrett
* File: IMenuItem.cs
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the IMenuItem interface
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// The name of the menu item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The description of the menu item
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The price of the menu item
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// The amount of calories in the menu item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The preparation information for the menu item
        /// </summary>
        IEnumerable<string> PreparationInformation { get; }
    }
}