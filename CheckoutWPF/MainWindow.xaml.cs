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

namespace CheckoutWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseMenuIfOpen(RoutedEventArgs e)
        {
            if (checkBoxMainMenu.IsChecked == true)
            {
                checkBoxMainMenu.IsChecked = false;
                e.Handled = true;
            }
            
        }

        private void gridActivePageTouchLayer_TouchDown(object sender, TouchEventArgs e)
        {
            CloseMenuIfOpen(e);
        }

        private void gridActivePageTouchLayer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseMenuIfOpen(e);
        }

        private void CloseMenu(object sender, RoutedEventArgs e)
        {
            CloseMenuIfOpen(e);
        }

        // disable boundary movement of window
        private void Grid_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}
