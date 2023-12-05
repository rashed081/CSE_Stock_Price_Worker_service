﻿// <auto-generated />
using System;
using CSEData.Scrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSEData.Worker.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20230807165525_createTable")]
    partial class createTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSEData.Scrapper.Entities.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("StockCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CSEData.Scrapper.Entities.Price", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Companyid")
                        .HasColumnType("int");

                    b.Property<double>("LTP")
                        .HasColumnType("float");

                    b.Property<double>("high")
                        .HasColumnType("float");

                    b.Property<double>("low")
                        .HasColumnType("float");

                    b.Property<double>("open")
                        .HasColumnType("float");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<int>("volume")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Companyid");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("CSEData.Scrapper.Entities.Price", b =>
                {
                    b.HasOne("CSEData.Scrapper.Entities.Company", null)
                        .WithMany("priceList")
                        .HasForeignKey("Companyid");
                });

            modelBuilder.Entity("CSEData.Scrapper.Entities.Company", b =>
                {
                    b.Navigation("priceList");
                });
#pragma warning restore 612, 618
        }
    }
}
