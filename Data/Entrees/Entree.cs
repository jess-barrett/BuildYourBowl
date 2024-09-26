/* Author: Jess Barrett
* File: Entree.cs
*/

using BuildYourBowl.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildYourBowl.Data.Entrees
{
    /// <summary>
    /// The definition of the abstract Entree class
    /// </summary>
    public abstract class Entree : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// An event handler for when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the entree
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the entree
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The base ingredient for the entree
        /// </summary>
        public abstract IngredientItem Base { get; }

        /// <summary>
        /// Backing field for Salsa
        /// </summary>
        private Salsa _salsa = Salsa.Medium;

        /// <summary>
        /// The salsa on the entree
        /// </summary>
        public virtual Salsa Salsa
        {
            get => _salsa;
            set
            {
                _salsa = value;

                Ingredients[Ingredient.Salsa].Included = (value == Salsa.None) ? false : true;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salsa)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
        }

        /// <summary>
        /// The default calories on an entree
        /// </summary>
        public virtual uint DefaultCalories => Base.Calories + new IngredientItem(Ingredient.Salsa).Calories;

        /// <summary>
        /// The price of the entree
        /// </summary>
        public virtual decimal Price => GetPrice(7.99m);

        /// <summary>
        /// The amount of calories in the entree
        /// </summary>
        public virtual uint Calories => GetCalories(DefaultCalories);

        /// <summary>
        /// The preparation information for the entree
        /// </summary>
        public virtual IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Salsa != Salsa.None && Salsa != Salsa.Medium) instructions.Add($"Swap {Salsa} Salsa");

                GetPrepInfo(instructions);

                return instructions;
            }
        }

        /// <summary>
        /// The ingredients in the entree (besides base)
        /// </summary>
        public Dictionary<Ingredient, IngredientItem> Ingredients = new();

        /// <summary>
        /// A list of all ingredients
        /// </summary>
        public List<IngredientItem> AllIngredients
        {
            get
            {
                List<IngredientItem> list = new();

                foreach (IngredientItem item in Ingredients.Values)
                {
                    if (!(item.Name == "Salsa"))
                    {
                        list.Add(item);
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// Calculates the total price of the entree
        /// </summary>
        /// <param name="p">The default price of the entree</param>
        /// <returns>The price of the entree</returns>
        public decimal GetPrice(decimal p)
        {
            decimal price = p;

            foreach (KeyValuePair<Ingredient, IngredientItem> item in Ingredients)
            {
                if (item.Value.Included)
                {
                    price += item.Value.UnitCost;
                }
            }

            return price;
        }

        /// <summary>
        /// Calcluates the amount of calories in the entree
        /// </summary>
        /// <param name="c">The default calorie amount</param>
        /// <returns>The amount of calories in the entree</returns>
        public uint GetCalories(uint c)
        {
            uint cals = c;

            foreach (KeyValuePair<Ingredient, IngredientItem> i in Ingredients)
            {
                if (i.Value.Default && !i.Value.Included)
                {
                    cals -= i.Value.Calories;
                }
                else if (!i.Value.Default && i.Value.Included)
                {
                    cals += i.Value.Calories;
                }
            }

            return cals;
        }

        /// <summary>
        /// Gets (part of) the preparation info for the entree
        /// </summary>
        /// <param name="instructions">The starting instructions</param>
        public void GetPrepInfo(List<string> instructions)
        {
            foreach (KeyValuePair<Ingredient, IngredientItem> i in Ingredients)
            {
                if (i.Value.Default && !i.Value.Included)
                {
                    instructions.Add($"Hold {i.Value.Name}");
                }

                if (!i.Value.Default && i.Value.Included)
                {
                    instructions.Add($"Add {i.Value.Name}");
                }
            }
        }

        /// <summary>
        /// Initializes the ingredients for the entree
        /// </summary>
        public virtual Dictionary<Ingredient, IngredientItem> InitializeIngredients()
        {
            Dictionary<Ingredient, IngredientItem> i = new()
            {
                { Ingredient.Rice, new IngredientItem(Ingredient.Rice) { Included = true, Default = true } },
                { Ingredient.Salsa, new IngredientItem(Ingredient.Salsa) { Included =  true, Default = true } },
                { Ingredient.BlackBeans, new IngredientItem(Ingredient.BlackBeans) },
                { Ingredient.PintoBeans, new IngredientItem(Ingredient.PintoBeans) },
                { Ingredient.Queso, new IngredientItem(Ingredient.Queso) },
                { Ingredient.Veggies, new IngredientItem(Ingredient.Veggies) },
                { Ingredient.SourCream, new IngredientItem(Ingredient.SourCream) },
                { Ingredient.Guacamole, new IngredientItem(Ingredient.Guacamole) },
                { Ingredient.Chicken, new IngredientItem(Ingredient.Chicken) },
                { Ingredient.Steak, new IngredientItem(Ingredient.Steak) },
                { Ingredient.Carnitas, new IngredientItem(Ingredient.Carnitas) }
            };

            foreach (IngredientItem item in i.Values)
            {
                item.PropertyChanged += HandleIncludedChange;
            }

            return i;
        }

        /// <summary>
        /// Returns the name of the entree
        /// </summary>
        /// <returns>The name of the drink</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Helper invoking method
        /// </summary>
        /// <param name="propertyName">The property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Handles when an item's included property is changed
        /// </summary>
        /// <param name="sender">Information about the event</param>
        /// <param name="e">Information about the event</param>
        public void HandleIncludedChange(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
        }
    }
}
