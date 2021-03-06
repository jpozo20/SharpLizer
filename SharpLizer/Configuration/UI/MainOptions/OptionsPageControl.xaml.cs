﻿using SharpLizer.Configuration.Settings;
using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using SharpLizer.Helpers;

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

        public bool ShouldSaveChanges { get; set; }

        private MainOptionsViewModel ViewModel => (MainOptionsViewModel) Resources["ViewModel"];

        private void ListViews_SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            // Remove selection from the other lists only if this is a selection
            // and not a deselection
            if (e.AddedItems.Count > 0) {
                ClearSelection(sender as ListView);
                ViewModel.SelectedColorSettings = e.AddedItems[0] as CategoryItemDecorationSettings;
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

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // If the user hits the OK button, save the settings
            if (ShouldSaveChanges)
            {
                ViewModel.SaveSettings();
                ViewModel.BatchUpdateColors();
                ShouldSaveChanges = false;
            }
            else
            {
                // Otherwise,revert the changes by 
                // assigning the original view model on cancel
                ViewModel.Categories = ViewModel.RevertableCategories;
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Create a deep copy of the Settings so we can revert them on cancel
            if (ViewModel.Categories != ViewModel.RevertableCategories)
            {
                ViewModel.RevertableCategories = ViewModel.Categories.JsonClone();
                ViewModel.RemoveChangesFlagFromItems();
            }
        }
    }
}
