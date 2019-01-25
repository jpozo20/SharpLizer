using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Shell.Interop;
using SharpLizer.Classification;
using SharpLizer.Configuration.Json;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Media;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class MainOptionsViewModel : NotifiesPropertyChanged
    {
#pragma warning disable 649

        [Import]
        private TextViewColorizersManager _textViewsManager;

        [Import]
        private SettingsLoader _settingsLoader;

#pragma warning restore 649

        private ApplicationSettings _settings;

        public MainOptionsViewModel()
        {
            DefaultColors = GetSystemColors();
            InitializeCategories();
            SatisfyImports();

            RestoreDefaultsCommand = new RelayCommand(RestoreDefaults);

        }

        private void InitializeCategories()
        {
            if (Common.Instances.ApplicationSettings.ColorSettings.Any())
            {
                Categories = new ObservableCollection<CategorySettings>(Common.Instances.ApplicationSettings.ColorSettings);
            }
            else
            {
                Categories = LoadCategories();
                Common.Instances.ApplicationSettings.ColorSettings = Categories;
            }
        }

        private void SatisfyImports()
        {
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

        public ObservableCollection<CategorySettings> RevertableCategories { get; set; }

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

            var defaultColor = new ColorInfo("Default", default(Color));
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

            colors.Insert(0, defaultColor);
            return colors;
        }

        private RelayCommand _restoreDefaultsCommand;

        public RelayCommand RestoreDefaultsCommand
        {
            get { return _restoreDefaultsCommand; }
            set { _restoreDefaultsCommand = value; }
        }

        internal void SaveSettings()
        {
            Common.Instances.ApplicationSettings.ColorSettings = Categories;
            _settingsLoader.SaveSettings(Common.Instances.ApplicationSettings);
        }

        internal void LoadSettings()
        {
            _settings = _settingsLoader.LoadSettings();
            if (_settings == null || _settings.ColorSettings == null)
            {
                Categories = LoadCategories();
            }
            else
            {
                Categories = new ObservableCollection<CategorySettings>(_settings.ColorSettings);
            }
        }

        internal void RemoveChangesFlagFromItems()
        {
            Categories.ForEach(category => category.ChildrenColorSettings.ForEach(colorSetting => colorSetting.HasChanges = false));
        }

        public void BatchUpdateColors()
        {
            if (_textViewsManager == null) return;
            IEnumerable<CategoryItemDecorationSettings> changedItems = GetChangedItems();
            if (!changedItems.Any()) return;

            foreach (TextViewColorizer colorizer in _textViewsManager.GetColorizers())
            {
                colorizer.UpdateColors(changedItems);
            }
        }

        public void RestoreDefaults()
        {
            var settings = Categories.SelectMany(x => x.ChildrenColorSettings).ToList();
            settings.ForEach(setting => setting.Reset());
        }

        private IEnumerable<CategoryItemDecorationSettings> GetChangedItems()
        {
            return Categories
                    .Where(category => category.ChildrenColorSettings.Any(x => x.HasChanges))
                    .SelectMany(category => category.ChildrenColorSettings)
                    .Where(colorSetting => colorSetting.HasChanges).ToList();
        }
    }
}