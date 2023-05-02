using Contracts.SwaggerExclude;
using Data.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Data.DependencyInjection.ConfigureServices(builder.Services);

BLL.DependencyInjection.ConfigureServices(builder.Services);

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options
    => options.UseSqlServer("Data Source=geekburger.database.windows.net,1433; Initial Catalog=geekburger; User Id=geekburger; Password=@liAdos206"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekBurger", Version = "v1" });
    c.EnableAnnotations();
    c.SchemaFilter<SwaggerExcludeFilter>();
});

var app = builder.Build();

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeekBurger v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

