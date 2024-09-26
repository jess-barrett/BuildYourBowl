/*  Author: Jess Barrett
*  File: ClassicNachos.cs
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
    /// The definition for the ClassicNachos class
    /// </summary>
    public class ClassicNachos : Nachos
    {
        /// <summary>
        /// The name of a classic nachos instance
        /// </summary>
        public override string Name => "Classic Nachos";

        /// <summary>
        /// The description of the classic nachos
        /// </summary>
        public override string Description => "Standard nachos with steak, chicken, and cheese";

        /// <summary>
        /// The price of the nachos
        /// </summary>
        public override decimal Price => Ingredients[Ingredient.Guacamole].Included ? 13.99m : 12.99m;

        /// <summary>
        /// The default amount of calories
        /// </summary>
        public override uint DefaultCalories => 710;

        /// <summary>
        /// Initializes the ingredients
        /// </summary>
        public override Dictionary<Ingredient, IngredientItem> InitializeIngredients()
        {
            Dictionary<Ingredient, IngredientItem> i = new()
            {
                { Ingredient.Chips, new IngredientItem(Ingredient.Chips) { Included = true, Default = true } },
                { Ingredient.Salsa, new IngredientItem(Ingredient.Salsa) { Included = true, Default = true } },
                { Ingredient.Steak, new IngredientItem(Ingredient.Steak) { Included = true, Default = true } },
                { Ingredient.Chicken, new IngredientItem(Ingredient.Chicken) { Included = true, Default = true } },
                { Ingredient.Veggies, new IngredientItem(Ingredient.Veggies) { Included = true, Default = true } },
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