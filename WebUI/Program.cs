WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoint => endpoint.MapDefaultControllerRoute());

app.Run();
