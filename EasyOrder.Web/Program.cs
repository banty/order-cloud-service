using EasyOrder.Web;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(builder.Configuration["ConnectionString:AppConfig"])
           .Select("apidemo:settings:*")
           .ConfigureRefresh(t => t.Register("apidemo:sentinel", refreshAll: true)
                                   .SetCacheExpiration(TimeSpan.FromSeconds(2)));

});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAzureAppConfiguration();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("apidemo:settings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAzureAppConfiguration();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

