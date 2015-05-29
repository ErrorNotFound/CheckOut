using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckoutWPF.Pages
{
    /// <summary>
    /// Interaction logic for CheckoutPage.xaml
    /// </summary>
    public partial class CheckoutPage : Page
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private void CurrentOrderItemsPresenter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(sender is ItemsPresenter)
            {
                var ip = (ItemsPresenter)sender;

                if(ip.Parent is ScrollViewer)
                {
                    var sv = (ScrollViewer)ip.Parent;
                    sv.ScrollToBottom();
                }
            }
        }
    }
}
