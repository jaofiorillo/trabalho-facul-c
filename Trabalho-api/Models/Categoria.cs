namespace Trabalho_api.Models;

public class Categoria
{

    public int id { get; set; }
    public string nome { get; set; }
    
    public static Categoria of (string nomeCategoria)
    {
        var categoria = new Categoria();
        categoria.nome = nomeCategoria;
        return categoria;
    }
}