using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst2.Models;

public partial class CodeFirstDb1Context : DbContext
{
    public CodeFirstDb1Context()
    {
    }

    public CodeFirstDb1Context(DbContextOptions<CodeFirstDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
