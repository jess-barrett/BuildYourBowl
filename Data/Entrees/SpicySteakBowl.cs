/*  Author: Jess Barrett
*  File: SpicySteakBowl.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition for the SpicySteakBowl class
    /// </summary>
    public class SpicySteakBowl : Bowl
    {
        /// <summary>
        /// The name of a spicy steak bowl instance
        /// </summary>
        public override string Name => "Spicy Steak Bowl";

        /// <summary>
        /// The description of a spicy steak bowl
        /// </summary>
        public override string Description => "Spicy rice bowl with steak and fajita toppings";

        /// <summary>
        /// Backing field for Salsa
        /// </summary>
        private Salsa _salsa = Salsa.Hot;

        /// <summary>
        /// The type of salsa in the bowl
        /// </summary>
        public override Salsa Salsa
        {
            get => _salsa;
            set
            {
                _salsa = value;

                Ingredients[Ingredient.Salsa].Included = (value == Salsa.None) ? false : true;

                OnPropertyChanged(nameof(Salsa));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of the bowl
        /// </summary>
        public override decimal Price => Ingredients[Ingredient.Guacamole].Included ? 11.99m : 10.99m;

        /// <summary>
        /// The default amount of calories
        /// </summary>
        public override uint DefaultCalories => 620;

        /// <summary>
        /// The preparation information for the bowl
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Salsa != Salsa.None && Salsa != Salsa.Hot) instructions.Add($"Swap {Salsa} Salsa");

                GetPrepInfo(instructions);

                return instructions;
            }
        }

        /// <summary>
        /// Initializes the ingredients
        /// </summary>
        public override Dictionary<Ingredient, IngredientItem> InitializeIngredients()
        {
            Dictionary<Ingredient, IngredientItem> i = new()
            {
                { Ingredient.Rice, new IngredientItem(Ingredient.Rice) { Included = true, Default = true } },
                { Ingredient.Salsa, new IngredientItem(Ingredient.Salsa) { Included = true, Default = true } },
                { Ingredient.Steak, new IngredientItem(Ingredient.Steak) { Included = true, Default = true } },
                { Ingredient.Veggies, new IngredientItem(Ingredient.Veggies) { Included = false, Default = false } },
                { Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Included = true, Default = true } },
                { Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole) { Included = false, Default = false } },
                { Ingredient.SourCream, new IngredientItem(Ingredient.SourCream) { Included = true, Default = true } }
            };

            foreach (IngredientItem item in i.Values)
            {
                item.PropertyChanged += HandleIncludedChange;
            }

            return i;
        }
    }
}