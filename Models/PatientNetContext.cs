using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatientNet.Models;

public partial class PatientNetContext : DbContext
{
    public PatientNetContext()
    {
    }

    public PatientNetContext(DbContextOptions<PatientNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consult> Consults { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1HIBEEUN; Database=PatientNet; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consult>(entity =>
        {
            entity.HasKey(e => e.ConsultId).HasName("PK_consults");

            entity.HasIndex(e => e.PatientId, "FK_Patients");

            entity.Property(e => e.ConsultId).HasColumnName("consult_id");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.Diagnostic)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("diagnostic");
            entity.Property(e => e.Observations)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.Patient).WithMany(p => p.Consults)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consults_Patients");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Allergies)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("allergies");
            entity.Property(e => e.Birthdate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("birthdate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observations)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.Sex)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
