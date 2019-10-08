using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCare_PU.Entities;

namespace WeCare_PU.Models
{
    public class WeCareBdContext:DbContext
    {

            public WeCareBdContext(DbContextOptions<WeCareBdContext> options)
        : base(options)
                 {
                        }

        public WeCareBdContext()
        {
        }
       
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Messagerie> Messageries { get; set; }
        public DbSet<DemandeAdhesion> DemandeAdhesions { get; set; }
        public DbSet<CitoyenEvenement> CitoyenEvenements { get; set; }
        public DbSet<UtilisateursMessages> UtilisateursMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
    {
           builder.Entity<Evenement>();
            builder.Entity<EvenementAvecDon>();
            builder.Entity<EvenementSansDon>();
            builder.Entity<Utilisateur>();
            builder.Entity<Administrateur>();
            builder.Entity<Association>();
            builder.Entity<Citoyen>();
            builder.Entity<UtilisateursMessages>();
            builder.Entity<CitoyenEvenement>();
            builder.Entity<DemandeAdhesion>();
            builder.Entity<Messagerie>();
            builder.Entity<Publication>();

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDb;DataBase=WECARE_PU;Trusted_Connection=True;");
        }

    public DbSet<WeCare_PU.Entities.Association> Association { get; set; }

    public DbSet<WeCare_PU.Entities.Citoyen> Citoyen { get; set; }

    public DbSet<WeCare_PU.Entities.EvenementAvecDon> EvenementAvecDon { get; set; }

    public DbSet<WeCare_PU.Entities.EvenementSansDon> EvenementSansDon { get; set; }
        
      //  public DbSet<WeCare_PU.Entities.Citoyen> Citoyen { get; set; }
    }
}
