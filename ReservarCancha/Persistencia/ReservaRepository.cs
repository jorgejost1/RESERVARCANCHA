using ReservarCancha.Dominio.Modelos;

namespace ReservarCancha.Persistencia;

public class ReservaRepository : IReservaRepository
{
    private readonly List<Reserva> _reservas = [];

    public List<Reserva> ObtenerTodas()
    {
        return _reservas;
    }

    public Reserva? ObtenerPorId(int id)
    {
        return _reservas.FirstOrDefault(r => r.Id == id);
    }

    public void Agregar(Reserva reserva)
    {
        _reservas.Add(reserva);
    }

    public void Actualizar(Reserva reserva)
{
    var existente = ObtenerPorId(reserva.Id);

    if (existente == null)
        return;

    existente.Cliente = reserva.Cliente;
    existente.FechaHora = reserva.FechaHora;
    existente.CanchaId = reserva.CanchaId;
    existente.Cancelada = reserva.Cancelada;
}

    public void Eliminar(int id)
    {
        var reserva = ObtenerPorId(id);

        if (reserva != null)
            _reservas.Remove(reserva);
    }
}