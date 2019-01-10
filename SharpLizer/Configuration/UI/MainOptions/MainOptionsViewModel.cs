using SharpLizer.Classification;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class MainOptionsViewModel : NotifiesPropertyChanged
    {

        public MainOptionsViewModel()
        {
            Categories = LoadCategories();
            DefaultColors = GetColors();
        }

        private ObservableCollection<CategorySettings> _categories;
        public ObservableCollection<CategorySettings> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        private CategoryItemDecorationSettings _selectedColorSettings;
        public CategoryItemDecorationSettings SelectedColorSettings
        {
            get { return _selectedColorSettings; }
            set {
                _selectedColorSettings = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<ColorInfo> _defaultColors;
        public IEnumerable<ColorInfo> DefaultColors
        {
            get { return _defaultColors; }
            set {
                _defaultColors = value;
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
                    var colorSetting = new CategoryItemDecorationSettings();
                    colorSetting.DisplayName = item.Name.SpliByCapitalLetters();
                    categorySetting.ChildrenColorSettings.Add(colorSetting);
                }

                categoriesList.Add(categorySetting);
            }

            return categoriesList;
        }
        IEnumerable<ColorInfo> GetColors()
        {
            var colors = new Collection<ColorInfo>();
            var colorType = typeof(System.Windows.Media.Colors);
            var colorsProps = colorType.GetProperties();
            foreach (var colorProp in colorsProps)
            {
                var color = (Color)colorProp.GetValue(null, null);

                var colorItem = new ColorInfo();
                colorItem.DisplayName = colorProp.Name;
                colorItem.Color = color;
                colors.Add(colorItem);
            }

            return colors;
        }
    }
}
