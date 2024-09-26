/*  Author: Jess Barrett
*  File: AguaFresca.cs
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
    /// The definition of the AguaFresca class
    /// </summary>
    public class AguaFresca : Drink
    {
        /// <summary>
        /// The name of the agua fresca instance
        /// </summary>
        public override string Name => "Agua Fresca";

        /// <summary>
        /// The description of an agua fresca drink
        /// </summary>
        public override string Description => "Refreshingly lightly sweetened fruit drink";

        /// <summary>
        /// Backing field for Flavor
        /// </summary>
        private Flavor _flavor = Flavor.Limonada;

        /// <summary>
        /// The flavor of this drink
        /// </summary>
        public Flavor Flavor
        {
            get => _flavor;
            set
            {
                _flavor = value;

                OnPropertyChanged(nameof(Flavor));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

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
        public override decimal Price
        {
            get
            {
                decimal price = GetPrice(3m);

                if (Flavor == Flavor.Tamarind) price += 0.5m;

                return price;
            }
        }

        /// <summary>
        /// The number of calories in this drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 125;

                if (Flavor == Flavor.Tamarind || Flavor == Flavor.Strawberry) calories += 25;

                if (Flavor == Flavor.Cucumber) calories -= 50;

                if (!Ice) calories += 10;

                return GetCalories(calories);
            }
        }

        /// <summary>
        /// The preparations information for this drink
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new()
                {
                    Size.ToString(),
                    Flavor.ToString()
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
            if (obj is AguaFresca a)
            {
                return Name == a.Name &&
                    Description == a.Description &&
                    Flavor == a.Flavor &&
                    Size == a.Size &&
                    Price == a.Price &&
                    Calories == a.Calories &&
                    PreparationInformation.SequenceEqual(a.PreparationInformation);
            }
            return false;
        }
    }
}