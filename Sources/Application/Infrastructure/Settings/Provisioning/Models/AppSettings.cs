using JetBrains.Annotations;

namespace Mmu.JassBuddy2.Infrastructure.Settings.Provisioning.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";

        public string ComputerVisionApiKey { get; set; } = default!;
        public string ComputerVisionEndpoint { get; set; } = default!;
    }
}