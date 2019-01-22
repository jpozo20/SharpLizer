using SharpLizer.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharpLizer.Configuration.Settings
{
    internal class CategorySettings : NotifiesPropertyChanged
    {
        private ObservableCollection<CategoryItemDecorationSettings> _childrenColorSettings;
        private string _displayName;

        public CategorySettings()
        {
            ChildrenColorSettings = new ObservableCollection<CategoryItemDecorationSettings>();
        }
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CategoryItemDecorationSettings> ChildrenColorSettings
        {
            get { return _childrenColorSettings; }
            set { _childrenColorSettings = value;
                OnPropertyChanged();
            }
        }
    }
}