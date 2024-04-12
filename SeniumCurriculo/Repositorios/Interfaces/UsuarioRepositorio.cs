using Microsoft.EntityFrameworkCore;
using SeniumCurriculo.Data;
using SeniumCurriculo.Models;

namespace SeniumCurriculo.Repositorios.Interfaces;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly SeniumCurriculoDBContext _dbContex;
    
    public UsuarioRepositorio(SeniumCurriculoDBContext seniumCurriculoDbContext)
    {
        _dbContex = seniumCurriculoDbContext;
    }
   
    public async Task<List<UsuarioModel>> BuscarTodosUsusarios()
    {
        return await _dbContex.Usuarios.ToListAsync();
    }

    public async Task<List<UsuarioModel>> BuscarPorCidade()
    {
        return await _dbContex.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> BuscarPorId(int id)
    {
        return await _dbContex.Usuarios.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
        await _dbContex.Usuarios.AddAsync(usuario);
        await _dbContex.SaveChangesAsync();
        return usuario;
    }

    public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioPorId = await BuscarPorId(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
        }

        usuarioPorId.name = usuario.name;
        usuarioPorId.Cidade = usuario.Cidade;
        usuarioPorId.NumeroTelefone = usuario.NumeroTelefone;

        _dbContex.Usuarios.Update(usuarioPorId);
        await _dbContex.SaveChangesAsync();

        return usuarioPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        UsuarioModel usuarioPorId = await BuscarPorId(id);
        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
        }

        _dbContex.Usuarios.Remove(usuarioPorId);
        await _dbContex.SaveChangesAsync();

        return true;
    }
}