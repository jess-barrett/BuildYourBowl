/* Author: Jess Barrett
* File: Bowl.cs
*/

using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the Bowl class
    /// </summary>
    public class Bowl : Entree
    {
        /// <summary>
        /// The name of a default bowl
        /// </summary>
        public override string Name => "Build-Your-Own Bowl";

        /// <summary>
        /// The description of a default bowl
        /// </summary>
        public override string Description => "A bowl you get to build";

        /// <summary>
        /// The base ingredient of a bowl
        /// </summary>
        public override IngredientItem Base => new IngredientItem(Ingredient.Rice);

        /// <summary>
        /// Initializes a new Bowl
        /// </summary>
        public Bowl()
        {
            Ingredients = InitializeIngredients();
        }
    }
}