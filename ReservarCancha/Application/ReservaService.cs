using ReservarCancha.Dominio.Modelos;
using ReservarCancha.Persistencia;
using System.Linq;

namespace ReservarCancha.Application;

public class ReservaService
{
    private readonly IReservaRepository _reservaRepository;
    private readonly ICanchaRepository _canchaRepository;

    public ReservaService(
        IReservaRepository reservaRepository,
        ICanchaRepository canchaRepository)
    {
        _reservaRepository = reservaRepository;
        _canchaRepository = canchaRepository;
    }

    public void CrearReserva(Reserva reserva)
    {
        if (string.IsNullOrWhiteSpace(reserva.Cliente))
            throw new Exception("Debe ingresar el nombre del cliente.");

        var cancha = _canchaRepository.ObtenerPorId(reserva.CanchaId);

        if (cancha == null)
            throw new Exception("La cancha no existe.");


        var reservas = _reservaRepository.ObtenerTodas();

            if (reservas.Any(r =>
                r.CanchaId == reserva.CanchaId &&
                r.FechaHora == reserva.FechaHora &&
                !r.Cancelada))
            {
                throw new Exception("La cancha ya está reservada en ese horario.");
            }


        _reservaRepository.Agregar(reserva);
    }

    public List<Reserva> ObtenerTodas()
    {
        return _reservaRepository.ObtenerTodas();
    }

    public Reserva? ObtenerPorId(int id)
    {
        return _reservaRepository.ObtenerPorId(id);
    }

    public void Actualizar(Reserva reserva)
    {
        _reservaRepository.Actualizar(reserva);
    }

    public void Eliminar(int id)
    {
        _reservaRepository.Eliminar(id);
    }

    
}