using Trabalho_api.Models;

namespace Trabalho_api.Dto;

public class CategoriaResponse
{
    public int id { get; set; }
    public string nomeCategoria { get; set; }

    public static CategoriaResponse convertFrom(Categoria categoria)
    {
        var categoriaResponse = new CategoriaResponse();
        categoriaResponse.id = categoria.id;
        categoriaResponse.nomeCategoria = categoria.nome;
        return categoriaResponse;
    }

    public static List<CategoriaResponse> convertFrom(List<Categoria> categorias)
    {
        return categorias.Select(categoria => convertFrom(categoria)).ToList();
    }
}