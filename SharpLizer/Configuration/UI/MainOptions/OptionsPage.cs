using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace SharpLizer.Configuration.UI.MainOptions
{
    public class OptionsPage : UIElementDialogPage
    {
        protected override UIElement Child { get { return new OptionsPageControl(); } }
    }
}
