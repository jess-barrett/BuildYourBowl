/* Author: Jess Barrett
* File: Order.cs
*/

using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// The definition of the Order class
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// The handler for when this collection changes
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// The handler for when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// A list of items in the order
        /// </summary>
        public List<IMenuItem> List = new();

        /// <summary>
        /// The number of items in the order
        /// </summary>
        public int Count => List.Count();

        /// <summary>
        /// If this is readonly
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// The subtotal of the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal total = 0;

                foreach (IMenuItem item in List)
                {
                    total += item.Price;
                }

                return total;
            }
        }

        /// <summary>
        /// The private backing field for TaxRate
        /// </summary>
        private decimal _taxRate = 0.0915m;

        /// <summary>
        /// The taxrate on the order
        /// </summary>
        public decimal TaxRate
        {
            get => _taxRate;
            set
            {
                _taxRate = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

        /// <summary>
        /// The tax on the order
        /// </summary>
        public decimal Tax => decimal.Round(Subtotal * TaxRate, 2);

        /// <summary>
        /// The total cost of the order
        /// </summary>
        public decimal Total => Subtotal + Tax;

        /// <summary>
        /// The static counter for the Number
        /// </summary>
        private static int _nextNumber = 1;

        /// <summary>
        /// The unique identifier for the order
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// When the order is placed
        /// </summary>
        public DateTime PlacedAt { get; init; }

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order()
        {
            Number = _nextNumber;

            _nextNumber++;

            PlacedAt = DateTime.Now;
        }

        /// <summary>
        /// Handles whenever a property is changed
        /// </summary>
        /// <param name="sender">Information about the change</param>
        /// <param name="e">Information about the change</param>
        private void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Adds an item to the order
        /// </summary>
        /// <param name="item">The item to remove</param>
        public void Add(IMenuItem item)
        {
            List.Add(item);

            if (item is Drink d)
            {
                d.PropertyChanged += HandlePropertyChanged;
            }
            else if (item is Side s)
            {
                s.PropertyChanged += HandlePropertyChanged;
            }
            else if (item is Entree e)
            {
                e.PropertyChanged += HandlePropertyChanged;
            }
            else if (item is KidsMeal km)
            {
                km.PropertyChanged += HandlePropertyChanged;
                km.SideChoice.PropertyChanged += HandlePropertyChanged;
                km.DrinkChoice.PropertyChanged += HandlePropertyChanged;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        /// <summary>
        /// Removes an item from the order
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>If the item was removed</returns>
        public bool Remove(IMenuItem item)
        {
            int index = List.IndexOf(item);

            if (index > -1)
            {
                List.Remove(item);

                if (item is Drink d)
                {
                    d.PropertyChanged -= HandlePropertyChanged;
                }
                else if (item is Side s)
                {
                    s.PropertyChanged -= HandlePropertyChanged;
                }
                else if (item is Entree e)
                {
                    e.PropertyChanged -= HandlePropertyChanged;
                }
                else if (item is KidsMeal km)
                {
                    km.PropertyChanged -= HandlePropertyChanged;
                    km.SideChoice.PropertyChanged -= HandlePropertyChanged;
                    km.DrinkChoice.PropertyChanged -= HandlePropertyChanged;
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));

                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears everything from the order
        /// </summary>
        public void Clear()
        {
            foreach (IMenuItem item in List)
            {
                if (item is Drink d)
                {
                    d.PropertyChanged -= HandlePropertyChanged;
                }
                else if (item is Side s)
                {
                    s.PropertyChanged -= HandlePropertyChanged;
                }
                else if (item is Entree e)
                {
                    e.PropertyChanged -= HandlePropertyChanged;
                }
                else if (item is KidsMeal km)
                {
                    km.PropertyChanged -= HandlePropertyChanged;
                    km.SideChoice.PropertyChanged -= HandlePropertyChanged;
                    km.DrinkChoice.PropertyChanged -= HandlePropertyChanged;
                }
            }

            List = new();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// If the orders contains the given item
        /// </summary>
        /// <param name="item">The item to check for</param>
        /// <returns>If the order contains the item</returns>
        public bool Contains(IMenuItem item)
        {
            return List.Contains(item);
        }

        /// <summary>
        /// Copies the array starting at the given index
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The starting index</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Enumerates through the order
        /// </summary>
        /// <returns>An enumerator for the order</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        /// <summary>
        /// Calls the GetEnumerator method
        /// </summary>
        /// <returns>The value from GetEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}