/*  Author: Jess Barrett
*  File: SlidersMeal.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Sides;
using System.ComponentModel;

namespace BuildYourBowl.Data.KidsMeals
{
    /// <summary>
    /// The definition of the SlidersMeal class
    /// </summary>
    public class SlidersMeal : KidsMeal
    {
        /// <summary>
        /// The name of the sliders meal instance
        /// </summary>
        public override string Name => "Sliders Kids Meal";

        /// <summary>
        /// The description of a sliders meal
        /// </summary>
        public override string Description => "Sliders with side and drink";

        /// <summary>
        /// The main item of the kids meal
        /// </summary>
        public override string MainItem => "Sliders";

        /// <summary>
        /// The private backing field for Count
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The number of sliders in the meal
        /// </summary>
        public override uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value >= 2 && value <= 4) _count = value;

                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default number of sliders
        /// </summary>
        public override uint DefaultCount => 2;

        /// <summary>
        /// The price per extra slider
        /// </summary>
        public override decimal PricePerCount => 2m;

        /// <summary>
        /// The amount of calories per slider
        /// </summary>
        public override uint CaloriesPerCount => 150u;

        /// <summary>
        /// Backing field for AmericanCheese
        /// </summary>
        private bool _americanCheese = true;

        /// <summary>
        /// If the sliders have cheese of them
        /// </summary>
        public bool AmericanCheese
        {
            get => _americanCheese;
            set
            {
                _americanCheese = value;

                OnPropertyChanged(nameof(AmericanCheese));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The number of calories in the meal
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = GetCalories();

                if (!AmericanCheese) calories -= Count * 40;

                return calories;
            }
        }

        /// <summary>
        /// The preparation information for the meal
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                GetPrepInfo(instructions);

                if (!AmericanCheese) instructions.Add("Hold American Cheese");

                return instructions;
            }
        }
    }
}