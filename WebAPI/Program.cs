using Business;
using DataAccess;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogic();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCors();

WebApplication app = builder.Build();

app.UseCors(opt =>
{
  opt.AllowAnyHeader();
  opt.AllowAnyMethod();
  opt.AllowAnyOrigin();
});

app.UseRouting();

app.UseEndpoints(endpoint => endpoint.MapControllers());

app.Run();
