var start = new Startup("Quest");
var builder = start.Build(args);

builder.Services.AddScoped<IQuestRepository, QuestRepository>();

var app = start.Create(builder);

app.MapEndpointsV1();
app.Run();