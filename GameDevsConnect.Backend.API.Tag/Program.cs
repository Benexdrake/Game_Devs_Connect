using GameDevsConnect.Backend.API.Configuration;
var start = new Startup();
var builder = start.Build(args);

builder.Services.AddScoped<ITagRepository, TagRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();