using Trabalho_api.Dto;
using Trabalho_api.Models;
using Trabalho_api.Repository;

namespace Trabalho_api.Services;

public class CategoriaService
{
    private readonly CategoriaRepository repository;

    public CategoriaService(CategoriaRepository _repository)
    {
        repository = _repository;
    }

    public async Task<Categoria> findById(int id)
    {
        return await repository.getById(id);
    }

    public async Task<List<CategoriaResponse>> getAll()
    {
        var categorias = await repository.findAll();
        return CategoriaResponse.convertFrom(categorias);
    }

    public async Task<Categoria?> saveCategoria(string nome)
    {
        var categoria = Categoria.of(nome);
        return await repository.save(categoria);
    }
    
    public async Task<Categoria?> editarCategoria(string nome, int id)
    {
        var categoria = await repository.getById(id);
        categoria.nome = nome;
        return await repository.atualizar(categoria);
    }
}