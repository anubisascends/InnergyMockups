using Mockups.Models;
using System.Globalization;
using System.Windows.Data;

namespace Mockups.Components
{
    public class MachineAssignmentsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var machines = Machine.DefaultMachines;

            if(value is IEnumerable<int> ids)
            {
                return string.Join(", ", Machine.DefaultMachines.Where(x => ids.Contains(x.Id)).Select(y => y.Name));
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
