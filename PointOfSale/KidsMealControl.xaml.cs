using BuildYourBowl.Data.Drinks;
using BuildYourBowl.Data.KidsMeals;
using BuildYourBowl.Data.Sides;
using BuildYourBowl.Data.Enums;
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

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for KidsMealControl.xaml
    /// </summary>
    public partial class KidsMealControl : UserControl
    {
        public KidsMealControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles when a new side choice is selected
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void SideChoiceHandler(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton b && DataContext is KidsMeal meal)
            {
                FriesControl.Visibility = Visibility.Hidden;
                RefriedBeansControl.Visibility = Visibility.Hidden;
                StreetCornControl.Visibility = Visibility.Hidden;

                switch (b.Name)
                {
                    case "Fries":
                        FriesControl.Visibility = Visibility.Visible;

                        if (!(meal.SideChoice is Fries))
                        {
                            meal.SideChoice = new Fries { Size = Data.Enums.Size.Kids };
                        }
                        break;

                    case "RefriedBeans":
                        RefriedBeansControl.Visibility = Visibility.Visible;

                        if (!(meal.SideChoice is RefriedBeans))
                        {
                            meal.SideChoice = new RefriedBeans { Size = Data.Enums.Size.Kids };
                        }
                        break;

                    case "StreetCorn":
                        StreetCornControl.Visibility = Visibility.Visible;

                        if (!(meal.SideChoice is StreetCorn))
                        {
                            meal.SideChoice = new StreetCorn { Size = Data.Enums.Size.Kids };
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Handles when a new drink choice is selected
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        public void DrinkChoiceHandler(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton b && DataContext is KidsMeal meal)
            {
                MilkControl.Visibility = Visibility.Hidden;
                AguaFrescaControl.Visibility = Visibility.Hidden;
                HorchataControl.Visibility = Visibility.Hidden;

                switch (b.Name)
                {
                    case "Milk":
                        MilkControl.Visibility = Visibility.Visible;

                        if (!(meal.DrinkChoice is Milk))
                        {
                            meal.DrinkChoice = new Milk();
                        }
                        break;

                    case "AguaFresca":
                        AguaFrescaControl.Visibility = Visibility.Visible;

                        if (!(meal.DrinkChoice is AguaFresca))
                        {
                            meal.DrinkChoice = new AguaFresca { Size = Data.Enums.Size.Kids };
                        }
                        break;

                    case "Horchata":
                        HorchataControl.Visibility = Visibility.Visible;

                        if (!(meal.DrinkChoice is Horchata))
                        {
                            meal.DrinkChoice = new Horchata { Size = Data.Enums.Size.Kids };
                        }
                        break;
                }
            }
        }
    }
}
