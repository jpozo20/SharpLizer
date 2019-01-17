using Microsoft.VisualStudio.Text.Classification;
using SharpLizer.Classification;
using SharpLizer.Configuration.Json;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Reflection;
using System.Windows.Media;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class MainOptionsViewModel : NotifiesPropertyChanged
    {
        [Import(Common.Constants.CLASSIFIERPROVIDER_EXPORT_NAME)]
        internal IClassifierProvider _classifierProvider;

        private readonly SettingsLoader _settingsLoader;

        public MainOptionsViewModel()
        {
            Categories = LoadCategories();
            DefaultColors = GetSystemColors();
            _settingsLoader = new SettingsLoader();

            if (Common.Instances.ServiceProvider != null)
            {
                Common.Instances.ServiceProvider.SatisfyImportsOnce(this);
            }
        }

        private ObservableCollection<CategorySettings> _categories;

        public ObservableCollection<CategorySettings> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        private CategoryItemDecorationSettings _selectedColorSettings;

        public CategoryItemDecorationSettings SelectedColorSettings
        {
            get => _selectedColorSettings;
            set
            {
                _selectedColorSettings = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<ColorInfo> _defaultColors;

        public IEnumerable<ColorInfo> DefaultColors
        {
            get => _defaultColors;
            set
            {
                _defaultColors = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CategorySettings> LoadCategories()
        {
            ObservableCollection<CategorySettings> categoriesList = new ObservableCollection<CategorySettings>();

            Type categoryClass = typeof(ClassificationTypes);
            Type[] categories = categoryClass.GetNestedTypes();
            foreach (Type category in categories)
            {
                CategorySettings categorySetting = new CategorySettings
                {
                    DisplayName = category.Name.Replace("Types", "")
                };

                System.Reflection.FieldInfo[] categoryItems = category.GetFields();
                foreach (System.Reflection.FieldInfo item in categoryItems)
                {
                    CategoryItemDecorationSettings colorSetting = new CategoryItemDecorationSettings
                    {
                        DisplayName = item.Name.SpliByCapitalLetters()
                    };
                    categorySetting.ChildrenColorSettings.Add(colorSetting);
                }

                categoriesList.Add(categorySetting);
            }

            return categoriesList;
        }

        private IEnumerable<ColorInfo> GetSystemColors()
        {
            Collection<ColorInfo> colors = new Collection<ColorInfo>();
            Type colorType = typeof(System.Windows.Media.Colors);
            System.Reflection.PropertyInfo[] colorsProps = colorType.GetProperties();
            foreach (System.Reflection.PropertyInfo colorProp in colorsProps)
            {
                Color color = (Color)colorProp.GetValue(null, null);

                ColorInfo colorItem = new ColorInfo
                {
                    DisplayName = colorProp.Name,
                    Color = color
                };
                colors.Add(colorItem);
            }

            return colors;
        }

        internal void SaveSettings()
        {
            _settingsLoader.SaveSettings(Categories);
        }

        internal void LoadSettings()
        {
            var settings = _settingsLoader.LoadSettings();
            if (settings.Count > 0)
            {
                Categories = new ObservableCollection<CategorySettings>(settings);
            }
        }
    }
}