using DataAccess;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddDataAccess(configuration);

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoint => endpoint.MapDefaultControllerRoute());

app.Run();
