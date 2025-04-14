var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.GameDevsConnect_Backend_API_User>("gamedevsconnect-backend-api-user");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Tag>("gamedevsconnect-backend-api-tag");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Request>("gamedevsconnect-backend-api-request");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Project>("gamedevsconnect-backend-api-project");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Profile>("gamedevsconnect-backend-api-profile");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Notification>("gamedevsconnect-backend-api-notification");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Gateway>("gamedevsconnect-backend-api-gateway");

builder.AddProject<Projects.GameDevsConnect_Backend_API_File>("gamedevsconnect-backend-api-file");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Comment>("gamedevsconnect-backend-api-comment");

builder.AddProject<Projects.GameDevsConnect_Backend_API_Azure>("gamedevsconnect-backend-api-azure");

builder.Build().Run();
