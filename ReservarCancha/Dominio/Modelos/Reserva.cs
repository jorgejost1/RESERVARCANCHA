namespace ReservarCancha.Dominio.Modelos;

public class Reserva
{
    public int Id { get; set; }

    public int CanchaId { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public DateTime FechaHora { get; set; }

    public bool Cancelada { get; set; }

    public void Validar()
    {
        if (CanchaId <= 0)
            throw new Exception("Debe seleccionar una cancha válida.");

        if (string.IsNullOrWhiteSpace(Cliente))
            throw new Exception("El nombre del cliente es obligatorio.");

        if (FechaHora <= DateTime.Now)
            throw new Exception("No se puede reservar una cancha en una fecha u horario pasado.");

        if (Cancelada)
            throw new Exception("No se puede crear una reserva cancelada.");
    }

    public void Cancelar()
    {
        if (Cancelada)
            throw new Exception("La reserva ya fue cancelada.");

        Cancelada = true;
    }
}

// estan famelicas, necesitos reglas de negocio, por ejemplo que no se pueda reservar una cancha que ya esta reservada en ese horario