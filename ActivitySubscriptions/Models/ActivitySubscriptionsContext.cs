using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ActivitySubscriptions.Models
{
    public partial class ActivitySubscriptionsContext : DbContext
    {
        public ActivitySubscriptionsContext()
        {
        }

        public ActivitySubscriptionsContext(DbContextOptions<ActivitySubscriptionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.Comments)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__Subscribe__Activ__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
