using ReservarCancha.Dominio.Modelos;
using ReservarCancha.Persistencia;

namespace ReservarCancha.Application.Services;

public class CrearReservaService
{
    private readonly IReservaRepository _reservaRepository;
    private readonly ICanchaRepository _canchaRepository;

    public CrearReservaService(
        IReservaRepository reservaRepository,
        ICanchaRepository canchaRepository)
    {
        _reservaRepository = reservaRepository;
        _canchaRepository = canchaRepository;
    }

    public void Ejecutar(Reserva reserva)
    {
        reserva.Validar();

        var cancha = _canchaRepository.ObtenerPorId(reserva.CanchaId);

        if (cancha == null)
            throw new Exception("La cancha no existe.");

        if (_reservaRepository.ExisteReserva(reserva.CanchaId, reserva.FechaHora))
            throw new Exception("La cancha ya está reservada en ese horario.");

        _reservaRepository.Agregar(reserva);
    }
}