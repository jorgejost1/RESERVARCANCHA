using Microsoft.AspNetCore.Mvc;
using ReservarCancha.Persistencia;

namespace ReservarCancha.Presentacion.Controllers;

[ApiController]
[Route("api/canchas")]
public class CanchasController : ControllerBase
{
    private readonly ICanchaRepository _repository;

    public CanchasController(ICanchaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.ObtenerTodas());
    }
}