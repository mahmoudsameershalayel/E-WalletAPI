using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using E_Wallet.API.Data;
using E_Wallet.API.Infrastructure.Helpers;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_WalletAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//connect to database 
var connectionString = builder.Configuration.GetConnectionString("AppConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
}
);
//Configure Repositories & Services
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSwagger();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(Program).Assembly,                  // Assembly A (where Program.cs is located)
    typeof(CreatePaymentCommand).Assembly
)); 


//Configure services from serviceExtensions
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Auto Mapper Service
builder.Services.AddAutoMapper(typeof(ApplicationProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/E-WalletAPI/swagger.json", "E-Wallet API");
});
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
