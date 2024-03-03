using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using POS.Models;

namespace POS.Converters
{
    public class CategoryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the values array is not null and has at least one item
            if (values != null && values.Length > 0)
            {
                // Extract the collection of MenuItemCategories from the values array
                var menuItemCategories = values[0] as IEnumerable<MenuItemCategory>;

                if (menuItemCategories != null)
                {
                    // Extract the category names from the MenuItemCategory objects
                    var categoryNames = menuItemCategories.Select(mc => mc.Category.category_name);

                    // Concatenate the category names into a single string separated by commas
                    return string.Join(", ", categoryNames);
                }
            }

            // Return an empty string if the input is invalid or no categories are found
            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
