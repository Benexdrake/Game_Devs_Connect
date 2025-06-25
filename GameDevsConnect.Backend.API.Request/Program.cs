var start = new Startup("Request");
var builder = start.Build(args);

builder.Services.AddScoped<IRequestRepository, RequestRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();