using ReservarCancha.Dominio.Modelos;

namespace ReservarCancha.Persistencia;

public class CanchaRepository : ICanchaRepository
{
    private readonly List<Cancha> _canchas =
    [
        new() { Id = 1, Nombre = "Cancha Futbol 5" },
        new() { Id = 2, Nombre = "Cancha Futbol 7" },
        new() { Id = 3, Nombre = "Cancha Paddle" }
    ];

    public List<Cancha> ObtenerTodas()
    {
        return _canchas;
    }

    public Cancha? ObtenerPorId(int id)
    {
        return _canchas.FirstOrDefault(c => c.Id == id);
    }
}