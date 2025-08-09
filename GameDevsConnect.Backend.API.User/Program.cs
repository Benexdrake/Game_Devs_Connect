var start = new Startup("User");
var builder = start.Build(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = start.Create(builder);

// HTTP1
app.MapEndpointsV1();

// HTTP2
app.MapGrpcService<UserRPCService>();

app.Run();