using System.Windows.Media;

namespace SharpLizer.Configuration.Settings
{
    internal class ColorInfo
    {
        internal ColorInfo()
        {
        }

        internal ColorInfo(string displayName, Color color)
        {
            this.DisplayName = displayName;
            this.Color = color;
        }

        public string DisplayName { get; set; }
        public Color Color { get; set; }
    }
}