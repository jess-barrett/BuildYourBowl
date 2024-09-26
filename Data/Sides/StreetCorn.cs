/*  Author: Jess Barrett
*  File: StreetCorn.cs
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
    /// The definition of the StreetCorn class
    /// </summary>
    public class StreetCorn : Side
    {
        /// <summary>
        /// The name of the street corn instance
        /// </summary>
        public override string Name => "Street Corn";

        /// <summary>
        /// The description of street corn
        /// </summary>
        public override string Description => "The zestiest corn out there";

        /// <summary>
        /// Backing field for CotijaCheese
        /// </summary>
        private bool _cotijaCheese = true;

        /// <summary>
        /// If there is cotija cheese in the street corn
        /// </summary>
        public bool CotijaCheese
        {
            get => _cotijaCheese;
            set
            {
                _cotijaCheese = value;

                OnPropertyChanged(nameof(CotijaCheese));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// Backing field for Cilantro
        /// </summary>
        private bool _cilantro = true;

        /// <summary>
        /// If there is cilantro in the street corn
        /// </summary>
        public bool Cilantro
        {
            get => _cilantro;
            set
            {
                _cilantro = value;

                OnPropertyChanged(nameof(Cilantro));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of the street corn
        /// </summary>
        public override decimal Price => GetPrice(4.50m, true);

        /// <summary>
        /// The number of calories in the street corn
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 300;

                if (!CotijaCheese) calories -= 80;

                if (!Cilantro) calories -= 5;

                return GetCalories(calories);
            }
        }

        /// <summary>
        /// The preparation information for the street corn
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new()
                {
                    Size.ToString()
                };

                if (!CotijaCheese) instructions.Add("Hold Cotija Cheese");

                if (!Cilantro) instructions.Add("Hold Cilantro");

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
            if (obj is StreetCorn s)
            {
                return Name == s.Name &&
                    Description == s.Description &&
                    Size == s.Size &&
                    CotijaCheese == s.CotijaCheese &&
                    Cilantro == s.Cilantro &&
                    Price == s.Price &&
                    Calories == s.Calories &&
                    PreparationInformation.SequenceEqual(s.PreparationInformation);
            }
            return false;
        }
    }
}