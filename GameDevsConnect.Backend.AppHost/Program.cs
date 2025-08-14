var builder = DistributedApplication.CreateBuilder(args);

string sqlPW = builder.Configuration["SQL"]!;
string azureSCS = builder.Configuration["AZURE_STORAGE_CONNECTION_STRING"]!;
string azureBaseUrl = builder.Configuration["AZURE_STORAGE_BASE_URL"]!;

int replicas = 1;

// 0 = both, 1 = http, 2 = grpc
string modus = "0";

var accessKey = "123456";

var sqlServerPassword = builder.AddParameter("sqlPassword", secret: true, value: sqlPW);

var sql = builder.AddSqlServer("gamedevsconnect-backend-sql", port: 1400, password: sqlServerPassword)
                 .WithVolume("sqlserver-data", "/var/opt/mssql");

// HTTP1

var user = builder.AddProject<Projects.GameDevsConnect_Backend_API_User>("gamedevsconnect-backend-api-user")
       .WithHttpsEndpoint(port: 7009, name: "user")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var tag = builder.AddProject<Projects.GameDevsConnect_Backend_API_Tag>("gamedevsconnect-backend-api-tag")
       .WithHttpsEndpoint(port: 7008, name: "tag")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var quest = builder.AddProject<Projects.GameDevsConnect_Backend_API_Quest>("gamedevsconnect-backend-api-quest")
       .WithHttpsEndpoint(port: 7007, name: "quest")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var project = builder.AddProject<Projects.GameDevsConnect_Backend_API_Project>("gamedevsconnect-backend-api-project")
       .WithHttpsEndpoint(port: 7006, name: "project")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var profile = builder.AddProject<Projects.GameDevsConnect_Backend_API_Profile>("gamedevsconnect-backend-api-profile")
       .WithHttpsEndpoint(port: 7005, name: "profile")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var post = builder.AddProject<Projects.GameDevsConnect_Backend_API_Post>("gamedevsconnect-backend-api-post")
       .WithHttpsEndpoint(port: 7004, name: "post")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var notification = builder.AddProject<Projects.GameDevsConnect_Backend_API_Notification>("gamedevsconnect-backend-api-notification")
       .WithHttpsEndpoint(port: 7003, name: "notification")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var file = builder.AddProject<Projects.GameDevsConnect_Backend_API_File>("gamedevsconnect-backend-api-file")
       .WithHttpsEndpoint(port: 7002, name: "file")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("AZURE_STORAGE_BASE_URL", azureBaseUrl)
       .WithEnvironment("X-Access-Key", accessKey)
       .WaitFor(sql);

var azure = builder.AddProject<Projects.GameDevsConnect_Backend_API_Azure>("gamedevsconnect-backend-api-azure")
       .WithHttpEndpoint(port: 7001, name: "azure")
       .WithReplicas(replicas)
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WithEnvironment("AZURE_BLOB_CONNECTION_STRING", azureSCS)
       .WaitFor(sql);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Gateway>("gamedevsconnect-backend-api-gateway")
       .WithHttpsEndpoint(port: 7000, name: "gateway")
       .WithReplicas(replicas)
       .WithArgs([modus])
       .WithEnvironment("SQL_URL", "127.0.0.1, 1400")
       .WithEnvironment("SQL_ADMIN_USERNAME", "sa")
       .WithEnvironment("SQL_ADMIN_PASSWORD", sqlPW)
       .WithEnvironment("X-Access-Key", accessKey)
       .WithEnvironment("DEVMODUS", "true")
       .WithEnvironment("AZURE_URL", "https://localhost:7001")
       .WithEnvironment("FILE_URL", "https://localhost:7002")
       .WithEnvironment("NOTIFICATION_URL", "https://localhost:7003")
       .WithEnvironment("POST_URL", "https://localhost:7004")
       .WithEnvironment("PROFILE_URL", "https://localhost:7005")
       .WithEnvironment("PROJECT_URL", "https://localhost:7006")
       .WithEnvironment("QUEST_URL", "https://localhost:7007")
       .WithEnvironment("TAG_URL", "https://localhost:7008")
       .WithEnvironment("USER_URL", "https://localhost:7009")
       .WaitFor(azure)
       .WaitFor(file)
       .WaitFor(notification)
       .WaitFor(profile)
       .WaitFor(project)
       .WaitFor(post)
       .WaitFor(quest)
       .WaitFor(tag)
       .WaitFor(user);


var build = builder.Build();

await build.RunAsync();
