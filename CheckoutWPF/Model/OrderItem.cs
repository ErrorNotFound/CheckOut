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
        public int ProductID { get; private set; }

        public string ProductName
        {
            get
            {
                return ProductRepository.Instance.GetProductById(ProductID).Name;
            }
        }

        private int _count;
        public int Count {
            get
            {
                return _count;
            }
            set
            {
                if (value == _count)
                    return;

                _count = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }

        public decimal SingleValue
        {
            get
            {
                return ProductRepository.Instance.GetProductById(ProductID).Price;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return CalculateTotalValue();
            }
        }

        public OrderItem(int productId)
        {
            ProductID = productId;
            Count = 1;
        }

        private decimal CalculateTotalValue()
        {
            if (Count == 0)
                return 0;

            Product product;
            if (true == ProductRepository.Instance.TryGetProductById(ProductID, out product))
            {
                return Count * product.Price;
            }
            else
                throw new ProductNotFoundException(ProductID);
        }
    }
}
