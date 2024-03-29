﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DataAccess.Concrete.EFCore.DbContexts;

namespace Repository.DataAccess.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210806101846_firstDB")]
    partial class firstDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Entities.Auth.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "81407d34-354f-4a32-80cc-64a9d1e0fb16",
                            Name = "AKR3P",
                            NormalizedName = "akr3p"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "62b70ca6-e040-43f8-bcd9-b0a9cc973197",
                            Name = "YÖNETİM",
                            NormalizedName = "yönetim"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "1ba2a38a-e853-4cd3-b1af-6065c4854141",
                            Name = "FABRİKA",
                            NormalizedName = "fabrika"
                        },
                        new
                        {
                            Id = "4",
                            ConcurrencyStamp = "b611feb9-3cad-47c9-ae78-4710c5355f26",
                            Name = "BAYİİ",
                            NormalizedName = "bayii"
                        },
                        new
                        {
                            Id = "5",
                            ConcurrencyStamp = "19255214-b145-4493-8e2d-dbf2f4242838",
                            Name = "USER",
                            NormalizedName = "user"
                        });
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("AccountCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRole_RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<short?>("ParentId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("City")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("date")
                        .HasColumnName("Date_Register");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<string>("PhoneMobile")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("Phone_Mobile");

                    b.Property<int?>("ProducerId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("WebUrl")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("WebURL");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.DealerPersonel", b =>
                {
                    b.Property<string>("AspNetUserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("date")
                        .HasColumnName("Date_Register");

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneMobile")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("Phone_Mobile");

                    b.HasKey("AspNetUserId");

                    b.HasIndex("DealerId");

                    b.ToTable("DealerPersonels");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOrderStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("OrderDate");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("ProducerId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("City")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("date")
                        .HasColumnName("Date_Register");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<string>("PhoneMobile")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("Phone_Mobile");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("WebUrl")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("WebURL");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.ProducerPersonel", b =>
                {
                    b.Property<string>("AspNetUserId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("date")
                        .HasColumnName("Date_Register");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneMobile")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("Phone_Mobile");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("AspNetUserId");

                    b.HasIndex("ProducerId");

                    b.ToTable("ProducerPersonels");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("PathPDF")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<short>("TypeId")
                        .HasColumnType("smallint");

                    b.HasKey("ProductId");

                    b.HasIndex("DealerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.ProductPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Size")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductParts");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.ProductType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetRoleClaim", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserClaim", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserLogin", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserRole", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.Auth.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUserToken", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Category", b =>
                {
                    b.HasOne("Repository.Entities.Concrete.Category", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Categories_Categories");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Dealer", b =>
                {
                    b.HasOne("Repository.Entities.Concrete.Producer", null)
                        .WithMany("Dealers")
                        .HasForeignKey("ProducerId");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.DealerPersonel", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetUser", "AspNetUser")
                        .WithOne("DealerPersonel")
                        .HasForeignKey("Repository.Entities.Concrete.DealerPersonel", "AspNetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.Concrete.Dealer", "Dealer")
                        .WithMany("DealerPersonels")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("FK_DealerPersonels_Dealers")
                        .IsRequired();

                    b.Navigation("AspNetUser");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Order", b =>
                {
                    b.HasOne("Repository.Entities.Concrete.Dealer", "Dealer")
                        .WithMany("Orders")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("FK_Orders_Dealers")
                        .IsRequired();

                    b.HasOne("Repository.Entities.Concrete.Producer", "Producer")
                        .WithMany("Orders")
                        .HasForeignKey("ProducerId")
                        .HasConstraintName("FK_Orders_Producers")
                        .IsRequired();

                    b.HasOne("Repository.Entities.Concrete.Product", "Product")
                        .WithOne("Order")
                        .HasForeignKey("Repository.Entities.Concrete.Order", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dealer");

                    b.Navigation("Producer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.ProducerPersonel", b =>
                {
                    b.HasOne("Repository.Entities.Auth.AspNetUser", "AspNetUser")
                        .WithOne("ProducerPersonel")
                        .HasForeignKey("Repository.Entities.Concrete.ProducerPersonel", "AspNetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Entities.Concrete.Producer", "Producer")
                        .WithMany("ProducerPersonels")
                        .HasForeignKey("ProducerId")
                        .HasConstraintName("FK_ProducerPersonels_Producers")
                        .IsRequired();

                    b.Navigation("AspNetUser");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Product", b =>
                {
                    b.HasOne("Repository.Entities.Concrete.Dealer", "Dealer")
                        .WithMany("Products")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("FK_Products_Dealers")
                        .IsRequired();

                    b.HasOne("Repository.Entities.Concrete.ProductType", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Products_ProductTypes")
                        .IsRequired();

                    b.Navigation("Dealer");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.ProductPart", b =>
                {
                    b.HasOne("Repository.Entities.Concrete.Category", "Category")
                        .WithMany("ProductParts")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_ProductParts_Categories")
                        .IsRequired();

                    b.HasOne("Repository.Entities.Concrete.Product", "Product")
                        .WithMany("ProductParts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductParts_Products")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Repository.Entities.Auth.AspNetUser", b =>
                {
                    b.Navigation("DealerPersonel");

                    b.Navigation("ProducerPersonel");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Category", b =>
                {
                    b.Navigation("InverseParent");

                    b.Navigation("ProductParts");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Dealer", b =>
                {
                    b.Navigation("DealerPersonels");

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Producer", b =>
                {
                    b.Navigation("Dealers");

                    b.Navigation("Orders");

                    b.Navigation("ProducerPersonels");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.Product", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("ProductParts");
                });

            modelBuilder.Entity("Repository.Entities.Concrete.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
