// <auto-generated/>
using C4PlusSharp.Elements;
using C4PlusSharp.Elements.Interfaces;
using C4PlusSharp.Elements.Relationships;

namespace dotnet.eShop.Architecture.SoftwareSystems
{
    public partial class BasketApi
    {
        public partial class Containers
        {
            public partial class Grpc
            {
                public partial class Components
                {
                    public partial class BasketService
                    {
                        public partial class Interfaces
                        {
                            public partial class DeleteBasket : IInterfaceInstance
                            {
                                public const string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Grpc.Components.BasketService.Interfaces.DeleteBasket";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Grpc.Components.BasketService.ALIAS, ALIAS, "Delete Basket")
                                {
                                    Description = "",
                                    Path = "",
                                    IsPrivate = false,
                                    Protocol = "",
                                    Flow = new Flow(ALIAS)
                                    	.If(@"string.IsNullOrEmpty(userId)")
                                    		.Use("dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Grpc.Components.BasketService.Interfaces.ThrowNotAuthenticated")
                                    	.EndIf()
                                    	.Use("dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Data.Components.RedisBasketRepository.Interfaces.DeleteBasketAsync"),
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