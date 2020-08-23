using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JBProject.Models
{
    public partial class BigShipContext : DbContext
    {
        //public CoreDbContext()
        //{
        //}

        public BigShipContext(DbContextOptions<BigShipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<PlanType> PlanType { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<UserBankDetails> UserBankDetails { get; set; }
        public virtual DbSet<UserCompanyDetails> UserCompanyDetails { get; set; }
        public virtual DbSet<UserInRoles> UserInRoles { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=69.16.239.56;Database=lalape_nopecom;uid=lpnop;pwd=r4y8Nb#2");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "lpnop");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Lcityid)
                    .HasName("PK__City__E0907D6E18F908AB");

                entity.Property(e => e.Lstate).IsUnicode(false);

                entity.Property(e => e.Lstatecode).IsUnicode(false);

                entity.Property(e => e.Ltype).IsUnicode(false);

                entity.HasOne(d => d.Lcountry)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.Lcountryid)
                    .HasConstraintName("FK__City__lcountryid__3572E547");

                entity.HasOne(d => d.LstateNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.Lstateid)
                    .HasConstraintName("FK__City__lstateid__347EC10E");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Lcountryid)
                    .HasName("PK__Country__6489F65FA62BE0C8");

                entity.Property(e => e.Lcountry).IsUnicode(false);
            });

            modelBuilder.Entity<PlanType>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__PlanType__755C22D7C20AC035");

                entity.HasIndex(e => e.PlanName)
                    .HasName("UQ__PlanType__46E12F9E9A2E9B47")
                    .IsUnique();
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE3ACDFB82B6");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__RoleMast__737584F6188F921D")
                    .IsUnique();
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Lstateid)
                    .HasName("PK__State__8868BBCC77CE0983");

                entity.Property(e => e.Lstate).IsUnicode(false);

                entity.Property(e => e.Lstatecode).IsUnicode(false);

                entity.Property(e => e.Ltype).IsUnicode(false);

                entity.HasOne(d => d.Lcountry)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.Lcountryid)
                    .HasConstraintName("FK__State__lcountryi__24485945");
            });

            modelBuilder.Entity<UserBankDetails>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__User_Ban__349DA586763060CC");

                entity.Property(e => e.BeneficiaryAccountNo).IsUnicode(false);

                entity.Property(e => e.BeneficiaryAccountType).IsUnicode(false);

                entity.Property(e => e.BeneficiaryName).IsUnicode(false);

                entity.Property(e => e.CancelledCheque).IsUnicode(false);

                entity.Property(e => e.IfscCode).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBankDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Bank__UserI__253C7D7E");
            });

            modelBuilder.Entity<UserCompanyDetails>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__User_Com__2D971C4C1FB71867");

                entity.Property(e => e.BillingAddressCity).IsUnicode(false);

                entity.Property(e => e.BillingAddressLine1).IsUnicode(false);

                entity.Property(e => e.BillingAddressLine2).IsUnicode(false);

                entity.Property(e => e.BillingAddressPhone).IsUnicode(false);

                entity.Property(e => e.BillingAddressPhoneCountryCode).IsUnicode(false);

                entity.Property(e => e.BillingAddressState).IsUnicode(false);

                entity.Property(e => e.CompanyEmailId).IsUnicode(false);

                entity.Property(e => e.CompanyGstin).IsUnicode(false);

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.InvoicePrefix).IsUnicode(false);

                entity.Property(e => e.InvoiceSuffix).IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Signature).IsUnicode(false);

                entity.Property(e => e.WebsiteUrl).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCompanyDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Comp__UserI__3943762B");
            });

            modelBuilder.Entity<UserInRoles>(entity =>
            {
                entity.HasKey(e => e.UserRoleId)
                    .HasName("PK__UserInRo__3D978A55E50B2BF8");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserInRol__RoleI__2818EA29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserInRol__UserI__290D0E62");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.InfoId)
                    .HasName("PK__User_Inf__4DEC9D9A4D3F29E0");

                entity.Property(e => e.MonthlyShipments).IsUnicode(false);

                entity.Property(e => e.OtherCategory).IsUnicode(false);

                entity.Property(e => e.ProductCategory).IsUnicode(false);

                entity.Property(e => e.SaleMedium).IsUnicode(false);

                entity.Property(e => e.UserCat).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Info__UserI__3C1FE2D6");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserMast__1788CCACAFF82403");

                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__UserMast__7ED91AEE6DEB1797")
                    .IsUnique();

                entity.Property(e => e.FirstName).HasDefaultValueSql("(N'')");

                entity.Property(e => e.LastName).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.UserMaster)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMaste__PlanI__2A01329B");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserMaster)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMaste__UserT__2AF556D4");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasIndex(e => e.UserType1)
                    .HasName("UQ__UserType__87E7869178F78539")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
