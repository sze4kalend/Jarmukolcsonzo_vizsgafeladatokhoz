using Jarmukolcsonzo.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using System;
using System.Collections.Generic;

namespace Jarmukolcsonzo.API.Data;

public partial class JKContext : DbContext
{
    public JKContext()
    {
    }

    public JKContext(DbContextOptions<JKContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JarmuTipus> jarmu_tipusok { get; set; }

    public virtual DbSet<Jarmu> jarmuvek { get; set; }

    public virtual DbSet<Rendeles> rendelesek { get; set; }

    public virtual DbSet<Ugyfel> ugyfelek { get; set; }

    public virtual DbSet<Felhasznalo> felhasznalok { get; set; }

    public virtual DbSet<LoginToken> login_tokenek { get; set; }

    public virtual DbSet<Szerepkor> szerepkorok { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=root;database=jarmukolcsonzo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<JarmuTipus>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Jarmu>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasOne(d => d.tipus).WithMany(p => p.jarmuvek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jarmuvek_ibfk_1");
        });

        modelBuilder.Entity<Rendeles>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasOne(d => d.jarmu).WithMany(p => p.rendelesek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rendelesek_ibfk_2");

            entity.HasOne(d => d.ugyfel).WithMany(p => p.rendelesek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rendelesek_ibfk_1");
        });

        modelBuilder.Entity<Ugyfel>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
