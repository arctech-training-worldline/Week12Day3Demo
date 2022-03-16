﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Week12Day3Demo.Data.Models;

#nullable disable

namespace Week12Day3Demo.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.CustomerRef)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Customers");

                entity.HasOne(d => d.HotelRef)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.HotelRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Hotels");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.IdCardPan)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}