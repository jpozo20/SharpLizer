using Microsoft.VisualStudio.ComponentModelHost;
using SharpLizer.Configuration.Settings;
using System;

namespace SharpLizer.Common
{
    internal static class Instances
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IComponentModel CompositionService { get; set; }
        public static ApplicationSettings ApplicationSettings { get; set; }
    }
}