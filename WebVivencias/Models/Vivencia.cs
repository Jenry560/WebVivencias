using System;
using System.Collections.Generic;

namespace WebVivencias.Models;

public partial class Vivencia
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty!;

    public DateOnly FechaVivencia { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public byte[]? Imagen { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
