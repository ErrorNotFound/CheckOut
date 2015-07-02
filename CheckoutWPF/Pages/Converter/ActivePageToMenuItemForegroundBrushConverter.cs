using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CheckoutWPF.Pages.Converter
{
    public class ActivePageToMenuItemForegroundBrushConverter : IValueConverter
    {
        private Brush _activeBrush = (SolidColorBrush)App.Current.TryFindResource("PrimaryHueMidBrush");
        private Brush _inactiveBrush = Brushes.Black;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var page = (Page)value;

            if (page.GetType() == (Type)parameter)
                return _activeBrush;
            else
                return _inactiveBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
