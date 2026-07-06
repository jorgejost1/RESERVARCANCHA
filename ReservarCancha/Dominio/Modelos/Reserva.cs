namespace ReservarCancha.Dominio.Modelos;

public class Reserva
{
    public int Id { get; set; }

    public int CanchaId { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public DateTime FechaHora { get; set; }

    public bool Cancelada { get; set; }
}

// estan famelicas, necesitos reglas de negocio, por ejemplo que no se pueda reservar una cancha que ya esta reservada en ese horario