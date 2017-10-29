using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Admin
{
    class CellBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = value as string;

            int number;
            int.TryParse(str, out number);

            if (number == 0) return Brushes.Red;
            if (number <= 2) return Brushes.Tomato;
            if (number <= 4) return Brushes.Gold;
            if (number <= 7) return Brushes.Yellow;

            return Brushes.White;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
