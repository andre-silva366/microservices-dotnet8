using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 01 - Acesso a configuração MySQL
var connectionString = builder.Configuration["MySQLConnection:MySQLConnectionString"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sw =>
{
    sw.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GeekShopping" });
});

// 02 - Adicionando serviço mysql
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
