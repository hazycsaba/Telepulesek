using Microsoft.EntityFrameworkCore;
using Telepulesek.Models.Entities;

namespace Telepulesek.API.Data;

public partial class TelepulesekContext : DbContext
{
    public TelepulesekContext()
    {
    }

    public TelepulesekContext(DbContextOptions<TelepulesekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HivatalKod> hivatal_kodok { get; set; }

    public virtual DbSet<Jaras> jarasok { get; set; }

    public virtual DbSet<KisebbsegiOnkormanyzat> kisebbsegi_onkormanyzatok { get; set; }

    public virtual DbSet<Megye> megyek { get; set; }

    public virtual DbSet<TelepulesJogallas> telepules_jogallasok { get; set; }

    public virtual DbSet<TelepulesKisebbsegiKapcsolat> telepules_kisebbsegi_kapcsolatok { get; set; }

    public virtual DbSet<Telepules> telepulesek { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;user id=root;database=telepulesek", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_hungarian_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<HivatalKod>(entity =>
        {
            entity.HasKey(e => e.kod).HasName("PRIMARY");
        });

        modelBuilder.Entity<Jaras>(entity =>
        {
            entity.HasKey(e => e.kod).HasName("PRIMARY");

            entity.HasOne(d => d.szekhely).WithMany(p => p.jarasok)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jarasok_ibfk_1");
        });

        modelBuilder.Entity<KisebbsegiOnkormanyzat>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Megye>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasOne(d => d.szekhely).WithMany(p => p.megyek).HasConstraintName("megyek_ibfk_1");
        });

        modelBuilder.Entity<TelepulesJogallas>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");
        });

        modelBuilder.Entity<TelepulesKisebbsegiKapcsolat>(entity =>
        {
            entity.HasOne(d => d.onkormanyzat).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telepules_kisebbsegi_kapcsolatok_ibfk_1");

            entity.HasOne(d => d.telepules).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telepules_kisebbsegi_kapcsolatok_ibfk_2");
        });

        modelBuilder.Entity<Telepules>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasOne(d => d.hivatal_kod).WithMany(p => p.telepulesek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telepulesek_ibfk_5");

            entity.HasOne(d => d.hivatal_szekhely).WithMany(p => p.Inversehivatal_szekhely).HasConstraintName("telepulesek_ibfk_4");

            entity.HasOne(d => d.jaras).WithMany(p => p.telepulesek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telepulesek_ibfk_2");

            entity.HasOne(d => d.jogallas).WithMany(p => p.telepulesek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telepulesek_ibfk_3");

            entity.HasOne(d => d.megye).WithMany(p => p.telepulesek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telepulesek_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
