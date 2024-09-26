/*  Author: Jess Barrett
*  File: CarnitasBowl.cs
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the CarnitasBowl class
    /// </summary>
    public class CarnitasBowl : Bowl
    {
        /// <summary>
        /// The name of the carnitas bowl instance
        /// </summary>
        public override string Name => "Carnitas Bowl";

        /// <summary>
        /// The description of a carnitas bowl
        /// </summary>
        public override string Description => "Rice bowl with carnitas and extras";

        /// <summary>
        /// The price of the bowl
        /// </summary>
        public override decimal Price => Ingredients[Ingredient.Guacamole].Included ? 10.99m : 9.99m;

        /// <summary>
        /// The default amount of calories
        /// </summary>
        public override uint DefaultCalories => 680;

        /// <summary>
        /// Initializes the ingredients for the CarnitasBowl
        /// </summary>
        public override Dictionary<Ingredient, IngredientItem> InitializeIngredients()
        {
            Dictionary<Ingredient, IngredientItem> i =  new()
            {
                { Ingredient.Rice, new IngredientItem(Ingredient.Rice) { Included = true, Default = true } },
                { Ingredient.Salsa, new IngredientItem(Ingredient.Salsa) { Included = true, Default = true } },
                { Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas) { Included = true, Default = true } },
                { Ingredient.Veggies, new IngredientItem(Ingredient.Veggies) { Included = false, Default = false } },
                { Ingredient.Queso, new IngredientItem(Ingredient.Queso) { Included = true, Default = true } },
                { Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans) { Included = true, Default = true } },
                { Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole) { Included = false, Default = false } },
                { Ingredient.SourCream, new IngredientItem(Ingredient.SourCream) { Included = false, Default = false } }
            };

            foreach (IngredientItem item in i.Values)
            {
                item.PropertyChanged += HandleIncludedChange;
            }

            return i;
        }
    }
}