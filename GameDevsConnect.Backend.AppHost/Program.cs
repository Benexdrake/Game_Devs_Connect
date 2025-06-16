using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

string sqlPW = builder.Configuration["SQL"]!;

int replicas = 1;

var accessKey = Guid.NewGuid().ToString();

var sqlServerPassword = builder.AddParameter("sqlPassword", secret: true, value: sqlPW);

var sql = builder.AddSqlServer("gamedevsconnect-backend-sql", port: 1400, password: sqlServerPassword)
                 .WithVolume("sqlserver-data", "/var/opt/mssql");

var user = builder.AddProject<Projects.GameDevsConnect_Backend_API_User>("gamedevsconnect-backend-api-user")
       .WithHttpEndpoint(port: 7009, name: "user")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var tag = builder.AddProject<Projects.GameDevsConnect_Backend_API_Tag>("gamedevsconnect-backend-api-tag")
       .WithHttpEndpoint(port: 7008, name: "tag")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var request = builder.AddProject<Projects.GameDevsConnect_Backend_API_Request>("gamedevsconnect-backend-api-request")
       .WithHttpEndpoint(port: 7007, name: "request")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var project = builder.AddProject<Projects.GameDevsConnect_Backend_API_Project>("gamedevsconnect-backend-api-project")
       .WithHttpEndpoint(port: 7006, name: "project")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var profile = builder.AddProject<Projects.GameDevsConnect_Backend_API_Profile>("gamedevsconnect-backend-api-profile")
       .WithHttpEndpoint(port: 7005, name: "profile")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var notification = builder.AddProject<Projects.GameDevsConnect_Backend_API_Notification>("gamedevsconnect-backend-api-notification")
       .WithHttpEndpoint(port: 7004, name: "notification")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var file = builder.AddProject<Projects.GameDevsConnect_Backend_API_File>("gamedevsconnect-backend-api-file")
       .WithHttpEndpoint(port: 7003, name: "file")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var comment = builder.AddProject<Projects.GameDevsConnect_Backend_API_Comment>("gamedevsconnect-backend-api-comment")
       .WithHttpEndpoint(port: 7002, name: "comment")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var azure = builder.AddProject<Projects.GameDevsConnect_Backend_API_Azure>("gamedevsconnect-backend-api-azure")
       .WithHttpEndpoint(port: 7001, name: "azure")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Gateway>("gamedevsconnect-backend-api-gateway")
       .WithHttpsEndpoint(port: 7000, name: "gateway")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WithEnvironment("AZURE_URL", "http://localhost:7001")
       .WithEnvironment("COMMENT_URL", "http://localhost:7002")
       .WithEnvironment("FILE_URL", "http://localhost:7003")
       .WithEnvironment("NOTIFICATION_URL", "http://localhost:7004")
       .WithEnvironment("PROFILE_URL", "http://localhost:7005")
       .WithEnvironment("PROJECT_URL", "http://localhost:7006")
       .WithEnvironment("REQUEST_URL", "http://localhost:7007")
       .WithEnvironment("TAG_URL", "http://localhost:7008")
       .WithEnvironment("USER_URL", "http://localhost:7009")
       .WaitFor(azure)
       .WaitFor(comment)
       .WaitFor(file)
       .WaitFor(notification)
       .WaitFor(profile)
       .WaitFor(project)
       .WaitFor(request)
       .WaitFor(tag)
       .WaitFor(user);

var build = builder.Build();

await build.RunAsync();
