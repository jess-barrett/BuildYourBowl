using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuildYourBowl.PointOfSale
{
    public class ItemAddedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Custom event for when an item is added to an order
        /// </summary>
        public IMenuItem Item;

        /// <summary>
        /// Constructor for ItemAddedEventArgs
        /// </summary>
        /// <param name="i">The item being added</param>
        public ItemAddedEventArgs(IMenuItem i)
        {
            Item = i;
        }
    }
}
