// <auto-generated/>
using C4PlusSharp.Elements;
using C4PlusSharp.Elements.Interfaces;
using C4PlusSharp.Elements.Relationships;

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
                            public partial class SaveChangesAsync : IInterfaceInstance
                            {
                                public const string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.Interfaces.SaveChangesAsync";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.ALIAS, ALIAS, "Save Changes Async")
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