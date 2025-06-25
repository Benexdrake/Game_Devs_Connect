var start = new Startup("User");
var builder = start.Build(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();