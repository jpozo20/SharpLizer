using Microsoft.VisualStudio.Shell;
using System;
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

        // When the user presses the OK button
        protected override void OnApply(PageApplyEventArgs e)
        {
            base.OnApply(e);
            var pageControl = Child as OptionsPageControl;
            if (pageControl != null) pageControl.ShouldSaveChanges = true;
        }
    }
}
