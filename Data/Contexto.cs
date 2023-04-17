using CoderCarrer.Models;
using Microsoft.EntityFrameworkCore;

namespace CoderCarrer.Context
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Vaga> Vaga { get; set; }
    }
}
