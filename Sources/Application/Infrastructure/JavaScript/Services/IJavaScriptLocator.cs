using Microsoft.AspNetCore.Components;

namespace Mmu.JassBuddy2.Infrastructure.JavaScript.Services
{
    public interface IJavaScriptLocator
    {
        Task<string> LocateJsFilePathAsync(ComponentBase comp);
    }
}