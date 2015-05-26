using CheckoutWPF.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutWPF.Model
{
    public class Order : AbstractModel
    {
        public ObservableCollection<OrderItem> Items { get; set; }
        public int OrderID { get; set; }

        public DateTime CreatedTime { get; private set; }
        public DateTime CompletedTime { get; set; }

        public decimal TotalValue
        {
            get
            {
                return CalculateTotalValue();
            }
        }

        public Order()
        {
            Items = new ObservableCollection<OrderItem>();
            Items.CollectionChanged += Items_CollectionChanged;

            CreatedTime = DateTime.Now;
        }

        ~Order()
        {
            if (Items != null)
            {
                Items.CollectionChanged -= Items_CollectionChanged;
                Items = null;
            }
        }

        public void AddProduct(int productId)
        {
            // check if we have that product already
            var item = Items.FirstOrDefault(x => x.ProductID == productId);

            if(item != null)
            {
                item.Count++;
            }
            else
            {
                item = new OrderItem(productId);
                Items.Add(item);
            }
        }

        public void RemoveProduct(int id)
        {
            var item = Items.FirstOrDefault(x => x.ProductID == id);
            if(item != null)
            {
                item.Count--;

                if (item.Count == 0)
                    Items.Remove(item);
            }
        }


        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
                foreach (OrderItem item in e.NewItems)
                    item.PropertyChanged += OrderItem_PropertyChanged;

            if (e.OldItems != null)
                foreach (OrderItem item in e.OldItems)
                    item.PropertyChanged -= OrderItem_PropertyChanged;
        }

        private void OrderItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalValue));
        }

        private decimal CalculateTotalValue()
        {
            decimal sum = 0;

            foreach (var item in Items)
                sum += item.TotalValue;

            return sum;
        }

        public static Order GetSampleOrder()
        {
            var order = new Order();
            order.AddProduct(1);
            order.AddProduct(1);
            order.AddProduct(2);
            order.AddProduct(2);
            order.AddProduct(3);
            return order;
        }
    }
}
