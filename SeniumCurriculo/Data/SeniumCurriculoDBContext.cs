using Microsoft.EntityFrameworkCore;
using SeniumCurriculo.Models;

namespace SeniumCurriculo.Data;

public class SeniumCurriculoDBContext : DbContext
{
    public SeniumCurriculoDBContext(DbContextOptions<SeniumCurriculoDBContext> options) : base(options)
    { }
    
    public DbSet<UsuarioModel> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        base.OnModelCreating(modelBuilder);
    }
}