using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevTestAPI.Models
{
    public partial class TALTestDBContext : DbContext
    {
        public TALTestDBContext()
        {
        }

        public TALTestDBContext(DbContextOptions<TALTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOccupation> TblOccupation { get; set; }
        public virtual DbSet<TblRatings> TblRatings { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("Server=DELL-AUSTRALIA;Database=TAL-TestDB;Trusted_Connection=True;");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TblOccupation>(entity =>
            {
                entity.HasKey(e => e.OccupationId)
                    .HasName("PK__tblOccup__8917118D91B6697E");

                entity.ToTable("tblOccupation");

                entity.Property(e => e.OccupationId).HasColumnName("OccupationID");

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.TblOccupation)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK__tblOccupa__Ratin__4222D4EF");
            });

            modelBuilder.Entity<TblRatings>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__tblRatin__FCCDF85CDDD045C1");

                entity.ToTable("tblRatings");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.Factor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
