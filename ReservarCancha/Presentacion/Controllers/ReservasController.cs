using Microsoft.AspNetCore.Mvc;
using ReservarCancha.Application.Dtos;
using ReservarCancha.Application.Services;
using ReservarCancha.Dominio.Modelos;

namespace ReservarCancha.Presentacion.Controllers;

[ApiController]
[Route("api/reservas")]
public class ReservasController : ControllerBase
{
    private readonly CrearReservaService _crearReservaService;
    private readonly ObtenerReservasService _obtenerReservasService;
    private readonly ObtenerReservaPorIdService _obtenerReservaPorIdService;
    private readonly ActualizarReservaService _actualizarReservaService;
    private readonly PatchReservaService _patchReservaService;
    private readonly EliminarReservaService _eliminarReservaService;

    public ReservasController(
        CrearReservaService crearReservaService,
        ObtenerReservasService obtenerReservasService,
        ObtenerReservaPorIdService obtenerReservaPorIdService,
        ActualizarReservaService actualizarReservaService,
        PatchReservaService patchReservaService,
        EliminarReservaService eliminarReservaService)
    {
        _crearReservaService = crearReservaService;
        _obtenerReservasService = obtenerReservasService;
        _obtenerReservaPorIdService = obtenerReservaPorIdService;
        _actualizarReservaService = actualizarReservaService;
        _patchReservaService = patchReservaService;
        _eliminarReservaService = eliminarReservaService;
    }

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        return Ok(_obtenerReservasService.Ejecutar());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var reserva = _obtenerReservaPorIdService.Ejecutar(id);

        if (reserva == null)
            return NotFound();

        return Ok(reserva);
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Reserva reserva)
    {
        try
        {
            _crearReservaService.Ejecutar(reserva);
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
            _actualizarReservaService.Ejecutar(reserva);
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
            _patchReservaService.Ejecutar(id, dto);
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
            _eliminarReservaService.Ejecutar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}