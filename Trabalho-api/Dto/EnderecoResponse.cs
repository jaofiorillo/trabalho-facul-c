using Trabalho_api.Models;

namespace Trabalho_api.Dto;

public class EnderecoResponse
{
    public int id { get; set; }
    public string rua { get; set; }
    public string cidade { get; set; }
    public string uf { get; set; }
    public int userId { get; set; }
    public string userNome { get; set; }

    public static EnderecoResponse convertFrom(Endereco endereco)
    {
        var doacaoResponse = new EnderecoResponse();
        doacaoResponse.id = endereco.id;
        doacaoResponse.rua = endereco.rua;
        doacaoResponse.cidade = endereco.cidade;
        doacaoResponse.uf = endereco.uf;
        doacaoResponse.userId = endereco.user.id;
        doacaoResponse.userNome = endereco.user.nome;
        return doacaoResponse;
    }

    public static List<EnderecoResponse> convertFrom(List<Endereco> enderecos)
    {
        return enderecos.Select(endereco => convertFrom(endereco)).ToList();
    }
}