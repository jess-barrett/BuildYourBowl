/* Author: Jess Barrett
* File: Drink.cs
*/

using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Drinks
{
    /// <summary>
    /// The definition of the abstract Drink class
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// An event handler for when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The size of the drink
        /// </summary>
        public abstract Size Size { get; set; }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The amount of calories in the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The preparation information for the drink
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// Calculates the price of the drink
        /// </summary>
        /// <param name="p">The default price</param>
        /// <returns>The price</returns>
        public decimal GetPrice(decimal p)
        {
            decimal price = p;

            if (Size == Size.Kids) price -= 1;

            if (Size == Size.Small) price -= 0.5m;

            if (Size == Size.Large) price += 0.75m;

            return price;
        }

        /// <summary>
        /// Calculates the amount of calories in the drink
        /// </summary>
        /// <param name="c">The default calorie amount</param>
        /// <returns>The calorie amount</returns>
        public uint GetCalories(uint c)
        {
            double calories = c;

            if (Size == Size.Kids) calories *= 0.6;

            if (Size == Size.Small) calories *= 0.75;

            if (Size == Size.Large) calories *= 1.5;

            return (uint)calories;
        }

        /// <summary>
        /// Returns the name of the drink
        /// </summary>
        /// <returns>The name of the drink</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Helper invoking method
        /// </summary>
        /// <param name="propertyName">The property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}