var start = new Startup("Quest");
var builder = start.Build(args);

builder.Services.AddScoped<IQuestRepository, QuestRepository>();

var app = start.Create(builder);

string modus = "0";

if (args.Length > 0)
    modus = args[0];

// HTTP1
if (modus.Equals("0") || modus.Equals("1"))
    app.MapEndpointsV1();

// HTTP2
if (modus.Equals("0") || modus.Equals("2"))
    app.MapGrpcService<APIService>();

app.Run();