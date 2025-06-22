using DulceFacil.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;
using DulceFacil.Dominio.Repositories;
using DulceFacil.Infrastructura.Repositories;



var builder = WebApplication.CreateBuilder(args);

// 👇 Aquí agregas tu DbContext
builder.Services.AddDbContext<DulceFacilDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IClienteRepository, ClientesRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
builder.Services.AddScoped<IZonaRepository, ZonaRepository>();
builder.Services.AddScoped<IRutaEntregaRepository, RutaEntregaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();







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

