namespace ReservarCancha.Application.DTOs;

public class CrearReservaDto
{
    public int CanchaId { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public DateTime FechaHora { get; set; }
}