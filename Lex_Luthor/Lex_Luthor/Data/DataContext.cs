using Lex_Luthor.Models;
using Microsoft.EntityFrameworkCore;
namespace Lex_Luthor.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }

}