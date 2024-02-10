// <auto-generated/>
using C4InterFlow.Elements;
using C4InterFlow.Elements.Interfaces;
using C4InterFlow.Elements.Relationships;

namespace dotnet.eShop.Architecture.SoftwareSystems
{
    public partial class BasketApi
    {
        public partial class Containers
        {
            public partial class Data
            {
                public partial class Components
                {
                    public partial class RedisBasketRepository
                    {
                        public partial class Interfaces
                        {
                            public partial class DeleteBasketAsync : IInterfaceInstance
                            {
                                private static readonly string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Data.Components.RedisBasketRepository.Interfaces.DeleteBasketAsync";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Data.Components.RedisBasketRepository.ALIAS, ALIAS, "Delete Basket Async")
                                {
                                    Description = "",
                                    Path = "",
                                    IsPrivate = false,
                                    Protocol = "",
                                    Flow = new Flow(ALIAS)
                                    	.Use("dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Data.Components.RedisDatabase.Interfaces.KeyDeleteAsync"),
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