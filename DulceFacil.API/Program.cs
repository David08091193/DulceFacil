using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// 👇 Aquí agregas tu DbContext
builder.Services.AddDbContext<DulceFacilDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<EmpleadoRepository>();




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
    
Console.WriteLine("Conexión usada:");
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

app.Run();

