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

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Kick> Kicks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("TrainingDbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.EndDateTime).HasColumnType("datetime2(3)");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime2(3)");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Exercis)
                    .HasForeignKey(d => d.SensorId)
                    .HasConstraintName("FK_Excercises_Sensors");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_Excercises_Trainings");
            });

            modelBuilder.Entity<Kick>(entity =>
            {
                entity.Property(e => e.KickDateTime).HasColumnType("datetime2(3)");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Kicks)
                    .HasForeignKey(d => d.ExerciseId)
                    .HasConstraintName("FK_Kicks_Excercises");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Trainings_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
