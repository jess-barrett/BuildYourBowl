/* Author: Jess Barrett
* File: Nachos.cs
*/

using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the Nachos class
    /// </summary>
    public class Nachos : Entree
    {
        /// <summary>
        /// The name of a default nachos
        /// </summary>
        public override string Name => "Build-Your-Own Nachos";

        /// <summary>
        /// The description of a default nachos
        /// </summary>
        public override string Description => "Nachos you get to build";

        /// <summary>
        /// The base ingredient of nachos
        /// </summary>
        public override IngredientItem Base => new IngredientItem(Ingredient.Chips);

        /// <summary>
        /// Initializes a new Entree
        /// </summary>
        public Nachos()
        {
            Ingredients = InitializeIngredients();
        }
    }
}