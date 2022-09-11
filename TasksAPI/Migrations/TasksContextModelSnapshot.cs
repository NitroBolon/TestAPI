﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasksAPI.Context;

#nullable disable

namespace TasksAPI.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TasksAPI.Models.Task", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<long?>("StateId")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("StateId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TasksAPI.Models.TaskState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<int>("TenantOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaskStates");
                });

            modelBuilder.Entity("TasksAPI.Models.Task", b =>
                {
                    b.HasOne("TasksAPI.Models.Task", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("TasksAPI.Models.TaskState", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("Parent");

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
