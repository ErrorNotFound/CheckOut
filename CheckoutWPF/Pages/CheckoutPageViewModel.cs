using CheckoutWPF.Abstract;
using CheckoutWPF.DataSource;
using CheckoutWPF.Helper;
using CheckoutWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckoutWPF.Pages
{
    public class CheckoutPageViewModel : AbstractModel
    {
        private Order _currentOrder;
        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                if (value == _currentOrder)
                    return;

                _currentOrder = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand<object> _nextOrderCommand;
        public RelayCommand<object> NextOrderCommand
        {
            get
            {
                if (_nextOrderCommand == null)
                {
                    _nextOrderCommand = new RelayCommand<object>((param) => NextOrder());
                }
                return _nextOrderCommand;
            }
            set
            {
                _nextOrderCommand = value;
            }
        }

        private RelayCommand<object> _barCommand;
        public RelayCommand<object> BarCommand
        {
            get
            {
                if (_barCommand == null)
                {
                    _barCommand = new RelayCommand<object>((param) => Bar());
                }
                return _barCommand;
            }
            set
            {
                _barCommand = value;
            }
        }

        private RelayCommand<object> _clearCommand;
        public RelayCommand<object> ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand<object>((param) => Cancel());
                }
                return _clearCommand;
            }
            set
            {
                _clearCommand = value;
            }
        }

        private RelayCommand<int> _addProductCommand;
        public RelayCommand<int> AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                {
                    _addProductCommand = new RelayCommand<int>(param => AddProduct(param));
                }
                return _addProductCommand;
            }
            set
            {
                _addProductCommand = value;
            }
        }

        private RelayCommand<Guid> _increaseProductCountCommand;
        public RelayCommand<Guid> IncreaseProductCountCommand
        {
            get
            {
                if (_increaseProductCountCommand == null)
                {
                    _increaseProductCountCommand = new RelayCommand<Guid>(param => IncreaseProductCount(param));
                }
                return _increaseProductCountCommand;
            }
            set
            {
                _increaseProductCountCommand = value;
            }
        }


        private RelayCommand<int> _removeProductCommand;
        public RelayCommand<int> RemoveProductCommand
        {
            get
            {
                if (_removeProductCommand == null)
                {
                    _removeProductCommand = new RelayCommand<int>(param => RemoveProduct(param));
                }
                return _removeProductCommand;
            }
            set
            {
                _removeProductCommand = value;
            }
        }

        private RelayCommand<Guid> _decreaseProductCountCommand;
        public RelayCommand<Guid> DecreaseProductCountCommand
        {
            get
            {
                if (_decreaseProductCountCommand == null)
                {
                    _decreaseProductCountCommand = new RelayCommand<Guid>(param => DecreaseProductCount(param));
                }
                return _decreaseProductCountCommand;
            }
            set
            {
                _decreaseProductCountCommand = value;
            }
        }

        public CheckoutPageViewModel()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                CurrentOrder = Order.GetSampleOrder();
            }
            else
            {
                CurrentOrder = OrderBacklog.Instance.GetNextEmptyOrder();
            }
        }

        private void NextOrder()
        {
            
        }

        private void Bar()
        {

        }

        private void Cancel()
        {
            CurrentOrder = OrderBacklog.Instance.GetNextEmptyOrder();
        }

        private void AddProduct(int id)
        {
            CurrentOrder.AddProductByProductId(id);
        }

        private void IncreaseProductCount(Guid itemId)
        {
            CurrentOrder.IncreaseOrderItemCount(itemId);
        }

        private void RemoveProduct(int id)
        {
            CurrentOrder.RemoveProductByProductId(id);
        }

        private void DecreaseProductCount(Guid itemId)
        {
            CurrentOrder.DecreaseOrderItemCount(itemId);
        }

    }
}
