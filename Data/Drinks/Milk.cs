/*  Author: Jess Barrett
*  File: Milk.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Drinks
{
    /// <summary>
    /// The definition of the Milk class
    /// </summary>
    public class Milk : Drink
    {
        /// <summary>
        /// The name of the milk instance
        /// </summary>
        public override string Name => "Milk";

        /// <summary>
        /// The description of milk
        /// </summary>
        public override string Description => "Creamy beverage in plain or chocolate";

        /// <summary>
        /// The size of this drink
        /// </summary>
        public override Size Size
        {
            get
            {
                return Size.Kids;
            }
            set
            { }
        }

        /// <summary>
        /// Backing field for Chocolate
        /// </summary>
        private bool _chocolate = false;

        /// <summary>
        /// If this drink is chocolate or not
        /// </summary>
        public bool Chocolate
        {
            get => _chocolate;
            set
            {
                _chocolate = value;

                OnPropertyChanged(nameof(Chocolate));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of this drink
        /// </summary>
        public override decimal Price => 2.50m;

        /// <summary>
        /// The number of calories in this drink
        /// </summary>
        public override uint Calories => Chocolate ? 270u : 200u;

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

                if (Chocolate) instructions.Add("Chocolate");

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
            if (obj is Milk m)
            {
                return Name == m.Name &&
                    Description == m.Description &&
                    Size == m.Size &&
                    Chocolate == m.Chocolate &&
                    Price == m.Price &&
                    Calories == m.Calories &&
                    PreparationInformation.SequenceEqual(m.PreparationInformation);
            }
            return false;
        }
    }
}