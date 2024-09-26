/*  Author: Jess Barrett
*  File: GreenChickenBowl.cs
*/

using BuildYourBowl.Data.Enums;
using System.Collections.Generic;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the GreenChickenBowl class
    /// </summary>
    public class GreenChickenBowl : Bowl
    {
        /// <summary>
        /// The name of the green chicken bowl instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name => "Green Chicken Bowl";

        /// <summary>
        /// The description of this bowl
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Rice bowl with chicken and green things";

        /// <summary>
        /// Backing field for Salsa
        /// </summary>
        private Salsa _salsa = Salsa.Green;

        /// <summary>
        /// The salsa in the bowl
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
        /// The price of this bowl
        /// </summary>
        public override decimal Price => 9.99m;

        /// <summary>
        /// The default amount of calories
        /// </summary>
        public override uint DefaultCalories => 890;

        /// <summary>
        /// Information for the preparation of this bowl
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Salsa != Salsa.None && Salsa != Salsa.Green) instructions.Add($"Swap {Salsa} Salsa");

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
                { Ingredient.Chicken, new IngredientItem(Ingredient.Chicken) { Included = true, Default = true } },
                { Ingredient.Veggies, new IngredientItem(Ingredient.Veggies) { Included = true, Default = true } },
                { Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Included = true, Default = true } },
                { Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans) { Included = true, Default = true } },
                { Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole) { Included = true, Default = true } },
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