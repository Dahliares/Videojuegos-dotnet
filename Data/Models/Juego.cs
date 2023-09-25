using System;
using System.Collections.Generic;

namespace Videojuegos.Data.Models;

public partial class Juego
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Consola { get; set; }

    public string? Tipo { get; set; }

    public string? Saga { get; set; }

    public string? Formato { get; set; }

    public string? Idioma { get; set; }

    public string? Estado { get; set; }

    public string? Compania { get; set; }

    public string? Comentarios { get; set; }
}
