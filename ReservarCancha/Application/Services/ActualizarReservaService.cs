using ReservarCancha.Dominio.Modelos;
using ReservarCancha.Persistencia;

namespace ReservarCancha.Application.Services;

public class ActualizarReservaService
{
    private readonly IReservaRepository _reservaRepository;

    public ActualizarReservaService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public void Ejecutar(Reserva reserva)
    {
        reserva.Validar();

        if (reserva.Cancelada)
        throw new Exception("No se puede modificar una reserva cancelada.");

        var existente = _reservaRepository.ObtenerPorId(reserva.Id);

        if (existente == null)
            throw new Exception("La reserva no existe.");

        if (_reservaRepository.ExisteReserva(reserva.CanchaId, reserva.FechaHora)
            && (existente.CanchaId != reserva.CanchaId ||
                existente.FechaHora != reserva.FechaHora))
        {
            throw new Exception("La cancha ya está reservada en ese horario.");
        }

        _reservaRepository.Actualizar(reserva);
    }
}