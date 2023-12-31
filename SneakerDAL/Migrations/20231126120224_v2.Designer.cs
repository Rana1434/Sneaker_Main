﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SneakerDAL;

#nullable disable

namespace SneakerDAL.Migrations
{
    [DbContext(typeof(SneakerDbContext))]
    [Migration("20231126120224_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SneakerDAL.Buy", b =>
                {
                    b.Property<int>("orderedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderedId"), 1L, 1);

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("shoeId")
                        .HasColumnType("int");

                    b.HasKey("orderedId");

                    b.HasIndex("orderId");

                    b.HasIndex("shoeId");

                    b.ToTable("Buys");
                });

            modelBuilder.Entity("SneakerDAL.Customer", b =>
                {
                    b.Property<int>("custId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("custId"), 1L, 1);

                    b.Property<string>("custAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("custName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("custId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SneakerDAL.Orders", b =>
                {
                    b.Property<int?>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("orderId"), 1L, 1);

                    b.Property<int?>("CustomercustId")
                        .HasColumnType("int");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("orderId");

                    b.HasIndex("CustomercustId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SneakerDAL.Shoes", b =>
                {
                    b.Property<int>("shoeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("shoeId"), 1L, 1);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shoeColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shoeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("shoePrice")
                        .HasColumnType("float");

                    b.Property<int?>("shoeSize")
                        .HasColumnType("int");

                    b.Property<string>("shoeStyle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("shoeId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("SneakerDAL.Buy", b =>
                {
                    b.HasOne("SneakerDAL.Orders", "OrderId")
                        .WithMany("Buys")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SneakerDAL.Shoes", "ShoeId")
                        .WithMany("Buys")
                        .HasForeignKey("shoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderId");

                    b.Navigation("ShoeId");
                });

            modelBuilder.Entity("SneakerDAL.Orders", b =>
                {
                    b.HasOne("SneakerDAL.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomercustId");
                });

            modelBuilder.Entity("SneakerDAL.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SneakerDAL.Orders", b =>
                {
                    b.Navigation("Buys");
                });

            modelBuilder.Entity("SneakerDAL.Shoes", b =>
                {
                    b.Navigation("Buys");
                });
#pragma warning restore 612, 618
        }
    }
}
