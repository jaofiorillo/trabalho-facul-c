using Newtonsoft.Json;
using Trabalho_api.Dto;
using Trabalho_api.Enuns;

namespace Trabalho_api.Models;

public class Doacao
{
    public int id { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }

    [JsonProperty("situacao")] public EProdutoSituacao situacao { get; set; }

    public string file { get; set; }
    public User vendedor { get; set; }

    public Endereco endereco { get; set; }
    public Categoria categoria { get; set; }
    public int quantidade { get; set; }

    public static Doacao of(DoacaoRequest request, User user, Endereco endereco, Categoria categoria)
    {
        var doacao = new Doacao();
        doacao.nome = request.nome;
        doacao.descricao = request.descricao;
        doacao.file = request.file;
        doacao.vendedor = user;
        doacao.endereco = endereco;
        doacao.quantidade = request.quantidade;
        doacao.categoria = categoria;
        return doacao;
    }

    public void pulicarDoacao()
    {
        situacao = EProdutoSituacao.PUBLICADO;
    }

    public void finalizarDoacao()
    {
        situacao = EProdutoSituacao.VENDIDO;
    }
}