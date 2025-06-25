using Autofac;
using Autofac.Extensions.DependencyInjection;
using MathProject.Host.API.Infrastructure;
using MathProject.Host.Application.Application.Extensions;
using MathProject.Host.Infrastructure.Extensions;

ContainerBuilder build = new ContainerBuilder();
build.RegisterModule(new ApplicationModule());

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMathProjectCollectionInfrastructure(builder.Configuration)
    .AddApplication();

// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        builder => builder.WithOrigins("https://localhost:7089")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Host.UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(build.Build()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowBlazorClient");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();