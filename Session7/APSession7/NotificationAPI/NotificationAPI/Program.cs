using NotificationAPI.Services.Abstractions;
using NotificationAPI.Services.Decorators;
using NotificationAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<INotifier, EmailNotifier>();
builder.Services.Decorate<INotifier, LoggingNotifier>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API Patrones de Dise�o Estructural");
    });
}
else
{
    app.UseHttpsRedirection();

    app.UseAuthorization();
}

app.MapControllers();

app.Run();