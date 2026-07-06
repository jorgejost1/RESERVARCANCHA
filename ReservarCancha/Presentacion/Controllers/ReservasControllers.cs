using Microsoft.AspNetCore.Mvc;
using ReservarCancha.Application;
using ReservarCancha.Application.Dtos;
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
        try
        {
            _reservaService.CrearReserva(reserva);
            return Ok(reserva);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Actualizar([FromBody] Reserva reserva)
    {
        try
        {
            _reservaService.Actualizar(reserva);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody] PatchReservaDto dto)
    {
        try
        {
            _reservaService.Patch(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        try
        {
            _reservaService.Eliminar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}