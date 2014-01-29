using System;
namespace BootstrapConfig.Configuration
{
    public interface IDirectorySearcherConfiguration : ITypeContainerConfiguration
    {
        string Path { get; set; }
        bool Recursive { get; set; }
        string SearchPattern { get; set; }
    }
}
