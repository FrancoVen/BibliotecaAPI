using System.Text.Json.Serialization;
using BibliotecaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//INICIO DEL AREA DE SERVICIOS

builder.Services.AddControllers().
    AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));




//FIN DEL AREA DE SERVICIOS
var app = builder.Build();
//INICIO DEL AREA DE MIDDLEWARES

app.MapControllers();
//FIN DEL AREA DE MIDDLEWARES
app.Run();
