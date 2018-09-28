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

        private IEnumerable<CategorySettings> _categories;
        public IEnumerable<CategorySettings> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value, nameof(Categories)); }
        }

        private ColorSettings _selectedColorSettings;
        public ColorSettings SelectedColorSettings
        {
            get { return _selectedColorSettings; }
            set { SetProperty(ref _selectedColorSettings, value, nameof(SelectedColorSettings)); }
        }


        IEnumerable<CategorySettings> LoadCategories()
        {
            var categoriesList = new Collection<CategorySettings>();

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
