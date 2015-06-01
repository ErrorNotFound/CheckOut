using CheckoutWPF.DataSource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CheckoutWPF.Pages.Converter
{
    public class CategoryIdToCategoryNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int)
            {
                var catId = (int)value;
                var category = ProductRepository.Instance.GetCategoryById(catId);
                return category.Name;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                var name = (string)value;

                var catId = ProductRepository.Instance.GetCategoryIdByName(name);
                return catId;
            }

            return 0;
        }
    }
}
