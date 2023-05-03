using Contracts.SwaggerExclude;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Repository.SQLServer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Repository.DependencyInjection.ConfigureServices(builder.Services);

BLL.DependencyInjection.ConfigureServices(builder.Services);

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddDbContext<RepositoryContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));

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

