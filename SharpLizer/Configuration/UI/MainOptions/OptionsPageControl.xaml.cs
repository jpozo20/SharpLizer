using SharpLizer.Classification;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SharpLizer.Configuration.UI.MainOptions
{
    /// <summary>
    /// Interaction logic for OptionsPageControl.xaml
    /// </summary>
    public partial class OptionsPageControl : UserControl
    {
        public OptionsPageControl()
        {
            InitializeComponent();
            
        }

        private MainOptionsViewModel ViewModel => (MainOptionsViewModel) Resources["ViewModel"];
                

        private void ListViews_SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            // Remove selection from the other lists only if this is a selection
            // and not a deselection
            if (e.AddedItems.Count > 0) {
                //ClearSelection(sender as ListView);
                ViewModel.SelectedColorSettings = e.AddedItems[0] as ColorSettings;
            }

        }

        void ClearSelection(ListView selectedListView)
        {
            foreach (var item in ItemsList.Items)
            {
                var contentPresenter = ItemsList.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
                var grid = VisualTreeHelper.GetChild(contentPresenter, 0) as Grid;
                var expander = grid.Children[0] as Expander;
                var expanderGrid = expander.Content as Grid;

                var listView = expanderGrid.Children[0] as ListView;
                if (listView == selectedListView) continue;
                listView.SelectedItem = null;
            }
        }
    }
}
