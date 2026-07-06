using ReservarCancha.Dominio.Modelos;

namespace ReservarCancha.Persistencia;

public interface ICanchaRepository
{
    List<Cancha> ObtenerTodas();

    Cancha? ObtenerPorId(int id);
}