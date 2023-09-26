using Trabalho_api.Models;

namespace Trabalho_api.Dto;

public class UserResponse
{
    public int id { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }
    public List<Endereco> enderecos { get; set; }

    public static UserResponse convertFrom(User user)
    {
        var userResponse = new UserResponse();
        userResponse.id = user.id;
        userResponse.nome = user.nome;
        userResponse.email = user.email;
        userResponse.telefone = user.telefone;
        userResponse.enderecos = user.enderecos;
        return userResponse;
    }

    public static List<UserResponse> convertFrom(List<User> users)
    {
        return users.Select(user => convertFrom(user)).ToList();
    }
}