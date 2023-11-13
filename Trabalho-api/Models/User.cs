using Trabalho_api.Dto;

namespace Trabalho_api.Models;

public class User
{
    public int id { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }
    public List<Endereco> enderecos { get; set; }
    public string senha { get; set; }

    public static User? of(UserRequest request)
    {
        var user = new User();
        user.nome = request.nome;
        user.email = request.email;
        user.senha = request.senha;
        user.telefone = request.telefone;
        return user;
    }

    public void vincularEndereco(Endereco endereco)
    {
        enderecos.Add(endereco);
    }

    public bool hasEnderecos()
    {
        return enderecos != null && enderecos.Count > 0;
    }
}