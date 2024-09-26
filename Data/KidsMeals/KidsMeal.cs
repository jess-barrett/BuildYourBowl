/* Author: Jess Barrett
* File: KidsMeal.cs
*/

using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Enums;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.KidsMeals
{
    /// <summary>
    /// The definition of the abstract KidsMeal class
    /// </summary>
    public abstract class KidsMeal : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A handler for when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the kids meal
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the kids meal
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The main meal item in the kids meal
        /// </summary>
        public abstract string MainItem { get; }

        /// <summary>
        /// The default amount of the main entree item
        /// </summary>
        public abstract uint DefaultCount { get; }

        /// <summary>
        /// The count of the main entree of the kids meal
        /// </summary>
        public virtual uint Count { get; set; }

        /// <summary>
        /// Backing field for DrinkChoice
        /// </summary>
        private Drink _drinkChoice = new Milk { Size = Size.Kids };

        /// <summary>
        /// The default drink choice for a kids meal
        /// </summary>
        public virtual Drink DrinkChoice
        {
            get => _drinkChoice;
            set
            {
                _drinkChoice = value;

                _drinkChoice.PropertyChanged += HandlePropertyChange;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DrinkChoice)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
        }

        /// <summary>
        /// Backing field for SideChoice
        /// </summary>
        private Side _sideChoice = new Fries { Size = Size.Kids };

        /// <summary>
        /// The default side choice for a kids meal
        /// </summary>
        public virtual Side SideChoice
        {
            get => _sideChoice;
            set
            {
                _sideChoice = value;

                _sideChoice.PropertyChanged += HandlePropertyChange;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SideChoice)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
        }

        /// <summary>
        /// The default count of the main entree of the kids meal
        /// </summary>
        public abstract decimal PricePerCount { get; }

        /// <summary>
        /// The price of a kids meal
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                decimal price = 5.99m;

                for (decimal i = DefaultCount; i < Count; i++)
                {
                    price += PricePerCount;
                }

                if (DrinkChoice.Size == Size.Small) price += 0.5m;

                if (DrinkChoice.Size == Size.Medium) price += 1;

                if (DrinkChoice.Size == Size.Large) price += 1.5m;

                if (SideChoice.Size == Size.Small) price += 0.5m;

                if (SideChoice.Size == Size.Medium) price += 1;

                if (SideChoice.Size == Size.Large) price += 1.5m;

                return price;
            }
        }

        /// <summary>
        /// The amount of calories in each entree item
        /// </summary>
        public abstract uint CaloriesPerCount { get; }

        /// <summary>
        /// The amount of calories in the kids meal
        /// </summary>
        public virtual uint Calories => GetCalories();

        /// <summary>
        /// The prepartion information for the kids meal
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        public KidsMeal()
        {
            _drinkChoice.PropertyChanged += HandlePropertyChange;
            _sideChoice.PropertyChanged += HandlePropertyChange;
        }

        /// <summary>
        /// Adds the preparation information for the kids meal
        /// </summary>
        /// <param name="i">The list to add to</param>
        public void GetPrepInfo(List<string> i)
        {
            i.Add(MainItem + ": " + Count);

            i.Add("Drink Choice: " + DrinkChoice.Name);
            foreach (string s in DrinkChoice.PreparationInformation)
            {
                i.Add("\t" + s);
            }

            i.Add("Side Choice: " + SideChoice.Name);
            foreach (string s in SideChoice.PreparationInformation)
            {
                i.Add("\t" + s); ;
            }
        }

        /// <summary>
        /// Calculates the amount of calories in the entree
        /// </summary>
        /// <returns>The amount of calories</returns>
        public uint GetCalories()
        {
            uint calories = Count * CaloriesPerCount;

            calories += DrinkChoice.Calories;

            calories += SideChoice.Calories;

            return calories;
        }

        /// <summary>
        /// Returns the name of the kids meal
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
        /// Handles when a property changes
        /// </summary>
        /// <param name="sender">Information about the change</param>
        /// <param name="e">Information about the change</param>
        private void HandlePropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SideChoice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DrinkChoice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
        }

        /// <summary>
        /// Checks that two kids meals are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is KidsMeal m)
            {
                return Name == m.Name && SideChoice.Equals(m.SideChoice) && DrinkChoice.Equals(m.DrinkChoice);
            }
            return false;
        }
    }
}