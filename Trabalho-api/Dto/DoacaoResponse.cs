using Trabalho_api.Models;

namespace Trabalho_api.Dto;

public class DoacaoResponse
{
    public int id { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }
    public string situacao { get; set; }
    public string file { get; set; }
    public string categoria { get; set; }
    public int categoriaId { get; set; }
    public int quantidade { get; set; }
    public int vendedorId { get; set; }
    public string vendedorNome { get; set; }
    public string userFile { get; set; }
    public EnderecoResponse endereco { get; set; }

    public static DoacaoResponse convertFrom(Doacao doacao)
    {
        var doacaoResponse = new DoacaoResponse();
        doacaoResponse.id = doacao.id;
        doacaoResponse.nome = doacao.nome;
        doacaoResponse.descricao = doacao.descricao;
        doacaoResponse.situacao = doacao.situacao.ToString();
        doacaoResponse.vendedorId = doacao.vendedor.id;
        doacaoResponse.vendedorNome = doacao.vendedor.nome;
        doacaoResponse.endereco = EnderecoResponse.convertFrom(doacao.endereco);
        doacaoResponse.quantidade = doacao.quantidade;
        doacaoResponse.categoria = doacao.categoria.nome;
        doacaoResponse.categoriaId = doacao.categoria.id;
        return doacaoResponse;
    }

    public static List<DoacaoResponse> convertFrom(List<Doacao> doacoes)
    {
        return doacoes.Select(doacao => convertFrom(doacao)).ToList();
    }
}