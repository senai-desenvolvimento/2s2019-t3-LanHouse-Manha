
using Microsoft.EntityFrameworkCore;
using Senai.LanHouse.Web.Razor.Dominios;

namespace Senai.LanHouse.Web.Razor.Contextos
{
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {
        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistrosDefeitos> RegistrosDefeitos { get; set; }
        public virtual DbSet<TiposDefeitos> TiposDefeitos { get; set; }
        public virtual DbSet<TiposEquipamentos> TiposEquipamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=Lan_House;integrated security=true");  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrosDefeitos>(entity =>
            {
                entity.ToTable("Registros_Defeitos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDefeito).HasColumnName("Data_Defeito");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDefeitoId).HasColumnName("Tipo_Defeito_Id");

                entity.Property(e => e.TipoEquipamentoId).HasColumnName("Tipo_Equipamento_Id");

                entity.HasOne(d => d.TipoDefeito)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.TipoDefeitoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registros__Tipo___4E88ABD4");

                entity.HasOne(d => d.TipoEquipamento)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.TipoEquipamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registros__Tipo___4D94879B");
            });

            modelBuilder.Entity<TiposDefeitos>(entity =>
            {
                entity.ToTable("Tipos_Defeitos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposEquipamentos>(entity =>
            {
                entity.ToTable("Tipos_Equipamentos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
