namespace Trabalho_api.Models;

public class Pedido
{
    public int id { get; set; }
    public string nome { get; set; }
    public float precoTotal { get; set; }
    public List<Produto> Produtos { get; set; }
    public User userCadastro { get; set; }
    public User userComprador { get; set; }
    public Endereco Endereco { get; set; }
}