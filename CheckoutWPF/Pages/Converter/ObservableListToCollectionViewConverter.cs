using CheckoutWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CheckoutWPF.Pages.Converter
{
    public class ObservableListToCollectionViewConverter : IMultiValueConverter
    {
        private int currentCategoryId;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
                return DependencyProperty.UnsetValue;

            if (values[0] is ObservableCollection<Product> && values[1] is int)
            {
                var list = (ObservableCollection<Product>)values[0];
                currentCategoryId = (int)values[1];

                var view = CollectionViewSource.GetDefaultView(list);
                view.Filter = new Predicate<object>(FilterByCurrentCategoryId);
                return view;
            }

            return DependencyProperty.UnsetValue;
        }

        private bool FilterByCurrentCategoryId(object obj)
        {
            var item = (Product)obj;

            return item.CategoryId == currentCategoryId;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
