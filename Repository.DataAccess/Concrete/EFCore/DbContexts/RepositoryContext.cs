using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Entities.Auth;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Concrete.EFCore.DbContexts
{
    public class RepositoryContext : IdentityDbContext<AspNetUser, AspNetRole, string,
                                     AspNetUserClaim, AspNetUserRole, AspNetUserLogin,
                                     AspNetRoleClaim, AspNetUserToken>
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<DealerPersonel> DealerPersonels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<ProducerPersonel> ProducerPersonels { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPart> ProductParts { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Provider=sqloledb;Data Source=SQL5108.site4now.net,1433;Initial Catalog=db_a7a56c_orguntay;User Id=db_a7a56c_orguntay_admin;Password=Papatya1453;");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-TUU483Q;Initial Catalog=MimarSoft-Orguntay-06ST8W-T1T46;Integrated Security=True;MultipleActiveResultSets=True");
                // akr3p     Rr3tt5!3     mimarsof_     77.245.159.18\MSSQLSERVER2019
                //                        MimarSoft-Orguntay-06ST8W-T1T46       78.175.56.43
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PhoneMobile).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.WebUrl).IsUnicode(false);

                //entity.HasOne(d => d.AspNetUser)
                //    .WithMany(p => p.Dealers)
                //    .HasForeignKey(d => d.AspNetUserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Dealers_AspNetUsers");
            });

            modelBuilder.Entity<DealerPersonel>(entity =>
            {
                entity.Property(e => e.PhoneMobile).IsUnicode(false);

                //entity.HasOne(d => d.AspNetUser)
                //    .WithOne(p => p.DealerPersonel)
                //    .HasForeignKey<DealerPersonel>(d => d.AspNetUserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_DealerPersonels_AspNetUsers");

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.DealerPersonels)
                    .HasForeignKey(d => d.DealerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DealerPersonels_Dealers");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DealerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Dealers");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Producers");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PhoneMobile).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.WebUrl).IsUnicode(false);

                //entity.HasOne(d => d.AspNetUser)
                //    .WithMany(p => p.Producers)
                //    .HasForeignKey(d => d.AspNetUserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Producers_AspNetUsers");
            });

            modelBuilder.Entity<ProducerPersonel>(entity =>
            {
                entity.Property(e => e.PhoneMobile).IsUnicode(false);

                //entity.HasOne(d => d.AspNetUser)
                //    .WithOne(p => p.ProducerPersonel)
                //    .HasForeignKey<ProducerPersonel>(d => d.AspNetUserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ProducerPersonels_AspNetUsers");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.ProducerPersonels)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProducerPersonels_Producers");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DealerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Dealers");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductTypes");
            });

            modelBuilder.Entity<ProductPart>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductParts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductParts_Categories");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductParts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductParts_Products");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole { Id = 1.ToString(), Name = "AKR3P", NormalizedName = "akr3p", ConcurrencyStamp = System.Guid.NewGuid().ToString() });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole { Id = 2.ToString(), Name = "YÖNETİM", NormalizedName = "yönetim", ConcurrencyStamp = System.Guid.NewGuid().ToString() });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole { Id = 3.ToString(), Name = "FABRİKA", NormalizedName = "fabrika", ConcurrencyStamp = System.Guid.NewGuid().ToString() });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole { Id = 4.ToString(), Name = "BAYİİ", NormalizedName = "bayii", ConcurrencyStamp = System.Guid.NewGuid().ToString() });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole { Id = 5.ToString(), Name = "USER", NormalizedName = "user", ConcurrencyStamp = System.Guid.NewGuid().ToString() });

            base.OnModelCreating(modelBuilder);
        }
    }
}