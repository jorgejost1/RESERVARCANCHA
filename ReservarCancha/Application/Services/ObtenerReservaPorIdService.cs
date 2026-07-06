using ReservarCancha.Dominio.Modelos;
using ReservarCancha.Persistencia;

namespace ReservarCancha.Application.Services;

public class ObtenerReservaPorIdService
{
    private readonly IReservaRepository _reservaRepository;

    public ObtenerReservaPorIdService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public Reserva? Ejecutar(int id)
    {
        return _reservaRepository.ObtenerPorId(id);
    }
}