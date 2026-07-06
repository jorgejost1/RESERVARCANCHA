using Microsoft.AspNetCore.Mvc;
using ReservarCancha.Application;
using ReservarCancha.Dominio.Modelos;

namespace ReservarCancha.Presentacion.Controllers;

[ApiController]
[Route("api/reservas")]
public class ReservasController : ControllerBase
{
    private readonly ReservaService _reservaService;

    public ReservasController(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        return Ok(_reservaService.ObtenerTodas());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var reserva = _reservaService.ObtenerPorId(id);

        if (reserva == null)
            return NotFound();

        return Ok(reserva);
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Reserva reserva)
    {
        _reservaService.CrearReserva(reserva);
        return Ok(reserva);
    }

    [HttpPut]
    public IActionResult Actualizar([FromBody] Reserva reserva)
    {
        _reservaService.Actualizar(reserva);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _reservaService.Eliminar(id);
        return NoContent();
    }
}