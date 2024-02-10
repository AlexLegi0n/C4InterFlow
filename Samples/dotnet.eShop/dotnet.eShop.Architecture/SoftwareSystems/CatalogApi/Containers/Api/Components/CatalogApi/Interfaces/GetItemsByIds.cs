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
            public partial class Api
            {
                public partial class Components
                {
                    public partial class CatalogApi
                    {
                        public partial class Interfaces
                        {
                            public partial class GetItemsByIds : IInterfaceInstance
                            {
                                private static readonly string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Api.Components.CatalogApi.Interfaces.GetItemsByIds";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Api.Components.CatalogApi.ALIAS, ALIAS, "Get Items By Ids")
                                {
                                    Description = "",
                                    Path = "",
                                    IsPrivate = false,
                                    Protocol = "",
                                    Flow = new Flow(ALIAS)
                                    	.Use("dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.Interfaces.CatalogItemsToListAsync")
                                    	.Return(@"TypedResults.Ok"),
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