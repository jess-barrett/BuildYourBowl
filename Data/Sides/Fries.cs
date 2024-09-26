/*  Author: Jess Barrett
*  File: Fries.cs
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition for the Fries class
    /// </summary>
    public class Fries : Side
    {
        /// <summary>
        /// The name of the fries instance
        /// </summary>
        public override string Name => "Fries";

        /// <summary>
        /// The description of fries
        /// </summary>
        public override string Description => "Crispy, salty sticks of deliciousness";

        /// <summary>
        /// Backing field for Curly
        /// </summary>
        private bool _curly = false;

        /// <summary>
        /// If the fries are curly of not
        /// </summary>
        public bool Curly
        {
            get => _curly;
            set
            {
                _curly = value;

                OnPropertyChanged(nameof(Curly));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of the fries
        /// </summary>
        public override decimal Price => GetPrice(3.50m, false);

        /// <summary>
        /// The number of calories in the fries
        /// </summary>
        public override uint Calories => GetCalories(350);

        /// <summary>
        /// The preparation information for the fries
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new()
                {
                    Size.ToString()
                };

                if (Curly) instructions.Add("Curly");

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
            if (obj is Fries f)
            {
                return Name == f.Name &&
                    Description == f.Description &&
                    Size == f.Size &&
                    Curly == f.Curly &&
                    Price == f.Price &&
                    Calories == f.Calories &&
                    PreparationInformation.SequenceEqual(f.PreparationInformation);
            }
            return false;
        }
    }
}