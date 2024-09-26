/* Author: Jess Barrett
* File: OrderUnitTests.cs
*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data;
using BuildYourBowl.Data.Entrees;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// The definition of the OrderUnitTests class
    /// </summary>
    public class OrderUnitTests
    {
        [Fact]
        public void DefaultTest()
        {
            Order order = new();

            Assert.Empty(order.List);
            Assert.Equal(0, order.Subtotal);
            Assert.Equal(0, order.Tax);
            Assert.Equal(0, order.Total);
        }

        /// <summary>
        /// Tests that the subtotal is correct
        /// </summary>
        [Fact]
        public void SubtotalTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// Tests that the tax amount is correct
        /// </summary>
        [Fact]
        public void TaxTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(0.59m, order.Tax);
        }

        /// <summary>
        /// Tests that the total cost is correct
        /// </summary>
        [Fact]
        public void TotalTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(7.09m, order.Total);
        }

        /// <summary>
        /// Tests that the count is correct
        /// </summary>
        [Fact]
        public void CountTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(3, order.Count);
        }

        /// <summary>
        /// Tests that we are notified of the property change
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyTaxRateChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Tests that we are notified of the property change
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyTaxChange()
        {
            Order order = new Order();
            order.Add(new GreenChickenBowl());

            Assert.PropertyChanged(order, "Tax", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Tests that we are notified of the property change
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyTotalChange()
        {
            Order order = new Order();
            order.Add(new GreenChickenBowl());

            Assert.PropertyChanged(order, "Total", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Tests that we are notified of the property change
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifySubtotalChange()
        {
            Order order = new Order();

            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Add(new GreenChickenBowl());
            });
        }

        /// <summary>
        /// Tests that we are notified of the property change
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyTaxChange()
        {
            Order order = new Order();

            Assert.PropertyChanged(order, "Tax", () => {
                order.Add(new GreenChickenBowl());
            });
        }

        /// <summary>
        /// Tests that we are notified of the property change
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyTotalChange()
        {
            Order order = new Order();

            Assert.PropertyChanged(order, "Total", () => {
                order.Add(new GreenChickenBowl());
            });
        }

        /// <summary>
        /// Tests that Order implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Tests that Order implements INotifyCollectionChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// Tests that the order number increments correctly
        /// </summary>
        [Fact]
        public void NumberTest()
        {
            Order order1 = new();
            Order order2 = new();
            Order order3 = new();

            Assert.Equal(order1.Number + 1, order2.Number);
            Assert.Equal(order2.Number + 1, order3.Number);

            Assert.Equal(order1.Number, order1.Number); // Test that it doesn't change when requested more than once
        }

        /// <summary>
        /// Tests that the time the order is placed at is correct
        /// </summary>
        [Fact]
        public void PlacedAtTest()
        {
            Order order = new();

            Assert.Equal(DateTime.Now, order.PlacedAt, new TimeSpan(1000));

            Assert.Equal(order.PlacedAt, order.PlacedAt); // Test that it doesn't change when requested more than once
        }
    }
}