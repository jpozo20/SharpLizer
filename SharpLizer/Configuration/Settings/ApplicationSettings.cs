using System.Collections.Generic;

namespace SharpLizer.Configuration.Settings
{
    internal class ApplicationSettings
    {
        public ApplicationSettings()
        {
            ColorSettings = new List<CategorySettings>();
        }

        public IEnumerable<CategorySettings> ColorSettings { get; set; }
    }
}