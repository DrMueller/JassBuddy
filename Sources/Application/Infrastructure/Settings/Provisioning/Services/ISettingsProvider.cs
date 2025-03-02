using Mmu.JassBuddy2.Infrastructure.Settings.Provisioning.Models;

namespace Mmu.JassBuddy2.Infrastructure.Settings.Provisioning.Services
{
    public interface ISettingsProvider
    {
        AppSettings AppSettings { get; }
    }
}