using System;
using System.Collections.Generic;
using Anki.Models;
using Microsoft.EntityFrameworkCore;

namespace Anki.Data;

public partial class AnkiContext : DbContext
{
    public AnkiContext()
    {
    }

    public AnkiContext(DbContextOptions<AnkiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Deck> Decks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=D:\\Projects\\Anki\\anki.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasColumnType("VARCHAR (30)")
                .HasColumnName("login");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("INT")
                .HasColumnName("password_hash");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("card");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BackContent).HasColumnName("back_content");
            entity.Property(e => e.DeckId)
                .HasColumnType("INT")
                .HasColumnName("deck_id");
            entity.Property(e => e.FrontContent).HasColumnName("front_content");
            entity.Property(e => e.LastPeriodRepeat)
                .HasColumnType("INT")
                .HasColumnName("last_period_repeat");
            entity.Property(e => e.TimeToShow).HasColumnName("time_to_show");

            entity.HasOne(d => d.Deck).WithMany(p => p.Cards)
                .HasForeignKey(d => d.DeckId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Deck>(entity =>
        {
            entity.ToTable("deck");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId)
                .HasColumnType("INT")
                .HasColumnName("account_id");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR (15)")
                .HasColumnName("name");

            entity.HasOne(d => d.Account).WithMany(p => p.Decks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
