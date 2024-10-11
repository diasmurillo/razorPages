using System;
using System.ComponentModel.DataAnnotations;

namespace filmeApp.Models;

public class Filme
{
    public int Id { get; set; }

    [Required]
    public string? Titulo { get; set; } 

    [DataType(DataType.Date)]
    public DateTime DataLancamento { get; set; }
    public string? Genero { get; set; }
    public decimal Preco { get; set; }
}
