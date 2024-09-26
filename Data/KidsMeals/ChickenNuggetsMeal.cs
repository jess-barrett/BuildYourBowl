/*  Author: Jess Barrett
*  File: ChickenNuggetsMeal.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Drinks;

namespace BuildYourBowl.Data.KidsMeals
{
    /// <summary>
    /// The definition of the ChickenNuggetsMeal class
    /// </summary>
    public class ChickenNuggetsMeal : KidsMeal
    {
        /// <summary>
        /// The name of a chicken nuggets meal instance
        /// </summary>
        public override string Name => "Chicken Nuggets Kids Meal";

        /// <summary>
        /// The description of a chicken nuggets meal
        /// </summary>
        public override string Description => "Chicken nuggets with side and drink";

        /// <summary>
        /// The main item of the kids meal
        /// </summary>
        public override string MainItem => "Nuggets";

        /// <summary>
        /// The private backing field for Count
        /// </summary>
        private uint _count = 5;

        /// <summary>
        /// The number of chicken nuggets in the meal
        /// </summary>
        public override uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 5 && value <= 8) _count = value;

                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default number of nuggets
        /// </summary>
        public override uint DefaultCount => 5;

        /// <summary>
        /// The price per extra nugget
        /// </summary>
        public override decimal PricePerCount => 0.75m;

        /// <summary>
        /// The number of calories per nugget
        /// </summary>
        public override uint CaloriesPerCount => 60;

        /// <summary>
        /// The preparation information for the meal
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                GetPrepInfo(instructions);

                return instructions;
            }
        }
    }
}