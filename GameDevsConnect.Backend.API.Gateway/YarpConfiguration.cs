using Yarp.ReverseProxy.Configuration;

namespace GameDevsConnect.Backend.API.Gateway
{
    public class YarpConfiguration(int apiVersion, string gateway, string azure, string file, string notification, string project, string profile, string post, string tag, string user, string access_key, bool development)
    {
        private readonly string _gateway = gateway;
        private readonly string _azure = azure;
        private readonly string _file = file;
        private readonly string _notification = notification;
        private readonly string _project = project;
        private readonly string _profile = profile;
        private readonly string _post = post;
        private readonly string _tag = tag;
        private readonly string _user = user;
        private readonly string access_Key = access_key;
        private readonly bool _development = development;

        public RouteConfig[] Routes => GetRoutes();
        public ClusterConfig[] Clusters => GetClusters();

        public RouteConfig[] GetRoutes()
        {
            var transforms = new List<Dictionary<string, string>>
            {
                new() {
                    { "RequestHeader", "X-Access-Key" },
                    { "Set", access_Key ?? "" }
            }};

            string authPolicy = _development ? "anonymous" : "default";

            return
            [
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/azure",
                    ClusterId = "api-azure-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/azure/{{**catch-all}}",
                    },
                    Transforms = transforms,
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/file",
                    ClusterId = "api-file-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/file/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/notification",
                    ClusterId = "api-notification-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/notification/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/project",
                    ClusterId = "api-project-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/project/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/profile",
                    ClusterId = "api-profile-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/profile/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/post",
                    ClusterId = "api-post-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/post/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/tag",
                    ClusterId = "api-tag-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/tag/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = $"{_gateway}/api/v{apiVersion}/user",
                    ClusterId = "api-user-cluster",
                    AuthorizationPolicy = authPolicy,
                    Match = new RouteMatch
                    {
                        Path = $"api/v{apiVersion}/user/{{**catch-all}}"
                    },
                    Transforms = transforms
                },
            ];
        }

        public ClusterConfig[] GetClusters()
        {
            return
                [
                    new ClusterConfig
                    {
                        ClusterId = "api-azure-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _azure
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-file-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _file
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-notification-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _notification
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-project-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _project
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-profile-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _profile
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-post-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _post
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-tag-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _tag
                                }
                            }
                        }
                    },
                    new ClusterConfig
                    {
                        ClusterId = "api-user-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _user
                                }
                            }
                        }
                    }
                ];
        }
    }
}
