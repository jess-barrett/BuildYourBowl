/* Jess Barrett
* File: IngredientItem.cs
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data.Enums;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The defintion of the IngredientItem class
    /// </summary>
    public class IngredientItem : INotifyPropertyChanged
    {
        /// <summary>
        /// Handles when a property in this class changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The food item that the ingredient is
        /// </summary>
        public Ingredient IngredientType { get; }

        /// <summary>
        /// The name of the ingredient
        /// </summary>
        public string Name
        {
            get
            {
                string name;

                switch (IngredientType)
                {
                    case Ingredient.BlackBeans:
                        name = "Black Beans";
                        break;

                    case Ingredient.PintoBeans:
                        name = "Pinto Beans";
                        break;

                    case Ingredient.SourCream:
                        name = "Sour Cream";
                        break;

                    case Ingredient.CotijaCheese:
                        name = "Cotija Cheese";
                        break;

                    case Ingredient.CheddarCheese:
                        name = "Cheddar Cheese";
                        break;

                    default:
                        name = IngredientType.ToString();
                        break;
                }

                return name;
            }
        }

        /// <summary>
        /// The amount of calories in the ingredient
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals;

                switch (IngredientType)
                {
                    case Ingredient.BlackBeans:
                    case Ingredient.PintoBeans:
                        cals = 130;
                        break;

                    case Ingredient.Queso:
                        cals = 110;
                        break;

                    case Ingredient.Veggies:
                    case Ingredient.Salsa:
                        cals = 20;
                        break;

                    case Ingredient.SourCream:
                        cals = 100;
                        break;

                    case Ingredient.Guacamole:
                    case Ingredient.Chicken:
                        cals = 150;
                        break;

                    case Ingredient.Steak:
                        cals = 180;
                        break;

                    case Ingredient.Carnitas:
                    case Ingredient.Rice:
                        cals = 210;
                        break;

                    case Ingredient.Chips:
                        cals = 250;
                        break;

                    case Ingredient.CheddarCheese:
                        cals = 90;
                        break;

                    case Ingredient.CotijaCheese:
                        cals = 80;
                        break;

                    default:
                        cals = 5;
                        break;
                }

                return cals;
            }
        }

        /// <summary>
        /// The cost of the ingredient
        /// </summary>
        public decimal UnitCost
        {
            get
            {
                decimal cost;

                switch (IngredientType)
                {
                    case Ingredient.Steak:
                    case Ingredient.Chicken:
                    case Ingredient.Carnitas:
                        cost = 2.00m;
                        break;

                    case Ingredient.BlackBeans:
                    case Ingredient.PintoBeans:
                    case Ingredient.Queso:
                    case Ingredient.Guacamole:
                        cost = 1.00m;
                        break;

                    default:
                        cost = 0m;
                        break;
                }

                return cost;
            }
        }

        /// <summary>
        /// Backing field for Included
        /// </summary>
        private bool _included = false;

        /// <summary>
        /// Whether this ingredient is currently included in a containing menu item
        /// </summary>
        public bool Included
        {
            get => _included;
            set
            {
                _included = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Included)));
            }
        }

        /// <summary>
        /// Whther this ingredient is included in its containing menu item by default
        /// </summary>
        public bool Default { get; set; } = false;

        /// <summary>
        /// Constructs an IngredientItem
        /// </summary>
        /// <param name="item">The type of ingredient</param>
        public IngredientItem(Ingredient type)
        {
            IngredientType = type;
        }
    }
}