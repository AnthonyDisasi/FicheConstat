using FicheConstat.Models;
using Microsoft.EntityFrameworkCore;

namespace FicheConstat.Data
{
    public class AppContextDb : DbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options) : base (options) { }
        public DbSet<Constat> Constats { get; set; }
        public DbSet<Intervenant> Intervenants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Materiel> Materiels { get; set; }
        public DbSet<Priorite> Priorites { get; set; }
        public DbSet<Renseignement> Renseignements { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
