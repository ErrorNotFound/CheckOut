using CheckoutWPF.Abstract;
using CheckoutWPF.Helper;
using CheckoutWPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckoutWPF
{
    public class MainWindowViewModel : AbstractModel
    {
        private Page _activePage;
        public Page ActivePage
        {
            get { return _activePage; }
            set
            {
                if (value == _activePage)
                    return;

                _activePage = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand<Type> _changePageCommand;
        public RelayCommand<Type> ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand<Type>((param) => ChangePage(param));
                }
                return _changePageCommand;
            }
            set
            {
                _changePageCommand = value;
            }
        }


        public MainWindowViewModel()
        {
            // Display first page
            //ActivePage = new CheckoutPage();
            ActivePage = new MyProductsPage();
        }

        private void ChangePage(Type typeOfPage)
        {
            var instance = Activator.CreateInstance(typeOfPage);

            if(instance is Page)
            {
                ActivePage = (Page)instance;
            } 
        }

    }
}
