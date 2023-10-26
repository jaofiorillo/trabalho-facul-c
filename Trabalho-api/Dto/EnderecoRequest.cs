using System.ComponentModel.DataAnnotations;

namespace Trabalho_api.Dto;

public class EnderecoRequest
{
    public int id { get; set; }

    [Required] [StringLength(100)] public string rua { get; set; }

    [Required] [StringLength(100)] public string cidade { get; set; }

    [Required] [StringLength(100)] public string uf { get; set; }

    [Required] public int userId { get; set; }
}