/*  Author: Jess Barrett
*  File: CornDogBitesMeal.cs
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
    /// The definition of the CornDogBitesMeal class
    /// </summary>
    public class CornDogBitesMeal : KidsMeal
    {
        /// <summary>
        /// The name of the corn dog bites meal instance
        /// </summary>
        public override string Name => "Corn Dog Bites Kids Meal";

        /// <summary>
        /// The description of a corn dog bites meal
        /// </summary>
        public override string Description => "Mini corn dogs with side and drink";

        /// <summary>
        /// The main item of the kids meal
        /// </summary>
        public override string MainItem => "Corn Dog Bites";

        /// <summary>
        /// The private backing field for Count
        /// </summary>
        private uint _count = 5;

        /// <summary>
        /// The number of bites in the meal
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
        /// The default number of bites
        /// </summary>
        public override uint DefaultCount => 5;

        /// <summary>
        /// The price per extra slider
        /// </summary>
        public override decimal PricePerCount => 0.75m;

        /// <summary>
        /// The amount of calories per slider
        /// </summary>
        public override uint CaloriesPerCount => 50u;

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