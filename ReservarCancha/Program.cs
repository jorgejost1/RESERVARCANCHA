using ReservarCancha.Persistencia;
using ReservarCancha.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReservaRepository, ReservaRepository>();

builder.Services.AddSingleton<ICanchaRepository, CanchaRepository>();

builder.Services.AddSingleton<CrearReservaService>();
builder.Services.AddSingleton<ObtenerReservaPorIdService>();
builder.Services.AddSingleton<ObtenerReservasService>();
builder.Services.AddSingleton<ActualizarReservaService>();
builder.Services.AddSingleton<PatchReservaService>();
builder.Services.AddSingleton<EliminarReservaService>();

var app = builder.Build();

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
