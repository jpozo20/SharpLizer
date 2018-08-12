using System.Collections.Generic;

namespace SharpLizer.Configuration
{
    internal class CategorySettings : BaseSettings
    {
        public IList<ColorSettings> ChildrenColorSettings {get;set;}
        
    }
}
