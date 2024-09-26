using BuildYourBowl.Data.KidsMeals;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        /// <summary>
        /// The count in the CountBox
        /// </summary>
        public uint Count
        {
            get
            {
                return (uint)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        /// <summary>
        /// The dependency property for Count
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(CountBox));

        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles going up one item
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChickenNuggetsMeal cnm && Count < 8)
            {
                Count++;
                cnm.Count++;
            }
            else if (DataContext is CornDogBitesMeal cdb && Count < 8)
            {
                Count++;
                cdb.Count++;
            }
            else if (DataContext is SlidersMeal sm && Count < 4)
            {
                Count++;
                sm.Count++;
            }
        }

        /// <summary>
        /// Handles going down one item
        /// </summary>
        /// <param name="sender">Information about the click</param>
        /// <param name="e">Information about the click</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChickenNuggetsMeal cnm && Count > 5)
            {
                Count--;
                cnm.Count--;
            }
            else if (DataContext is CornDogBitesMeal cdb && Count > 5)
            {
                Count--;
                cdb.Count--;
            }
            else if (DataContext is SlidersMeal sm && Count > 2)
            {
                Count--;
                sm.Count--;
            }
        }
    }
}
