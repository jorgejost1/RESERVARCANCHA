using ReservarCancha.Application.Dtos;
using ReservarCancha.Persistencia;

namespace ReservarCancha.Application.Services;

public class PatchReservaService
{
    private readonly IReservaRepository _reservaRepository;

    public PatchReservaService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public void Ejecutar(int id, PatchReservaDto dto)
    {
        var reserva = _reservaRepository.ObtenerPorId(id);

        if (reserva == null)
            throw new Exception("La reserva no existe.");

        if (dto.Cliente != null)
            reserva.Cliente = dto.Cliente;

        if (dto.Cancelada == true)
        {
            reserva.Cancelar();
        }
        
        reserva.Validar();

        _reservaRepository.Actualizar(reserva);
    }
}