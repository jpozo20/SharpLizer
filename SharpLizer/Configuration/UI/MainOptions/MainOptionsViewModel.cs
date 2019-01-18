using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Formatting;
using SharpLizer.Classification;
using SharpLizer.Configuration.Json;
using SharpLizer.Configuration.Settings;
using SharpLizer.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class MainOptionsViewModel : NotifiesPropertyChanged
    {
        [Import(Common.Constants.CLASSIFIERPROVIDER_EXPORT_NAME)]
        internal IClassifierProvider _classifierProvider;

        private readonly SettingsLoader _settingsLoader;
        private IEnumerable<IClassificationType> _classificationTypes;
        private IClassificationFormatMap _formatMap;

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
            BatchUpdateColors();
        }

        internal void LoadSettings()
        {
            var settings = _settingsLoader.LoadSettings();
            if (settings.Count == 0) return;

            Categories = new ObservableCollection<CategorySettings>(settings);
        }

        internal void RemoveChangesFlagFromItems()
        {
            Categories.ForEach(category => category.ChildrenColorSettings.ForEach(colorSetting => colorSetting.HasChanges = false));
        }

        internal void LoadClassificationTypes()
        {
            var provider = _classifierProvider as ClassifierProvider;
            if (provider == null) return;

            _formatMap = provider.GetFormatMapService().GetClassificationFormatMap("csharp");
            _classificationTypes = _formatMap.CurrentPriorityOrder.Where(x => x?.Classification.Contains("SharpLizer") == true).ToList();
        }

        private void BatchUpdateColors()
        {
            var changedItems = Categories
                    .Where(category => category.ChildrenColorSettings.Any(x => x.HasChanges))
                    .SelectMany(category => category.ChildrenColorSettings)
                    .Where(colorSetting => colorSetting.HasChanges).ToList();

            try
            {
                _formatMap.BeginBatchUpdate();

                foreach (CategoryItemDecorationSettings changedItem in changedItems)
                {
                    var classificationKey = changedItem.DisplayName.Replace(" ", "");
                    var classificationType = _classificationTypes.FirstOrDefault(x => x.Classification.Contains(classificationKey));
                    if (classificationType == null) continue;

                    var textProperties = _formatMap.GetTextProperties(classificationType);
                    UpdateTextProperties(changedItem, textProperties);

                    _formatMap.SetExplicitTextProperties(classificationType, textProperties);
                }
            }
            catch (Exception)
            {
                //TO-DO: Log exception
            }
            finally
            {
                _formatMap.EndBatchUpdate();
            }
        }

        private void UpdateTextProperties(CategoryItemDecorationSettings colorSetting, TextFormattingRunProperties textFormatting)
        {
            textFormatting.SetBackground(colorSetting.BackgroundColor);
            textFormatting.SetForeground(colorSetting.ForegroundColor);
            textFormatting.SetBold(colorSetting.IsBold);
            textFormatting.SetItalic(colorSetting.IsItalic);
            if (colorSetting.IsUnderlined) textFormatting.TextDecorations.Add(TextDecorations.Underline);
            if (colorSetting.HasStrikethrough) textFormatting.TextDecorations.Add(TextDecorations.Strikethrough);
        }
    }
}