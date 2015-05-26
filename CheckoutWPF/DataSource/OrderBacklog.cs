using CheckoutWPF.Abstract;
using CheckoutWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutWPF.DataSource
{
    public class OrderBacklog : AbstractModel
    {
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                if (_orders == value)
                    return;

                _orders = value;
                OnPropertyChanged();
            }
        }

        private static OrderBacklog _instance;
        public static OrderBacklog Instance { get { return _instance ?? (_instance = new OrderBacklog()); } }
        private OrderBacklog()
        {
            Orders = new ObservableCollection<Order>();
        }

        public Order GetNextEmptyOrder()
        {
            var highestOrderId = Orders.Count > 0 ? Orders.Max(x => x.OrderID) : 0;

            var order = new Order()
            {
                OrderID = highestOrderId + 1
            };

            return order;
        }

    }
}
