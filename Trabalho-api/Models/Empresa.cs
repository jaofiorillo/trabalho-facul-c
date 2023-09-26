namespace Trabalho_api.Models;

public class Empresa
{
    public int id { get; set; }
    public string nome { get; set; }
    public string razaoSocial { get; set; }
    public string cnpj { get; set; }
    public Endereco endereco { get; set; }
    public User representante { get; set; }
}