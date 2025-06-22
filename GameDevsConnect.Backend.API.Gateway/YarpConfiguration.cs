using Yarp.ReverseProxy.Configuration;

namespace GameDevsConnect.Backend.API.Gateway
{
    public class YarpConfiguration(string azure, string comment, string file, string notification, string project, string profile, string request, string tag, string user, string access_key)
    {
        private readonly string _azure = azure;
        private readonly string _comment = comment;
        private readonly string _file = file;
        private readonly string _notification = notification;
        private readonly string _project = project;
        private readonly string _profile = profile;
        private readonly string _request = request;
        private readonly string _tag = tag;
        private readonly string _user = user;
        private readonly string access_Key = access_key;

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

            return
            [
                new RouteConfig
                {
                    RouteId = "api-azure",
                    ClusterId = "api-azure-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/azure/{**catch-all}",
                    },
                    Transforms = transforms,
                },
                new RouteConfig
                {
                    RouteId = "api-comment",
                    ClusterId = "api-comment-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/comment/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-file",
                    ClusterId = "api-file-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/file/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-notification",
                    ClusterId = "api-notification-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/notification/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-project",
                    ClusterId = "api-project-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/project/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-profile",
                    ClusterId = "api-profile-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/profile/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-request",
                    ClusterId = "api-request-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/request/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-tag",
                    ClusterId = "api-tag-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/tag/{**catch-all}"
                    },
                    Transforms = transforms
                },
                new RouteConfig
                {
                    RouteId = "api-user",
                    ClusterId = "api-user-cluster",
                    AuthorizationPolicy = "default",
                    Match = new RouteMatch
                    {
                        Path = "api/v1/user/{**catch-all}"
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
                        ClusterId = "api-comment-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _comment
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
                        ClusterId = "api-request-cluster",
                        Destinations = new Dictionary<string, DestinationConfig>
                        {
                            {
                                "1", new DestinationConfig
                                {
                                    Address = _request
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
