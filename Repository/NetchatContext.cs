using System;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata;

namespace SignalRSimpleChat.Repository
{
    public partial class NetchatContext : DbContext
    {
        public NetchatContext()
        {
        }

        public NetchatContext(DbContextOptions<NetchatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SignalRSimpleChat.Model.Chat> Chat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=netchat;User Id=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignalRSimpleChat.Model.Chat>(entity =>
            {
                entity.ToTable("chat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(500);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
