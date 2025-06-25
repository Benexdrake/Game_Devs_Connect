var start = new Startup("Comment");
var builder = start.Build(args);

builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();