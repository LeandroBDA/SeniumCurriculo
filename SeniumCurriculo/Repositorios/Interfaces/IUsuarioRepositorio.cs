using SeniumCurriculo.Models;

namespace SeniumCurriculo.Repositorios.Interfaces;

public interface IUsuarioRepositorio
{ 
    Task<List<UsuarioModel>> BuscarTodosUsusarios();
    Task<List<UsuarioModel>> BuscarPorCidade();
    Task<UsuarioModel> BuscarPorId(int id);
    Task<UsuarioModel> Adicionar(UsuarioModel usuario);
    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
    Task<bool> Apagar(int id);
    
}