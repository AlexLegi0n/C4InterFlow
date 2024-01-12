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
            public partial class Api
            {
                public partial class Components
                {
                    public partial class CatalogApi
                    {
                        public partial class Interfaces
                        {
                            public partial class DeleteItemById : IInterfaceInstance
                            {
                                public const string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Api.Components.CatalogApi.Interfaces.DeleteItemById";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Api.Components.CatalogApi.ALIAS, ALIAS, "Delete Item By Id")
                                {
                                    Description = "",
                                    Path = "",
                                    IsPrivate = false,
                                    Protocol = "",
                                    Flow = new Flow(ALIAS)
                                    	.Use("dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.Interfaces.CatalogItemsSingleOrDefault")
                                    	.If(@"item is null")
                                    		.Return(@"TypedResults.NotFound")
                                    	.EndIf()
                                    	.Use("dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.Interfaces.CatalogItemsRemove")
                                    	.Use("dotnet.eShop.Architecture.SoftwareSystems.CatalogApi.Containers.Infrastructure.Components.CatalogContext.Interfaces.SaveChangesAsync")
                                    	.Return(@"TypedResults.NoContent"),
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