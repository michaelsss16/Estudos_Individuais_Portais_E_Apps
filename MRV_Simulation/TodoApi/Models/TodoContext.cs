using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TodoApi.Models.Cliente> Cliente { get; set; }

        public DbSet<TodoApi.Models.EmpreendimentoMoradia> Empreendimento { get; set; }
        public DbSet<TodoApi.Models.EmpreendimentoComercial> Empreendimento2 { get; set; }
        public DbSet<TodoApi.Models.Compras> Compras { get; set; }
    }
}