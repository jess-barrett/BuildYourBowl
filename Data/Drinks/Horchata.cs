/*  Author: Jess Barrett
*  File: Horchata.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Sides;

namespace BuildYourBowl.Data.Drinks
{
    /// <summary>
    /// The definition of the Horchata class
    /// </summary>
    public class Horchata : Drink
    {
        /// <summary>
        /// The name of the horchata instance
        /// </summary>
        public override string Name => "Horchata";

        /// <summary>
        /// The description of an horchata drink
        /// </summary>
        public override string Description => "Milky drink with cinnamon";

        /// <summary>
        /// Backing field for Size
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// The size of this drink
        /// </summary>
        public override Size Size
        {
            get => _size;
            set
            {
                _size = value;

                OnPropertyChanged(nameof(Size));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// Backing field for Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// If there is ice in this drink
        /// </summary>
        public bool Ice
        {
            get => _ice;
            set
            {
                _ice = value;

                OnPropertyChanged(nameof(Ice));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of this drink
        /// </summary>
        public override decimal Price => GetPrice(3.50m);

        /// <summary>
        /// The number of calories in this drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 380;

                if (!Ice) calories += 30;

                return GetCalories(calories);
            }
        }

        /// <summary>
        /// The preparation information for this drink
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new()
                {
                    Size.ToString()
                };

                if (!Ice) instructions.Add("Hold Ice");

                return instructions;
            }
        }

        /// <summary>
        /// Checks that two objects are equal
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <returns>If they are equal</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Horchata h)
            {
                return Name == h.Name &&
                    Description == h.Description &&
                    Size == h.Size &&
                    Price == h.Price &&
                    Calories == h.Calories &&
                    PreparationInformation.SequenceEqual(h.PreparationInformation);
            }
            return false;
        }
    }
}