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
            public partial class Data
            {
                public partial class Components
                {
                    public partial class RedisBasketRepository
                    {
                        public partial class Interfaces
                        {
                            public partial class GetBasketKey : IInterfaceInstance
                            {
                                public const string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Data.Components.RedisBasketRepository.Interfaces.GetBasketKey";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Data.Components.RedisBasketRepository.ALIAS, ALIAS, "Get Basket Key")
                                {
                                    Description = "",
                                    Path = "",
                                    IsPrivate = true,
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