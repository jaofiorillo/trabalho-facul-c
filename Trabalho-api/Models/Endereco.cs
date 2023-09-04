namespace Trabalho_api.Models;

public class Endereco
{
    public int id { get; set; }
    public User user { get; set; }
    public string rua { get; set; }
    public string cidade { get; set; }
    public string uf { get; set; }
}