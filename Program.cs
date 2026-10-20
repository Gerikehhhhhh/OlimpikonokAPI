var builder = WebApplication.CreateBuilder(args);

// 1. Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// 2. Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();