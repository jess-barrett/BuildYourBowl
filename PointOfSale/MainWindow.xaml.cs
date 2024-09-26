using BuildYourBowl.Data;
using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.Entrees;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;
using System.Collections.ObjectModel;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MenuControl.ItemAdded += ItemAddedEventHandler;
            OrderControl.ItemEdit += ItemAddedEventHandler;
            OrderControl.ItemRemove += ItemRemovedEventHandler;
            PaymentControl.FinalizePaymentHandler += FinalizeOrderHandler;

            DataContext = new Order();
        }

        /// <summary>
        /// Handles clearing the current order
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void CancelOrder(object sender, RoutedEventArgs e)
        {
            DataContext = new Order();

            HideAllControls();

            MenuControl.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles when an Item is added to the order
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void ItemAddedEventHandler(object? sender, ItemAddedEventArgs e)
        {
            HideAllControls();

            switch (e.Item)
            {
                case Fries:
                    FriesControl.Visibility = Visibility.Visible;
                    FriesControl.DataContext = e.Item;
                    break;

                case StreetCorn:
                    StreetCornControl.Visibility = Visibility.Visible;
                    StreetCornControl.DataContext = e.Item;
                    break;

                case RefriedBeans:
                    RefriedBeansControl.Visibility = Visibility.Visible;
                    RefriedBeansControl.DataContext = e.Item;
                    break;

                case AguaFresca:
                    AguaFrescaControl.Visibility = Visibility.Visible;
                    AguaFrescaControl.DataContext = e.Item;
                    break;

                case Horchata:
                    HorchataControl.Visibility = Visibility.Visible;
                    HorchataControl.DataContext = e.Item;
                    break;

                case Milk:
                    MilkControl.Visibility = Visibility.Visible;
                    MilkControl.DataContext = e.Item;
                    break;

                case Entree:
                    EntreeControl.Visibility = Visibility.Visible;
                    EntreeControl.DataContext = e.Item;
                    break;

                case KidsMeal:
                    KidsMealControl.Visibility = Visibility.Visible;
                    KidsMealControl.DataContext = e.Item;

                    if (e.Item is KidsMeal km)
                    {
                        KidsMealControl.CountBox.Count = km.DefaultCount;

                        if (km is SlidersMeal)
                        {
                            KidsMealControl.CheeseOption.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            KidsMealControl.CheeseOption.Visibility = Visibility.Hidden;
                        }

                        if (km.SideChoice is Fries)
                        {
                            KidsMealControl.Fries.IsChecked = true;
                            KidsMealControl.FriesControl.Visibility = Visibility.Visible;
                            KidsMealControl.RefriedBeansControl.Visibility = Visibility.Hidden;
                            KidsMealControl.StreetCornControl.Visibility = Visibility.Hidden;
                        }
                        else if (km.SideChoice is RefriedBeans)
                        {
                            KidsMealControl.RefriedBeans.IsChecked = true;
                            KidsMealControl.RefriedBeansControl.Visibility = Visibility.Visible;
                            KidsMealControl.FriesControl.Visibility = Visibility.Hidden;
                            KidsMealControl.StreetCornControl.Visibility = Visibility.Hidden;
                        }
                        else if (km.SideChoice is StreetCorn)
                        {
                            KidsMealControl.StreetCorn.IsChecked = true;
                            KidsMealControl.StreetCornControl.Visibility = Visibility.Visible;
                            KidsMealControl.FriesControl.Visibility = Visibility.Hidden;
                            KidsMealControl.RefriedBeansControl.Visibility = Visibility.Hidden;
                        }

                        if (km.DrinkChoice is Milk)
                        {
                            KidsMealControl.Milk.IsChecked = true;
                            KidsMealControl.MilkControl.Visibility = Visibility.Visible;
                            KidsMealControl.AguaFrescaControl.Visibility = Visibility.Hidden;
                            KidsMealControl.HorchataControl.Visibility = Visibility.Hidden;
                        }
                        else if (km.DrinkChoice is AguaFresca)
                        {
                            KidsMealControl.AguaFresca.IsChecked = true;
                            KidsMealControl.AguaFresca.Visibility = Visibility.Visible;
                            KidsMealControl.MilkControl.Visibility = Visibility.Hidden;
                            KidsMealControl.HorchataControl.Visibility = Visibility.Hidden;
                        }
                        else if (km.DrinkChoice is Horchata)
                        {
                            KidsMealControl.Horchata.IsChecked = true;
                            KidsMealControl.Horchata.Visibility = Visibility.Visible;
                            KidsMealControl.MilkControl.Visibility = Visibility.Hidden;
                            KidsMealControl.AguaFrescaControl.Visibility = Visibility.Hidden;
                        }
                    }

                    break;
            }

            MenuControl.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Handles when an Item is removed from the order
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void ItemRemovedEventHandler(object? sender, ItemAddedEventArgs e)
        {
            HideAllControls();

            MenuControl.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles going back to the menu
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void BackToMenu(object sender, RoutedEventArgs e)
        {
            HideAllControls();

            MenuControl.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles completing an order
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void CompleteOrder(object sender, RoutedEventArgs e)
        {
            HideAllControls();

            MenuControl.Visibility = Visibility.Hidden;

            if (DataContext is Order order)
            {
                PaymentControl.DataContext = new PaymentViewModel(order);
            }

            PaymentControl.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles finalizing an order
        /// </summary>
        /// <param name="sender">Information about the click</para
        public void FinalizeOrderHandler(object? sender, RoutedEventArgs e)
        {
            PaymentControl.Visibility = Visibility.Hidden;
            MenuControl.Visibility = Visibility.Visible;
            DataContext = new Order();
        }

        /// <summary>
        /// Hides all control views
        /// </summary>
        private void HideAllControls()
        {
            FriesControl.Visibility = Visibility.Hidden;
            StreetCornControl.Visibility = Visibility.Hidden;
            RefriedBeansControl.Visibility = Visibility.Hidden;
            AguaFrescaControl.Visibility = Visibility.Hidden;
            HorchataControl.Visibility = Visibility.Hidden;
            MilkControl.Visibility = Visibility.Hidden;
            EntreeControl.Visibility = Visibility.Hidden;
            KidsMealControl.Visibility = Visibility.Hidden;
            PaymentControl.Visibility = Visibility.Hidden;
        }
    }
}