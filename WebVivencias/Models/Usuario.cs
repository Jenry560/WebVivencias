using System;
using System.Collections.Generic;

namespace WebVivencias.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Vivencia> Vivencia { get; set; } = new List<Vivencia>();
}
