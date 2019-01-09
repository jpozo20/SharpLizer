using SharpLizer.Classification;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class MainOptionsViewModel : NotifiesPropertyChanged
    {

        public MainOptionsViewModel()
        {
            Categories = LoadCategories();
        }

        private ObservableCollection<CategorySettings> _categories;
        public ObservableCollection<CategorySettings> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        private ColorSettings _selectedColorSettings;
        public ColorSettings SelectedColorSettings
        {
            get { return _selectedColorSettings; }
            set {
                _selectedColorSettings = value;
                OnPropertyChanged();
            }
        }


        ObservableCollection<CategorySettings> LoadCategories()
        {
            var categoriesList = new ObservableCollection<CategorySettings>();

            var categoryClass = typeof(ClassificationTypes);
            var categories = categoryClass.GetNestedTypes();
            foreach (var category in categories)
            {
                var categorySetting = new CategorySettings();
                categorySetting.DisplayName = category.Name.Replace("Types", "");

                var categoryItems = category.GetFields();
                foreach (var item in categoryItems)
                {
                    var colorSetting = new ColorSettings();
                    colorSetting.DisplayName = item.Name.SpliByCapitalLetters();
                    categorySetting.ChildrenColorSettings.Add(colorSetting);
                }

                categoriesList.Add(categorySetting);
            }

            return categoriesList;
        }
    }
}
