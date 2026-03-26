using System;
using System.Collections.Generic;
using Jarmukolcsonzo.API.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Jarmukolcsonzo.API.Data;

public partial class JKContext2 : DbContext
{
    public JKContext2()
    {
    }

    public JKContext2(DbContextOptions<JKContext2> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=root;database=jarmukolcsonzo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Felhasznalo>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasOne(d => d.szerepkor).WithMany(p => p.felhasznalok)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("felhasznalok_ibfk_1");
        });

        modelBuilder.Entity<LoginToken>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasOne(d => d.felhasznalo).WithMany(p => p.login_tokenek).HasConstraintName("login_tokenek_ibfk_1");
        });

        modelBuilder.Entity<Szerepkor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
