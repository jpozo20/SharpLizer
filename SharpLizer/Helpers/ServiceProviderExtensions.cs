using Microsoft.VisualStudio.ComponentModelHost;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

namespace SharpLizer.Helpers
{
    internal static class ServiceProviderExtensions
    {
        internal static void SatisfyImportsOnce(this IServiceProvider serviceProvider, object objectToCompose)
        {
            IComponentModel compositionService = Common.Instances.CompositionService;
            if (compositionService == null)
            {
                compositionService = serviceProvider.GetService<SComponentModel, IComponentModel>();
            }

            if (compositionService != null)
            {
                compositionService.DefaultCompositionService.SatisfyImportsOnce(objectToCompose);
            }
        }

        private static T GetService<T>(this IServiceProvider serviceProvider) where T : class
        {
            return serviceProvider.GetService(typeof(T)) as T;
        }

        private static TReturn GetService<TGet, TReturn>(this IServiceProvider serviceProvider)
            where TGet : class
            where TReturn : class
        {
            return serviceProvider.GetService(typeof(TGet)) as TReturn;
        }
    }
}