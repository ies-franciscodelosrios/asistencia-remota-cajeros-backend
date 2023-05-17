﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Proyecto_BackEnd.Context;

#nullable disable

namespace ProyectoBackEnd.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230516083156_cambiostfg9")]
    partial class cambiostfg9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_BackEnd.Model.CajeroModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ip")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ubication")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.HasIndex("ip")
                        .IsUnique();

                    b.ToTable("Cashiers");
                });

            modelBuilder.Entity("Proyecto_BackEnd.Model.CallModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CajeroId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("duration")
                        .HasPrecision(5, 2)
                        .HasColumnType("DECIMAL(5,2)");

                    b.Property<int>("estado")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("p2p")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("rating")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id");

                    b.HasIndex("CajeroId");

                    b.HasIndex("UserId");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("Proyecto_BackEnd.Model.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double?>("note")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Proyecto_BackEnd.Model.CallModel", b =>
                {
                    b.HasOne("Proyecto_BackEnd.Model.CajeroModel", null)
                        .WithMany()
                        .HasForeignKey("CajeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_BackEnd.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
