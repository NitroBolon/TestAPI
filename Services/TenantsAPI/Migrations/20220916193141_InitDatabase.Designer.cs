// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TenantsAPI.Context;

#nullable disable

namespace TenantsAPI.Migrations
{
    [DbContext(typeof(TenantsContext))]
    [Migration("20220916193141_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tenant")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TenantsAPI.Models.Tenant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks", "tenant");
                });

            modelBuilder.Entity("TenantsAPI.Models.TenantSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<bool>("ValueBool")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ValueDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("ValueInt")
                        .HasColumnType("bigint");

                    b.Property<string>("ValueString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantSettings", "tenant");
                });

            modelBuilder.Entity("TenantsAPI.Models.TenantUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TenantUsers", "tenant");
                });

            modelBuilder.Entity("TenantsAPI.Models.TenantSetting", b =>
                {
                    b.HasOne("TenantsAPI.Models.Tenant", null)
                        .WithMany("Settings")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("TenantsAPI.Models.Tenant", b =>
                {
                    b.Navigation("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
