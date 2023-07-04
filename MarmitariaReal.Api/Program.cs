using MarmitariaReal.Domain.Configuration;
using MarmitariaReal.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MarmitariaReal.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;
var appSettings = new AppSettings();
new ConfigureFromConfigurationOptions<AppSettings>(configuration.GetSection("AppSettings")).Configure(appSettings);
builder.Services.AddSingleton(appSettings);

builder.Services.AddDbContext<ProdutosDbContext>(options =>
{
    options.UseSqlServer(appSettings.ConnectionStrings.DefaultConnection);
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterServices();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();
app.MapControllers();

app.Run();
