var start = new Startup("Azure");
var builder = start.Build(args);

builder.Services.AddScoped<IBlobRepository, BlobRepository>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();

var connectionString = Environment.GetEnvironmentVariable("AZURE_BLOB_CONNECTION_STRING");

builder.Configuration["STORAGECONNECTIONSTRING"] = connectionString;


var app = start.Create(builder);
app.MapEndpointsV1();
app.Run();