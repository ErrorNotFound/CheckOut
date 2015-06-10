using CheckoutWPF.Abstract;
using CheckoutWPF.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutWPF.Model
{
    public class OrderItem : AbstractModel
    {
        public Guid OrderItemID { get; private set; }

        private Product _product;
        public Product Product
        {
            get { return _product; }
            private set
            {
                if (_product == value)
                    return;

                _product = value;
                OnPropertyChanged();
            }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count)
                    return;

                _count = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }


        public decimal TotalValue
        {
            get
            {
                return Count * Product.Price;
            }
        }

        public OrderItem(Product product)
        {
            Product = product;
            Count = 1;

            OrderItemID = Guid.NewGuid();
        }
    }
}
