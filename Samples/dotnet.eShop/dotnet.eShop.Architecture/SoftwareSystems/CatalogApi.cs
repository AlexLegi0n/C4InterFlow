// <auto-generated/>
using C4InterFlow.Elements;
using C4InterFlow.Elements.Interfaces;
using C4InterFlow.Elements.Relationships;

namespace dotnet.eShop.Architecture.SoftwareSystems
{
    public partial class CatalogApi : ISoftwareSystemInstance
    {
        private static readonly string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.CatalogApi";
        public static SoftwareSystem Instance => new SoftwareSystem(ALIAS, "Catalog Api")
        {
            Description = "",
            Boundary = Boundary.Internal
        };

        public partial class Containers
        {
        }

        public partial class Interfaces
        {
        }
    }
}