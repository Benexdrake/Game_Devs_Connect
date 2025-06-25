using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var start = new Startup("Azure");
var builder = start.Build(args);

builder.Services.AddScoped<IBlobRepository, BlobRepository>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();