using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelSa3ada.Models;

public partial class Hotelsa3adaContext : DbContext
{
    public Hotelsa3adaContext()
    {
    }

    public Hotelsa3adaContext(DbContextOptions<Hotelsa3adaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chambre> Chambres { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Fidelite> Fidelites { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Rapport> Rapports { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GORDO\\SQLEXPRESS; Database=Hotelsa3ada; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chambre>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK__Chambre__FC77F21039CEEA38");

            entity.ToTable("Chambre");

            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Prix).HasColumnName("prix");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__A6A610D471DF0BB2");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.Contact)
                .HasMaxLength(15)
                .HasColumnName("contact");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .HasColumnName("prenom");
        });

        modelBuilder.Entity<Fidelite>(entity =>
        {
            entity.HasKey(e => e.IdFidelite).HasName("PK__Fidelite__0FB6E2041E5EEAE0");

            entity.ToTable("Fidelite");

            entity.Property(e => e.IdFidelite).HasColumnName("idFidelite");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.Niveau)
                .HasMaxLength(50)
                .HasColumnName("niveau");
            entity.Property(e => e.Points).HasColumnName("points");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Fidelites)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fidelite__idClie__45F365D3");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.IdPaiement).HasName("PK__Paiement__D44CB63DA77BA80C");

            entity.ToTable("Paiement");

            entity.Property(e => e.IdPaiement).HasColumnName("idPaiement");
            entity.Property(e => e.DatePaiement).HasColumnName("datePaiement");
            entity.Property(e => e.IdReservation).HasColumnName("idReservation");
            entity.Property(e => e.ModePaiement)
                .HasMaxLength(50)
                .HasColumnName("modePaiement");
            entity.Property(e => e.Montant).HasColumnName("montant");

            entity.HasOne(d => d.IdReservationNavigation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.IdReservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paiement__idRese__3E52440B");
        });

        modelBuilder.Entity<Rapport>(entity =>
        {
            entity.HasKey(e => e.IdRapport).HasName("PK__Rapport__0FC4D2602316794F");

            entity.ToTable("Rapport");

            entity.Property(e => e.IdRapport).HasColumnName("idRapport");
            entity.Property(e => e.Contenu).HasColumnName("contenu");
            entity.Property(e => e.DateGeneration).HasColumnName("dateGeneration");
            entity.Property(e => e.IdUtilisateur).HasColumnName("idUtilisateur");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Rapports)
                .HasForeignKey(d => d.IdUtilisateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rapport__idUtili__4316F928");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.IdReservation).HasName("PK__Reservat__B5B0E4106E7FFE9C");

            entity.ToTable("Reservation");

            entity.Property(e => e.IdReservation).HasColumnName("idReservation");
            entity.Property(e => e.DateDebut).HasColumnName("dateDebut");
            entity.Property(e => e.DateFin).HasColumnName("dateFin");
            entity.Property(e => e.IdChambre).HasColumnName("idChambre");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.Statut)
                .HasMaxLength(50)
                .HasColumnName("statut");

            entity.HasOne(d => d.IdChambreNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdChambre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__idCha__3A81B327");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__idCli__3B75D760");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK__Utilisat__5366DB19C239843C");

            entity.ToTable("Utilisateur");

            entity.Property(e => e.IdUtilisateur).HasColumnName("idUtilisateur");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
