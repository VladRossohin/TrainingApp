using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainingApp.DAL.Models
{
    public partial class TrainingDBContext : DbContext
    {
        public TrainingDBContext()
        {
        }

        public TrainingDBContext(DbContextOptions<TrainingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Excercise> Excercise { get; set; }
        public virtual DbSet<Kick> Kick { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("TrainingDbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Excercise>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Excercise)
                    .HasForeignKey(d => d.SensorId)
                    .HasConstraintName("FK_Excercise_Sensor");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Excercise)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_Excercise_Training");
            });

            modelBuilder.Entity<Kick>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.KickDateTime).HasColumnType("datetime");

                entity.Property(e => e.KickPower).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ReactionSpeed).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Excercise)
                    .WithMany(p => p.Kick)
                    .HasForeignKey(d => d.ExcerciseId)
                    .HasConstraintName("FK_Kick_Excercise");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Kick)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kick_Sensor");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Training)
                    .HasForeignKey<Training>(d => d.Id)
                    .HasConstraintName("FK_Training_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
