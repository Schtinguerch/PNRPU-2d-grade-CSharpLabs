using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ObjectOrientedTestsCasesPrototype.Model;

public partial class ObjectOrientedTestCasesPrototypeContext : DbContext
{
    public ObjectOrientedTestCasesPrototypeContext()
    {
    }

    public ObjectOrientedTestCasesPrototypeContext(DbContextOptions<ObjectOrientedTestCasesPrototypeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestCase> TestCases { get; set; }

    public virtual DbSet<TestCaseRun> TestCaseRuns { get; set; }

    public virtual DbSet<TestMap> TestMaps { get; set; }

    public virtual DbSet<TestMapInherition> TestMapInheritions { get; set; }

    public virtual DbSet<TestMapRun> TestMapRuns { get; set; }

    public virtual DbSet<TestMapRunInherition> TestMapRunInheritions { get; set; }

    public virtual DbSet<TestingResult> TestingResults { get; set; }

    public virtual DbSet<TestingType> TestingTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=ObjectOrientedTestCasesPrototype;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestCase>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PK__TestCase__6CAE524C00573A87");

            entity.Property(e => e.CheckText).HasMaxLength(2048);
            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.ExpectedResult).HasMaxLength(2048);

            entity.HasOne(d => d.OverridedCase).WithMany(p => p.InverseOverridedCase)
                .HasForeignKey(d => d.OverridedCaseId)
                .HasConstraintName("TestCases_fk2");

            entity.HasOne(d => d.TestMap).WithMany(p => p.TestCases)
                .HasForeignKey(d => d.TestMapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestCases_fk0");

            entity.HasOne(d => d.Type).WithMany(p => p.TestCases)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestCases_fk1");
        });

        modelBuilder.Entity<TestCaseRun>(entity =>
        {
            entity.HasKey(e => e.RunId).HasName("PK__TestCase__A259D4DD20F30E18");

            entity.Property(e => e.CheckText).HasMaxLength(2048);
            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.ExpectedResult).HasMaxLength(2048);
            entity.Property(e => e.RunComment).HasMaxLength(2048);
            entity.Property(e => e.TicketUrl).HasMaxLength(2048);

            entity.HasOne(d => d.Result).WithMany(p => p.TestCaseRuns)
                .HasForeignKey(d => d.ResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestCaseRuns_fk1");

            entity.HasOne(d => d.TestRun).WithMany(p => p.TestCaseRuns)
                .HasForeignKey(d => d.TestRunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestCaseRuns_fk2");

            entity.HasOne(d => d.Type).WithMany(p => p.TestCaseRuns)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestCaseRuns_fk0");
        });

        modelBuilder.Entity<TestMap>(entity =>
        {
            entity.HasKey(e => e.MapId).HasName("PK__TestMaps__3265E21B8C78CAD6");

            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.MapName).HasMaxLength(96);
            entity.Property(e => e.MapVersion).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<TestMapInherition>(entity =>
        {
            entity.HasKey(e => e.InheritionId).HasName("PK__TestMapI__5B2029F5521209A6");

            entity.HasOne(d => d.ContainerTestMap).WithMany(p => p.TestMapInheritionContainerTestMaps)
                .HasForeignKey(d => d.ContainerTestMapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestMapInheritions_fk0");

            entity.HasOne(d => d.HoldedTestMap).WithMany(p => p.TestMapInheritionHoldedTestMaps)
                .HasForeignKey(d => d.HoldedTestMapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestMapInheritions_fk1");
        });

        modelBuilder.Entity<TestMapRun>(entity =>
        {
            entity.HasKey(e => e.RunId).HasName("PK__TestMapR__A259D4DD7DFEE7F6");

            entity.Property(e => e.Comment).HasMaxLength(2048);
            entity.Property(e => e.RunName).HasMaxLength(96);
            entity.Property(e => e.RunOrderNumber).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.TargetTestMap).WithMany(p => p.TestMapRuns)
                .HasForeignKey(d => d.TargetTestMapId)
                .HasConstraintName("FK__TestMapRu__Targe__0697FACD");
        });

        modelBuilder.Entity<TestMapRunInherition>(entity =>
        {
            entity.HasKey(e => e.InheritionId).HasName("PK__TestMapR__5B2029F5BDE496EF");

            entity.HasOne(d => d.ContainerTestMapRun).WithMany(p => p.TestMapRunInheritionContainerTestMapRuns)
                .HasForeignKey(d => d.ContainerTestMapRunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestMapRunInheritions_fk0");

            entity.HasOne(d => d.HoldedTestMapRun).WithMany(p => p.TestMapRunInheritionHoldedTestMapRuns)
                .HasForeignKey(d => d.HoldedTestMapRunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TestMapRunInheritions_fk1");
        });

        modelBuilder.Entity<TestingResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__TestingR__976902082BEF3237");

            entity.Property(e => e.ResultName).HasMaxLength(24);
        });

        modelBuilder.Entity<TestingType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__TestingT__516F03B59838E3A3");

            entity.Property(e => e.TypeName).HasMaxLength(24);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
