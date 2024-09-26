using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public EventHandler<RoutedEventArgs>? FinalizePaymentHandler;

        public PaymentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles when the user finalizes their payment
        /// </summary>
        /// <param name="sender">Information about the event</param>
        /// <param name="e">Information about the event</param>
        public void FinalizePaymentClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.DataContext is PaymentViewModel p)
                {
                    File.AppendAllText("receipts.txt", p.Receipt);

                    MessageBox.Show("Receipt printed!\nClick OK to start a new order");

                    FinalizePaymentHandler?.Invoke(this, new RoutedEventArgs());
                }
            }
        }
    }
}
