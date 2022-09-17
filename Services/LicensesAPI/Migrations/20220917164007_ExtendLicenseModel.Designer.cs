﻿// <auto-generated />
using System;
using LicensesAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LicensesAPI.Migrations
{
    [DbContext(typeof(LicensesContext))]
    [Migration("20220917164007_ExtendLicenseModel")]
    partial class ExtendLicenseModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("license")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LicensesAPI.Models.License", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Licenses", "license");
                });

            modelBuilder.Entity("LicensesAPI.Models.LicenseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsOfferActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceMonth")
                        .HasColumnType("int");

                    b.Property<int>("Subscriptions")
                        .HasColumnType("int");

                    b.Property<int>("ValidMonths")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LicenseTypes", "license");
                });

            modelBuilder.Entity("LicensesAPI.Models.LicenseUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("LicenseId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LicenseUsers", "license");
                });

            modelBuilder.Entity("LicensesAPI.Models.License", b =>
                {
                    b.HasOne("LicensesAPI.Models.LicenseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
