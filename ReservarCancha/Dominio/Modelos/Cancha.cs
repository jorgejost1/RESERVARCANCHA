namespace ReservarCancha.Dominio.Modelos;

public class Cancha
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nombre))
            throw new Exception("El nombre de la cancha es obligatorio.");
    }
}