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
        private bool _hasChanges;

        public string DisplayName { get; set; }

        public Color ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                if (value != _foregroundColor)
                {
                    _foregroundColor = value;
                    OnPropertyChanged();
                    this.HasChanges = true;
                }
            }
        }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (value != _backgroundColor)
                {
                    _backgroundColor = value;
                    OnPropertyChanged();
                    this.HasChanges = true;
                }
            }
        }

        public bool IsBold
        {
            get { return _isBold; }
            set
            {
                if (value != _isBold)
                {
                    _isBold = value;
                    OnPropertyChanged();
                    this.HasChanges = true;
                }
            }
        }

        public bool IsItalic
        {
            get { return _isItalic; }
            set
            {
                if (_isItalic != value)
                {
                    _isItalic = value;
                    OnPropertyChanged();
                    this.HasChanges = true;
                }
            }
        }

        public bool IsUnderlined
        {
            get { return _isUnderlined; }
            set
            {
                if (value != _isUnderlined)
                {
                    _isUnderlined = value;
                    OnPropertyChanged();
                    this.HasChanges = true;
                }
            }
        }

        public bool HasStrikethrough
        {
            get { return _hasStrikethrough; }
            set
            {
                if (value != _hasStrikethrough)
                {
                    _hasStrikethrough = value;
                    OnPropertyChanged();
                    this.HasChanges = true;
                }
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                _hasChanges = value;
                OnPropertyChanged();
            }
        }
    }
}