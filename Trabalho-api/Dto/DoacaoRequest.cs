using System.ComponentModel.DataAnnotations;

namespace Trabalho_api.Dto;

public class DoacaoRequest
{
    public int id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string nome { get; set; }
    public string descricao { get; set; }
    [Required]
    public int vendedorId { get; set; }
    public string file { get; set; }
}