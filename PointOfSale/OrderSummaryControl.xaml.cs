using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BuildYourBowl.Data;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// Event for when an item is added
        /// </summary>
        public event EventHandler<ItemAddedEventArgs>? ItemEdit;

        /// <summary>
        /// Event for when an item is added
        /// </summary>
        public event EventHandler<ItemAddedEventArgs>? ItemRemove;

        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles removing an item from the order
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void RemoveItem(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button b)
                {
                    if (b.DataContext is IMenuItem item)
                    {
                        order.Remove(item);

                        ItemRemove?.Invoke(this, new ItemAddedEventArgs(item));
                    }
                }
            }
        }

        /// <summary>
        /// Handles when the user wants to edit an item
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void EditItem(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order)
            {
                if (sender is Button b)
                {
                    if (b.DataContext is IMenuItem item)
                    {
                        ItemEdit?.Invoke(this, new ItemAddedEventArgs(item));
                    }
                }
            }
        }
    }
}
