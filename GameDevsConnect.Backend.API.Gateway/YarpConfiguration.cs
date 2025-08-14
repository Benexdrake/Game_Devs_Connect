using Yarp.ReverseProxy.Forwarder;

namespace GameDevsConnect.Backend.API.Gateway;
public class YarpConfiguration(int apiVersion, string gateway, APIEndpoint[] apis , string access_key, bool development, ApiMode apiMode)
{
    private readonly string _gateway = gateway;
    private readonly APIEndpoint[] _apis = apis;
    private readonly string access_Key = access_key;
    private readonly bool _development = development;
    private readonly ApiMode _apiMode = apiMode;

    public RouteConfig[] Routes => GetRoutes();
    public ClusterConfig[] Clusters => GetClusters();

    public RouteConfig[] GetRoutes()
    {
        var routeConfigs = new List<RouteConfig>();

        foreach (var api in _apis)
        {
            // http
            if(_apiMode == ApiMode.Both || _apiMode == ApiMode.HTTP)
                routeConfigs.Add(
                    new RouteConfig
                    {
                        RouteId = $"{_gateway}/api/v{apiVersion}/{api.Name}",
                        ClusterId = $"api-{api.Name}-cluster",
                        AuthorizationPolicy = _development ? "anonymous" : "default",
                        Match = new RouteMatch
                        {
                            Path = $"api/v{apiVersion}/{api.Name}/{{**catch-all}}",
                        },
                        Transforms = new List<Dictionary<string, string>>
                                     { new() { { "RequestHeader", "X-Access-Key" }, { "Set", access_Key ?? "" }} }
                    }
                );

            // grpc
            if (_apiMode == ApiMode.Both || _apiMode == ApiMode.gRPC)
                routeConfigs.Add(
                    new RouteConfig
                    {
                        RouteId = $"{_gateway}/grpc/{api.Name}",
                        ClusterId = $"grpc-{api.Name}-cluster",
                        AuthorizationPolicy = _development ? "anonymous" : "default",
                        Match = new RouteMatch
                        {
                            Path = $"grpc/{api.Name}/{{**catch-all}}",
                        },
                        Transforms = new List<Dictionary<string, string>>
                                     { new() { { "RequestHeader", "X-Access-Key" }, { "Set", access_Key ?? "" }} }
                    }
                );
        }

        return [.. routeConfigs];
    }

    public ClusterConfig[] GetClusters()
    {
        var clusterConfigs = new List<ClusterConfig>();

        foreach( var api in _apis)
        {
            //http
            clusterConfigs.Add(new ClusterConfig
            {
                ClusterId = $"api-{api.Name}-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    {
                        "1", new DestinationConfig
                        {
                            Address = api.Url
                        }
                    }
                }
            });

            //grpc
            clusterConfigs.Add(new ClusterConfig
            {
                ClusterId = $"grpc-{api.Name}-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    {
                        "1", new DestinationConfig
                        {
                            Address = api.Url
                        }
                    }
                },
                HttpRequest = new ForwarderRequestConfig
                {
                    Version = new Version(2, 0) // Erzwingt HTTP/2
                }
            });
        }

        return [.. clusterConfigs];
    }
}
