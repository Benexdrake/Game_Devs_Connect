var start = new Startup("Post");
var builder = start.Build(args);

builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();