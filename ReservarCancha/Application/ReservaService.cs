using ReservarCancha.Dominio.Modelos;
using ReservarCancha.Persistencia;
using ReservarCancha.Application.Dtos;

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
        // Validaciones propias de la entidad
        reserva.Validar();

        // Verificar que la cancha exista
        var cancha = _canchaRepository.ObtenerPorId(reserva.CanchaId);

        if (cancha == null)
            throw new Exception("La cancha no existe.");

        // Regla de negocio
        if (_reservaRepository.ExisteReserva(reserva.CanchaId, reserva.FechaHora))
            throw new Exception("La cancha ya está reservada en ese horario.");

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

    

    public void Patch(int id, PatchReservaDto dto)
{
    var reserva = _reservaRepository.ObtenerPorId(id);

    if (reserva == null)
        throw new Exception("La reserva no existe.");

    if (dto.Cliente != null)
        reserva.Cliente = dto.Cliente;

    if (dto.CanchaId.HasValue)
        reserva.CanchaId = dto.CanchaId.Value;

    if (dto.FechaHora.HasValue)
        reserva.FechaHora = dto.FechaHora.Value;

    if (dto.Cancelada.HasValue)
        reserva.Cancelada = dto.Cancelada.Value;

    // Validar nuevamente la reserva
    reserva.Validar();

    // Verificar que la cancha exista
    var cancha = _canchaRepository.ObtenerPorId(reserva.CanchaId);

    if (cancha == null)
        throw new Exception("La cancha no existe.");

    // Verificar que no exista otra reserva para esa cancha y horario
    var existe = _reservaRepository.ObtenerTodas().Any(r =>
        r.Id != reserva.Id &&
        r.CanchaId == reserva.CanchaId &&
        r.FechaHora == reserva.FechaHora &&
        !r.Cancelada);

    if (existe)
        throw new Exception("La cancha ya está reservada en ese horario.");

    _reservaRepository.Actualizar(reserva);
}

    public void Eliminar(int id)
    {
        _reservaRepository.Eliminar(id);
    }
}