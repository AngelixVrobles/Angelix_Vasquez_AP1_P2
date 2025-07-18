﻿// <auto-generated />
using System;
using Angelix_Vasquez_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Angelix_Vasquez_AP1_P2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250715000642_Intial")]
    partial class Intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Angelix_Vasquez_AP1_P2.Models.Entradas", b =>
                {
                    b.Property<int>("EntradasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntradasId"));

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("EntradasId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("Angelix_Vasquez_AP1_P2.Models.EntradasDetalle", b =>
                {
                    b.Property<int>("DetallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetallesId"));

                    b.Property<int>("EntradasId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("DetallesId");

                    b.HasIndex("EntradasId");

                    b.HasIndex("ProductoId");

                    b.ToTable("EntradasDetalle");
                });

            modelBuilder.Entity("Angelix_Vasquez_AP1_P2.Models.Producto", b =>
                {
                    b.Property<int>("ProductosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductosId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("ProductosId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductosId = 1,
                            Descripcion = "Mani",
                            Peso = 0.0
                        },
                        new
                        {
                            ProductosId = 2,
                            Descripcion = "Almendra",
                            Peso = 0.0
                        },
                        new
                        {
                            ProductosId = 3,
                            Descripcion = "Pistacho",
                            Peso = 0.0
                        });
                });

            modelBuilder.Entity("Angelix_Vasquez_AP1_P2.Models.EntradasDetalle", b =>
                {
                    b.HasOne("Angelix_Vasquez_AP1_P2.Models.Entradas", null)
                        .WithMany("EntradasDetalle")
                        .HasForeignKey("EntradasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Angelix_Vasquez_AP1_P2.Models.Producto", "Producto")
                        .WithMany("EntradasDetalle")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Angelix_Vasquez_AP1_P2.Models.Entradas", b =>
                {
                    b.Navigation("EntradasDetalle");
                });

            modelBuilder.Entity("Angelix_Vasquez_AP1_P2.Models.Producto", b =>
                {
                    b.Navigation("EntradasDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
