var start = new Startup("Profile");
var builder = start.Build(args);

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

var app = start.Create(builder);

ApiMode apiMode = 0;

if (args.Length > 0)
{
    var isNumber = int.TryParse(args[0], out int number);
    if (isNumber)
        apiMode = (ApiMode)number;
}

// HTTP1
if (apiMode == ApiMode.Both || apiMode == ApiMode.HTTP)
    app.MapEndpointsV1();

// gRPC
if (apiMode == ApiMode.Both || apiMode == ApiMode.gRPC)
    app.MapGrpcService<APIService>();

app.Run();