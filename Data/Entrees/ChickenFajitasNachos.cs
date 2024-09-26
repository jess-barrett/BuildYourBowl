/*  Author: Jess Barrett
*  File: ChickenFajitasNachos.cs
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
    /// The definition for the ChickenFajitasNachos class
    /// </summary>
    public class ChickenFajitasNachos : Nachos
    {
        /// <summary>
        /// The name of a spicy fajitas nachos instance
        /// </summary>
        public override string Name => "Spicy Fajitas Nachos";

        /// <summary>
        /// The description of spicy fajitas nachos
        /// </summary>
        public override string Description => "Chicken fajitas but with chips";

        /// <summary>
        /// The price of the nachos
        /// </summary>
        public override decimal Price => Ingredients[Ingredient.Guacamole].Included ? 11.99m : 10.99m;

        /// <summary>
        /// The default amount of calories
        /// </summary>
        public override uint DefaultCalories => 650;

        /// <summary>
        /// Initializes the ingredients for the ChickenFajitasNachos
        /// </summary>
        public override Dictionary<Ingredient, IngredientItem> InitializeIngredients()
        {
            Dictionary<Ingredient, IngredientItem> i = new()
            {
                { Ingredient.Chips, new IngredientItem(Ingredient.Chips) { Included = true, Default = true } },
                { Ingredient.Salsa, new IngredientItem(Ingredient.Salsa) { Included = true, Default = true } },
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