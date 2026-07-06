using ReservarCancha.Dominio.Modelos;
using ReservarCancha.Persistencia;

namespace ReservarCancha.Application.Services;

public class ObtenerReservasService
{
    private readonly IReservaRepository _reservaRepository;

    public ObtenerReservasService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public List<Reserva> Ejecutar()
    {
        return _reservaRepository.ObtenerTodas();
    }
}