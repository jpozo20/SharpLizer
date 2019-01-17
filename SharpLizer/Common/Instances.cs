using Microsoft.VisualStudio.ComponentModelHost;
using System;

namespace SharpLizer.Common
{
    internal static class Instances
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IComponentModel CompositionService { get; set; }
    }
}