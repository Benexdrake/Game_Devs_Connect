var builder = DistributedApplication.CreateBuilder(args);

string sqlPW = builder.Configuration["SQL"];

int replicas = 3;

var sqlServerPassword = builder.AddParameter("sqlPassword", secret: true, value: sqlPW);

var sql = builder.AddSqlServer("gamedevsconnect-backend-sql", port: 1400,  password: sqlServerPassword)
                 .WithVolume("sqlserver-data", "/var/opt/mssql");

#region Add Projects
var gateway = builder.AddProject<Projects.GameDevsConnect_Backend_API_Gateway>("gamedevsconnect-backend-api-gateway")
                     .WithHttpsEndpoint(port: 7000, name: "gateway")
                     .WithReplicas(replicas)
                     .WaitFor(sql);

builder.AddProject<Projects.GameDevsConnect_Backend_API_User>("gamedevsconnect-backend-api-user")
       .WithHttpEndpoint(port: 7009, name:"user")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Tag>("gamedevsconnect-backend-api-tag")
       .WithHttpEndpoint(port: 7008, name: "tag")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Request>("gamedevsconnect-backend-api-request")
       .WithHttpEndpoint(port: 7007, name: "request")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Project>("gamedevsconnect-backend-api-project")
       .WithHttpEndpoint(port: 7006, name: "project")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Profile>("gamedevsconnect-backend-api-profile")
       .WithHttpEndpoint(port: 7005, name: "profile")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Notification>("gamedevsconnect-backend-api-notification")
       .WithHttpEndpoint(port: 7004, name: "notification")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_File>("gamedevsconnect-backend-api-file")
       .WithHttpEndpoint(port: 7003, name: "file")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Comment>("gamedevsconnect-backend-api-comment")
       .WithHttpEndpoint(port: 7002, name: "comment")
       .WithReplicas(replicas)
       .WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Azure>("gamedevsconnect-backend-api-azure")
       .WithHttpEndpoint(port: 7001, name: "azure")
       .WithReplicas(replicas)
       .WaitFor(gateway);
#endregion

//builder.AddDockerComposePublisher();

var build = builder.Build();

await build.RunAsync();
