var start = new Startup("Tag");
var builder = start.Build(args);

builder.Services.AddScoped<ITagRepository, TagRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();