using Microsoft.VisualStudio.Shell;
using System.Windows;

namespace SharpLizer.Configuration.UI.MainOptions
{
    public class OptionsPage : UIElementDialogPage
    {
        private UIElement _child;

        protected override UIElement Child
        {
            get
            {
                if (_child == null) _child = new OptionsPageControl();
                return _child;
            }
        }

        // When the user presses the OK button
        protected override void OnApply(PageApplyEventArgs e)
        {
            base.OnApply(e);
            var pageControl = Child as OptionsPageControl;
            if (pageControl != null)
            {
                pageControl.ShouldSaveChanges = true;
            }
        }
    }
}