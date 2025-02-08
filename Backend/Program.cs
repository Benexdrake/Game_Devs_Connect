var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<GDCDbContext>(o => o.UseSqlite("Data Source = UnitTestDb.db"));
else
    builder.Services.AddDbContext<GDCDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

var app = builder.Build();



app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
