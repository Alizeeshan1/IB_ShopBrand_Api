using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IB_ShopBrand_Api.Models
{
    public partial class IB_IBS_PortalContext : DbContext
    {
        

        public IB_IBS_PortalContext()
        {
        }

        public IB_IBS_PortalContext(DbContextOptions<IB_IBS_PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<IbsUser> IbsUsers { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=IB_IBS_Portal");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("IBS_Portal")
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES", "dbo");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_ID");

                entity.Property(e => e.Active)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category_Title");
            });

            modelBuilder.Entity<IbsUser>(entity =>
            {
                entity.HasKey(e => e.UserUnique)
                    .HasName("PK__IBS_USER__5209E075D2C347F3");

                entity.ToTable("IBS_USERS", "dbo");

                entity.Property(e => e.UserUnique)
                    .ValueGeneratedNever()
                    .HasColumnName("User_Unique");

                entity.Property(e => e.InsertBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Insert_By");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("date")
                    .HasColumnName("Insert_Date");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Update");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserActive)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Active");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Address");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Mobile");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserPic)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("User_Pic");

                entity.Property(e => e.UserSource)
                    .HasMaxLength(50)
                    .HasColumnName("User_Source");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.IbsUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__IBS_USERS__Role___3D5E1FD2");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("USER_ROLE", "dbo");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_ID");

                entity.Property(e => e.RoleTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role_Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
