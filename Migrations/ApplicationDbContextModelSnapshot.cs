﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopProject.Data;

#nullable disable

namespace ShopProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopProject.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("ShopProject.Models.CarsCategories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarEngine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasDiscriminator<string>("CarEngine").HasValue("Category");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ShopProject.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ShopProject.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.Property<int>("CarsID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("OrdersID", "CarsID");

                    b.HasIndex("CarsID");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("ShopProject.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNum")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Peoples", (string)null);
                });

            modelBuilder.Entity("ShopProject.Models.CarsCategories.ElectricCategory", b =>
                {
                    b.HasBaseType("ShopProject.Models.CarsCategories.Category");

                    b.HasDiscriminator().HasValue("Electric Engine");
                });

            modelBuilder.Entity("ShopProject.Models.CarsCategories.ICECategory", b =>
                {
                    b.HasBaseType("ShopProject.Models.CarsCategories.Category");

                    b.HasDiscriminator().HasValue("Internal Combustion Engine");
                });

            modelBuilder.Entity("ShopProject.Models.Car", b =>
                {
                    b.HasOne("ShopProject.Models.CarsCategories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShopProject.Models.Order", b =>
                {
                    b.HasOne("ShopProject.Models.People", "People")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });

            modelBuilder.Entity("ShopProject.Models.OrderDetails", b =>
                {
                    b.HasOne("ShopProject.Models.Car", "Cars")
                        .WithMany("OrderDetails")
                        .HasForeignKey("CarsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopProject.Models.Order", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cars");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ShopProject.Models.Car", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShopProject.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShopProject.Models.People", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
