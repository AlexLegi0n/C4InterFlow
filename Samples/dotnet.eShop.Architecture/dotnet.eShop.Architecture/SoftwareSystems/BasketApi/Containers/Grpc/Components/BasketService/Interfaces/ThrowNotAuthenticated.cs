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
            public partial class Grpc
            {
                public partial class Components
                {
                    public partial class BasketService
                    {
                        public partial class Interfaces
                        {
                            public partial class ThrowNotAuthenticated : IInterfaceInstance
                            {
                                public const string ALIAS = "dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Grpc.Components.BasketService.Interfaces.ThrowNotAuthenticated";
                                public static Interface Instance => new Interface(dotnet.eShop.Architecture.SoftwareSystems.BasketApi.Containers.Grpc.Components.BasketService.ALIAS, ALIAS, "Throw Not Authenticated")
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