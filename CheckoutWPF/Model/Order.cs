using CheckoutWPF.Abstract;
using CheckoutWPF.DataSource;
using CheckoutWPF.Properties;
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

        public void AddProductByProductId(int productId)
        {
            var createNewItem = Settings.Default.CreateNewOrderItemForSameProduct;

            // check if we have that product already
            var item = Items.FirstOrDefault(x => x.Product.Id == productId);

            if(item != null && !createNewItem)
            {
                AddOrRemoveItemsFromOrderItem(item, true);
            }
            else
            {
                var product = ProductRepository.Instance.GetProductById(productId);
                item = new OrderItem(product);
                Items.Add(item);
            }
        }

        public void IncreaseOrderItemCount(Guid itemID)
        {
            var item = Items.FirstOrDefault(x => x.OrderItemID == itemID);
            if(item != null)
            {
                AddOrRemoveItemsFromOrderItem(item, true);
            }
        }

        public void RemoveProductByProductId(int id)
        {
            var item = Items.FirstOrDefault(x => x.Product.Id == id);
            if(item != null)
            {
                AddOrRemoveItemsFromOrderItem(item, false);
            }
        }

        public void DecreaseOrderItemCount(Guid itemID)
        {
            var item = Items.FirstOrDefault(x => x.OrderItemID == itemID);
            if (item != null)
            {
                AddOrRemoveItemsFromOrderItem(item, false);
            }
        }

        private void AddOrRemoveItemsFromOrderItem(OrderItem orderitem, bool add)
        {
            if(add)
            {
                orderitem.Count++;
            }
            else
            {
                orderitem.Count--;

                if (orderitem.Count == 0)
                    Items.Remove(orderitem);
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

            OnPropertyChanged(nameof(TotalValue));
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
            order.AddProductByProductId(1);
            order.AddProductByProductId(1);
            order.AddProductByProductId(2);
            order.AddProductByProductId(2);
            order.AddProductByProductId(3);
            return order;
        }
    }
}
