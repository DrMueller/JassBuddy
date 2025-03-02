using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace Mmu.JassBuddy2.Infrastructure.JavaScript.Services.Implementation
{
    [UsedImplicitly]
    public class JavaScriptLocator : IJavaScriptLocator
    {
        public Task<string> LocateJsFilePathAsync(ComponentBase comp)
        {
            var type = comp.GetType();

            var assemblyFullName = type.Assembly.FullName;
            var assemblyName = type.Assembly.FullName!.Substring(0, assemblyFullName!.IndexOf(','));
            var relativeNamespace = type.FullName!.Replace(assemblyName, string.Empty);

            if (type.IsGenericType)
            {
                relativeNamespace = relativeNamespace.Substring(0, relativeNamespace.IndexOf('`'));
            }

            var path = relativeNamespace.Replace(".", "/");
            path += ".razor.js";

            return Task.FromResult(path);
        }
    }
}