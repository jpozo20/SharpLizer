using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Text.Formatting;
using SharpLizer.Configuration.Settings;
using System;
using System.Collections.Generic;

namespace SharpLizer.Common
{
    internal static class Instances
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IComponentModel CompositionService { get; set; }
        public static ApplicationSettings ApplicationSettings { get; set; }
        public static IDictionary<string, TextFormattingRunProperties> DefaultClassificationColors { get; set; }
    }
}