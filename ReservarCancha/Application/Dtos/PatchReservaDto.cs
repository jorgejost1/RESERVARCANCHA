namespace ReservarCancha.Application.Dtos;

public class PatchReservaDto
{
    public string? Cliente { get; set; }

    public int? CanchaId { get; set; }

    public DateTime? FechaHora { get; set; }

    public bool? Cancelada { get; set; }
}