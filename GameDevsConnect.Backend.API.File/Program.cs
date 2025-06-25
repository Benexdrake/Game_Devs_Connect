var start = new Startup("File");
var builder = start.Build(args);

builder.Services.AddScoped<IFileRepository, FileRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();