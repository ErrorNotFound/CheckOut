using CheckoutWPF.DataSource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CheckoutWPF.Pages.Converter
{
    public class CategoryIdToCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var categoryId = (int)value;

            var count = ProductRepository.Instance.Products.Count(x => x.CategoryId == categoryId);

            return count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
