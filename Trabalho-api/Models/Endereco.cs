using Trabalho_api.Dto;

namespace Trabalho_api.Models;

public class Endereco
{

    public int id { get; set; }
    public User user { get; set; }
    public string rua { get; set; }
    public string cidade { get; set; }
    public string uf { get; set; }
    
    public Endereco(int id)
    {
        this.id = id;
    }
    
    public Endereco()
    {
    }

    public static Endereco of(EnderecoRequest request)
    {
        var endereco = new Endereco();
        endereco.cidade = request.cidade;
        endereco.rua = request.rua;
        endereco.uf = request.uf;
        return endereco;
    }

    public void vincularUser(User novoUser)
    {
        user = novoUser;
    }
}