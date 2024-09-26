using BuildYourBowl.Data;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemControl.xaml
    /// </summary>
    public partial class MenuItemControl : UserControl
    {
        /// <summary>
        /// Event for when an item is added
        /// </summary>
        public event EventHandler<ItemAddedEventArgs>? ItemAdded;

        public MenuItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds an item to the order view
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        private void AddItem(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order && sender is Button b)
            {
                if (b.Name == "CustomBowl")
                {
                    Bowl bo = new();

                    order.Add(bo);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(bo));
                }
                else if (b.Name == "Carnitas")
                {
                    CarnitasBowl cb = new();

                    order.Add(cb);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(cb));
                }
                else if (b.Name == "GreenChicken")
                {
                    GreenChickenBowl gcb = new();

                    order.Add(gcb);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(gcb));
                }
                else if (b.Name == "SpicySteak")
                {
                    SpicySteakBowl ssb = new();

                    order.Add(ssb);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(ssb));
                }
                else if (b.Name == "CustomNachos")
                {
                    Nachos n = new();

                    order.Add(n);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(n));
                }
                else if (b.Name == "ChickenFajitas")
                {
                    ChickenFajitasNachos cfn = new();

                    order.Add(cfn);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(cfn));
                }
                else if (b.Name == "ClassicNachos")
                {
                    ClassicNachos cn = new();

                    order.Add(cn);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(cn));
                }
                else if (b.Name == "Fries")
                {
                    Fries f = new();

                    order.Add(f);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(f));
                }
                else if (b.Name == "StreetCorn")
                {
                    StreetCorn sc = new();

                    order.Add(sc);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(sc));
                }
                else if (b.Name == "RefriedBeans")
                {
                    RefriedBeans rb = new();

                    order.Add(rb);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(rb));
                }
                else if (b.Name == "AguaFresca")
                {
                    AguaFresca af = new();

                    order.Add(af);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(af));
                }
                else if (b.Name == "Horchata")
                {
                    Horchata h = new();

                    order.Add(h);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(h));
                }
                else if (b.Name == "Milk")
                {
                    Milk m = new();

                    order.Add(m);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(m));
                }
                else if (b.Name == "ChickenNuggets")
                {
                    ChickenNuggetsMeal cnm = new();

                    order.Add(cnm);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(cnm));
                }
                else if (b.Name == "CornDogBites")
                {
                    CornDogBitesMeal cdb = new();

                    order.Add(cdb);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(cdb));
                }
                else if (b.Name == "Sliders")
                {
                    SlidersMeal sm = new();

                    order.Add(sm);

                    ItemAdded?.Invoke(this, new ItemAddedEventArgs(sm));
                }
            }
        }
    }
}
