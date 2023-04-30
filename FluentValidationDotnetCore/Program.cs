using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationDotnetCore;
using FluentValidationDotnetCore.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton(_ =>
{
    return new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    }.ToList();
});
builder.Services.AddScoped<IWeatherServices, WeatherServices>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();