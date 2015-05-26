using CheckoutWPF.Abstract;
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


        public MainWindowViewModel()
        {
            ActivePage = new CheckoutPage();
        }

    }
}
