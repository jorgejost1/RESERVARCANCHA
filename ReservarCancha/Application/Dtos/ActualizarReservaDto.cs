namespace ReservarCancha.Application.DTOs;

public class ActualizarReservaDto
{
    public string Cliente { get; set; } = string.Empty;

    public DateTime FechaHora { get; set; }
}