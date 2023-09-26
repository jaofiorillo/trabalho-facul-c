namespace Trabalho_api.Dto;

public class DoacaoRequest
{
    public int id { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }
    public float preco { get; set; }
    public int vendedorId { get; set; }
    public string file { get; set; }
}