var builder = DistributedApplication.CreateBuilder(args);

var sqlServerPassword = builder.AddParameter("sqlPassword", secret: true, value:"P@ssword1");

var sql = builder.AddSqlServer("gamedevsconnect-backend-sql", port: 1400,  password: sqlServerPassword);

var gateway = builder.AddProject<Projects.GameDevsConnect_Backend_API_Gateway>("gamedevsconnect-backend-api-gateway").WithEndpoint(port: 7000, scheme: "https", name: "gateway").WaitFor(sql);

builder.AddProject<Projects.GameDevsConnect_Backend_API_User>("gamedevsconnect-backend-api-user").WithEndpoint(port: 7009, scheme: "http", name:"user").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Tag>("gamedevsconnect-backend-api-tag").WithEndpoint(port: 7008, scheme: "http", name: "tag").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Request>("gamedevsconnect-backend-api-request").WithEndpoint(port: 7007, scheme: "http", name: "request").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Project>("gamedevsconnect-backend-api-project").WithEndpoint(port: 7006, scheme: "http", name: "project").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Profile>("gamedevsconnect-backend-api-profile").WithEndpoint(port: 7005, scheme: "http", name: "profile").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Notification>("gamedevsconnect-backend-api-notification").WithEndpoint(port: 7004, scheme: "http", name: "notification").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_File>("gamedevsconnect-backend-api-file").WithEndpoint(port: 7003, scheme: "http", name: "file").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Comment>("gamedevsconnect-backend-api-comment").WithEndpoint(port: 7002, scheme: "http", name: "comment").WaitFor(gateway);

builder.AddProject<Projects.GameDevsConnect_Backend_API_Azure>("gamedevsconnect-backend-api-azure").WithEndpoint(port: 7001, scheme: "http", name: "azure").WaitFor(gateway);

builder.AddDockerfile(
    name: "gamedevsconnect-frontend",
    dockerfilePath: "../../GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/Dockerfile",
    contextPath: "../../GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web" )
        .WithEndpoint(port:3000, scheme: "http", name: "frontend", targetPort:3000)
        .WaitFor(gateway);

builder.AddDockerComposePublisher();

var build = builder.Build();

await build.RunAsync();
