using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Mockups.Components
{
    public class MyDataGrid : DataGrid
    {

        public IEnumerable<object> BindableSelectedItems
        {
            get { return (IEnumerable<object>)GetValue(BindableSelectedItemsProperty); }
            set { SetValue(BindableSelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BindableSelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindableSelectedItemsProperty = DependencyProperty.Register("BindableSelectedItems", typeof(IEnumerable<object>), typeof(MyDataGrid), new PropertyMetadata(Array.Empty<object>()));


        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            BindableSelectedItems = SelectedItems.Cast<object>().ToList();
        }
    }
}
