using ReservarCancha.Persistencia;

namespace ReservarCancha.Application.Services;

public class EliminarReservaService
{
    private readonly IReservaRepository _reservaRepository;

    public EliminarReservaService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public void Ejecutar(int id)
    {
        _reservaRepository.Eliminar(id);
    }
}