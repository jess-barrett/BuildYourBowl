using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BuildYourBowl.PointOfSale
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Handles when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The order to be displayed
        /// </summary>
        private Order _order;

        /// <summary>
        /// The total for the order
        /// </summary>
        public decimal Total => _order.Total;

        /// <summary>
        /// The subtotal for the order
        /// </summary>
        public decimal Subtotal => _order.Subtotal;

        /// <summary>
        /// The tax on the order
        /// </summary>
        public decimal Tax => _order.Tax;

        /// <summary>
        /// Backing field for ValidAmount
        /// </summary>
        private bool _validAmount = true;

        /// <summary>
        /// Whether the amount paid is a valid amount
        /// </summary>
        public bool ValidAmount
        {
            get => _validAmount;
            set
            {
                _validAmount = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValidAmount)));
            }
        }

        /// <summary>
        /// Backing field for Paid
        /// </summary>
        private decimal _paid;

        /// <summary>
        /// How much the customer has paid for their order
        /// </summary>
        public decimal Paid
        {
            get => _paid;
            set
            {
                if (value < Total)
                {
                    ValidAmount = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValidAmount)));
                    throw new ArgumentException();
                }
                else
                {
                    ValidAmount = true;
                    _paid = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValidAmount)));
                }
            }
        }

        /// <summary>
        /// The change owed to the customer
        /// </summary>
        public decimal Change => Paid - Total;

        /// <summary>
        /// A string of info to print on the receipt
        /// </summary>
        public string Receipt
        {
            get
            {
                StringBuilder sb = new();

                sb.AppendLine("Order Number: " + _order.Number.ToString());
                sb.AppendLine("Placed At: " + _order.PlacedAt.ToString() + "\n");
                
                foreach (IMenuItem item in _order.List)
                {
                    sb.AppendLine(item.Name + "\t" + item.Price.ToString("C"));
                    
                    foreach (string line in item.PreparationInformation)
                    {
                        sb.AppendLine("\t" + line);
                    }

                    sb.Append("\n");
                }

                sb.AppendLine("Subtotal: " + _order.Subtotal.ToString("C"));
                sb.AppendLine("Tax: " + _order.Tax.ToString("C"));
                sb.AppendLine("Total: " + _order.Total.ToString("C"));
                sb.AppendLine("Amount Paid: " + Paid.ToString("C"));
                sb.AppendLine("Change: " + Change.ToString("C"));
                sb.AppendLine("-------------------------------------------");

                return sb.ToString();
            }
        }

        /// <summary>
        /// Creates a new PaymentViewModel
        /// </summary>
        /// <param name="order">The order</param>
        public PaymentViewModel(Order order)
        {
            _order = order;

            _paid = order.Total;
        }
    }
}
