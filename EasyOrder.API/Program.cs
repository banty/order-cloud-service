using EasyOrder.Domain;
using EasyOrder.Application;
using EasyOrder.Infrastructure;
using EasyOrder.API.Common;
using EasyOrder.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainServices();
builder.Services.AddAppServices();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddSingleton<IMiddleware, ExceptionMiddleware>();

//builder.Configuration.AddAzureAppConfiguration(builder.Configuration["ConnectionString:AppConfig"])
//    ;
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(builder.Configuration["ConnectionString:AppConfig"])
    .Select(keyFilter: "apidemo:settings:*")
    .ConfigureRefresh(t => t.Register("apidemo:settings:fontSize", refreshAll: true));
});
builder.Services.AddAzureAppConfiguration();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("apidemo:settings"));
//builder.Configuration.AddAzureAppConfiguration(t=>t.Connect())

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAzureAppConfiguration();
app.UseMiddleware<IMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

