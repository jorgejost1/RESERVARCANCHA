using ReservarCancha.Dominio.Modelos;

namespace ReservarCancha.Persistencia;

public interface IReservaRepository
{
    List<Reserva> ObtenerTodas();

    Reserva? ObtenerPorId(int id);

    void Agregar(Reserva reserva);

    void Actualizar(Reserva reserva);

    void Eliminar(int id);
}