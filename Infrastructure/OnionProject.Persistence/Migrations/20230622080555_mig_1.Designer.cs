﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnionProject.Persistence.Contexts;

#nullable disable

namespace OnionProject.Persistence.Migrations
{
    [DbContext(typeof(CmengDbContext))]
    [Migration("20230622080555_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnionProject.Domain.Entities.Product.Urun", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Kdv")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Olcu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Otv")
                        .HasColumnType("int");

                    b.Property<string>("Tanim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.Property<string>("UrunNumara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Urun");
                });

            modelBuilder.Entity("OnionProject.Domain.Entities.User.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("OnionProject.Domain.Entities.User.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("AccountLock")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FailPasswordCount")
                        .HasColumnType("int");

                    b.Property<bool?>("ForcePasswordChange")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("OnionProject.Domain.Entities.User.UserRole", b =>
                {
                    b.Property<Guid?>("RoleID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID")
                        .HasColumnOrder(1);

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID")
                        .HasColumnOrder(0);

                    b.HasKey("RoleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("OnionProject.Domain.Entities.User.UserRole", b =>
                {
                    b.HasOne("OnionProject.Domain.Entities.User.Role", "AspNetRole")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionProject.Domain.Entities.User.User", "AspNetUser")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetRole");

                    b.Navigation("AspNetUser");
                });

            modelBuilder.Entity("OnionProject.Domain.Entities.User.Role", b =>
                {
                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("OnionProject.Domain.Entities.User.User", b =>
                {
                    b.Navigation("AspNetUserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
