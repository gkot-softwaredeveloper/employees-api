using Autofac;
using Autofac.Extensions.DependencyInjection;
using KOTIT.Employees.Infrastructure.DBContexts;
using KOTIT.Employees.Infrastructure.Host.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddDbContext<BaseContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesDb"), options =>
        {
            options.MigrationsAssembly(typeof(BaseContext).Assembly.ToString());
            options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        }));

// Autofac module

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder
    .Host
    .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DIConfigurations()));
var app = builder.Build();

// EF Migration process
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BaseContext>();
    if (db.Database.GetPendingMigrations().Any())
    {
        db.Database.Migrate();
    }
}
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
