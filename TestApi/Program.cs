using Microsoft.EntityFrameworkCore;
using TestApi.Models.Humans.DB;
using TestApi.Services.Implementations;
using TestApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IHumanService, HumanService>();
builder.Services.AddScoped<IBasicCalculatorService, BasicCalculatorService>();

builder.Services.AddDbContext<HumanDBContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
