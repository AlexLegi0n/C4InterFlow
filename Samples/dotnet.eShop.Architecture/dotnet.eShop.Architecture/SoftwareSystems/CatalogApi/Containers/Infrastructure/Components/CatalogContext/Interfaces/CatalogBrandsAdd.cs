// <auto-generated/>
using C4InterFlow.Elements;
using C4InterFlow.Elements.Interfaces;
using C4InterFlow.Elements.Relationships;

namespace dotnet.eShop.Architecture.SoftwareSystems
{
    public partial class CatalogApi
    {
        public partial class Containers
        {
            public partial class Infrastructure
            {
                public partial class Components
                {
                    public partial class CatalogContext
                    {
                        public partial class Interfaces
                        {
                            public partial class CatalogBrandsAdd : IInterfaceInstance
                            {
                                public const string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.Interfaces.CatalogBrandsAdd";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.ALIAS, ALIAS, "Catalog Brands Add")
                                {
                                    Description = "",
                                    Path = "",
                                    IsPrivate = false,
                                    Protocol = "",
                                    Flow = new Flow(ALIAS),
                                    Input = "",
                                    InputTemplate = "",
                                    Output = "",
                                    OutputTemplate = ""
                                };
                            }
                        }
                    }
                }
            }
        }
    }
}