var start = new Startup("Profile");
var builder = start.Build(args);

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();