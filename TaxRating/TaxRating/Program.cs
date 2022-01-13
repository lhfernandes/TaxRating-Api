using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TaxRating.Configurations;
using TaxRating.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddCorsConfiguration();

builder.Services.AddServicesDependencyGroup();

builder.Services.AddRepositoryDependencyGroup();

builder.Services.AddNotificationConfiguration();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

var conn = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<TaxRatingContext>(
x => x.UseSqlServer(conn));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseRouting();

app.MapControllers();

app.Run();
