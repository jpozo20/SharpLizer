using System.Collections.Generic;

namespace SharpLizer.Configuration.Settings
{
    internal class CategorySettings
    {
        public CategorySettings()
        {
            ChildrenColorSettings = new List<ColorSettings>();
        }
        public string DisplayName { get; set; }
        public IList<ColorSettings> ChildrenColorSettings {get;set;}        
    }
}