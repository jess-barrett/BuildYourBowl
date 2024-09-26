/* Author: Jess Barrett
* File: Side.cs
*/

using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition of the abstract Side class
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// An event handler for when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the side
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the side
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the side
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The amount of calories in the side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The preparation information for the side
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// Backing field for Size
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The default size of a side
        /// </summary>
        public virtual Size Size
        {
            get => _size;
            set
            {
                _size = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
        }

        /// <summary>
        /// Calculates the amount of calories in the side
        /// </summary>
        /// <param name="cals">The default calorie amount</param>
        /// <returns>The total calorie amount</returns>
        public uint GetCalories(uint cals)
        {
            double calories = cals;

            if (Size == Size.Kids) calories *= 0.6;

            if (Size == Size.Small) calories *= 0.75;

            if (Size == Size.Large) calories *= 1.5;

            return (uint)calories;
        }

        /// <summary>
        /// Calculates the price of the side
        /// </summary>
        /// <param name="p">The default price of the side</param>
        /// <param name="sc">If the side is Street Corn</param>
        /// <returns>The price of the side</returns>
        public decimal GetPrice(decimal p, bool sc)
        {
            decimal price = p;

            if (sc)
            {
                if (Size == Size.Kids) price -= 1.25m;

                if (Size == Size.Small) price -= 0.75m;

                if (Size == Size.Large) price += 1;
            }
            else
            {
                if (Size == Size.Kids) price -= 1m;

                if (Size == Size.Small) price -= 0.5m;

                if (Size == Size.Large) price += 0.75m;
            }

            return price;
        }

        /// <summary>
        /// Returns the name of the side
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