var start = new Startup("User gRPC");

var builder = start.Build(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = start.Create(builder);

app.MapGrpcService<UserRPCService>();

app.Run();