using SharpLizer.Helpers;
using System.Windows.Media;

namespace SharpLizer.Configuration.Settings
{
    internal class BaseSettings : NotifiesPropertyChanged
    {
        private Color _foregroundColor;
        private Color _backgroundColor;
        private bool _isBold;
        private bool _isItalic;
        private bool _isUnderlined;
        private bool _hasStrikethrough;

        public string DisplayName { get; set; }
        public Color ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                OnPropertyChanged();
            }
        }
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }
        public bool IsBold
        {
            get { return _isBold; }
            set
            {
                _isBold = value;
                OnPropertyChanged();
            }
        }
        public bool IsItalic
        {
            get { return _isItalic; }
            set
            {
                _isItalic = value;
                OnPropertyChanged();
            }
        }
        public bool IsUnderlined
        {
            get { return _isUnderlined; }
            set
            {
                _isUnderlined = value;
                OnPropertyChanged();
            }
        }
        public bool HasStrikethrough
        {
            get { return _hasStrikethrough; }
            set
            {
                _hasStrikethrough = value;
                OnPropertyChanged();
            }
        }
    }
}