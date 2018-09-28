using System.Windows.Media;

namespace SharpLizer.Configuration.Settings
{
    internal class BaseSettings
    {
        public string DisplayName { get; set; }
        public Color ForegroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderlined { get; set; }
        public bool HasStrikethrough { get; set; }
    }
}
