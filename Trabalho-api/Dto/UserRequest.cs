using System.ComponentModel.DataAnnotations;

namespace Trabalho_api.Dto;

public class UserRequest
{
    public int id;
    [Required]
    [StringLength(100)]
    public string nome { get; set; }
    
    [Required]
    [StringLength(100)]
    public string email { get; set; }
    
    [Required]
    [StringLength(100)]
    public string senha { get; set; }
}