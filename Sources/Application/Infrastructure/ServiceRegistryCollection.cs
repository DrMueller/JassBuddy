using JetBrains.Annotations;
using Lamar;

namespace Mmu.JassBuddy2.Infrastructure
{
    [UsedImplicitly]
    public class ServiceRegistryCollection : ServiceRegistry
    {
        public ServiceRegistryCollection()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<ServiceRegistryCollection>();
                scanner.WithDefaultConventions();
            });
        }
    }
}