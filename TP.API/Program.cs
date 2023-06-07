using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TP.API.Configurations;
using TP.CrossCutting.Services;
using TP.Data.Repositories;
using TP.Domain.Interfaces.Data;
using TP.Domain.Interfaces.Services;
using TP.Domain.Settings;
using TP.Service.Services;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.AddSerilog(builder);
builder.Services.AddCustomHealthChecks(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<ICacheControlService, CacheControlService>();

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

var app = builder.Build();

app.UseHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseHealthChecksUI(options =>
{
    options.UIPath = "/healthchecks-ui";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
