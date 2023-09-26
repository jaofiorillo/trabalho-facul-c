using Trabalho_api.Models;

namespace Trabalho_api.Dto;

public class DoacaoResponse
{
    public int id { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }
    public string situacao { get; set; }
    public string file { get; set; }
    public int vendedorId { get; set; }
    public string vendedorNome { get; set; }

    public static DoacaoResponse convertFrom(Doacao doacao)
    {
        var doacaoResponse = new DoacaoResponse();
        doacaoResponse.id = doacao.id;
        doacaoResponse.nome = doacao.nome;
        doacaoResponse.descricao = doacao.descricao;
        doacaoResponse.situacao = doacao.situacao.ToString();
        doacaoResponse.vendedorId = doacao.vendedor.id;
        doacaoResponse.vendedorNome = doacao.vendedor.nome;
        return doacaoResponse;
    }

    public static List<DoacaoResponse> convertFrom(List<Doacao> doacoes)
    {
        return doacoes.Select(doacao => convertFrom(doacao)).ToList();
    }
}