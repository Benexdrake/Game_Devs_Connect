var start = new Startup("Project");
var builder = start.Build(args);

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();