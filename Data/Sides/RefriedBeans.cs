/*  Author: Jess Barrett
*  File: RefriedBeans.cs
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Sides
{
    /// <summary>
    /// The definition of the RefriedBeans class
    /// </summary>
    public class RefriedBeans : Side
    {
        /// <summary>
        /// The name of the refried beans instance
        /// </summary>
        public override string Name => "Refried Beans";

        /// <summary>
        /// The description of refried beans
        /// </summary>
        public override string Description => "Beans fried not just once but twice";

        /// <summary>
        /// Backing field for Onions
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// If there are onions in the beans
        /// </summary>
        public bool Onions
        {
            get => _onions;
            set
            {
                _onions = value;

                OnPropertyChanged(nameof(Onions));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// Backing field for CheddarCheese
        /// </summary>
        private bool _cheddarCheese = true;

        /// <summary>
        /// If there is cheese in the beans
        /// </summary>
        public bool CheddarCheese
        {
            get => _cheddarCheese;
            set
            {
                _cheddarCheese = value;

                OnPropertyChanged(nameof(CheddarCheese));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of the beans
        /// </summary>
        public override decimal Price => GetPrice(3.75m, false);

        /// <summary>
        /// The number of calories in the beans
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 300;

                if (!CheddarCheese) calories -= 90;

                if (!Onions) calories -= 5;

                return GetCalories(calories);
            }
        }

        /// <summary>
        /// The preparation information for the beans
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new()
                {
                    Size.ToString()
                };

                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");

                if (!Onions) instructions.Add("Hold Onions");

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
            if (obj is RefriedBeans r)
            {
                return Name == r.Name &&
                    Description == r.Description &&
                    Size == r.Size &&
                    CheddarCheese == r.CheddarCheese &&
                    Onions == r.Onions &&
                    Price == r.Price &&
                    Calories == r.Calories &&
                    PreparationInformation.SequenceEqual(r.PreparationInformation);
            }
            return false;
        }
    }
}