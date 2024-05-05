﻿// <auto-generated />
using System;
using FarmApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmApplication.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240401185545_helpmemememe")]
    partial class helpmemememe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmApplication.Areas.Identity.Data.FarmApplicationDBUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FarmApplicationDBUser");
                });

            modelBuilder.Entity("FarmApplication.Model.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipmentCount")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("FarmApplication.Model.FarmResources", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"));

                    b.Property<int>("ResourceCount")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("FarmApplication.Model.FarmTasks", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"));

                    b.Property<int>("EquipmentValuesId")
                        .HasColumnType("int");

                    b.Property<int>("FieldValuesFieldID")
                        .HasColumnType("int");

                    b.Property<int>("ResourcesValuesResourceId")
                        .HasColumnType("int");

                    b.Property<int>("TaskEquipment")
                        .HasColumnType("int");

                    b.Property<int>("TaskField")
                        .HasColumnType("int");

                    b.Property<int>("TaskResources")
                        .HasColumnType("int");

                    b.Property<int>("TaskWorker")
                        .HasColumnType("int");

                    b.Property<int>("WorkersValuesWorkerID")
                        .HasColumnType("int");

                    b.HasKey("TaskID");

                    b.HasIndex("EquipmentValuesId");

                    b.HasIndex("FieldValuesFieldID");

                    b.HasIndex("ResourcesValuesResourceId");

                    b.HasIndex("WorkersValuesWorkerID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("FarmApplication.Model.Field", b =>
                {
                    b.Property<int>("FieldID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FieldID"));

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldSize")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FieldID");

                    b.HasIndex("UserID");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("FarmApplication.Model.Workers", b =>
                {
                    b.Property<int>("WorkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerID"));

                    b.Property<DateTime>("EmployedUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkerSalary")
                        .HasColumnType("int");

                    b.HasKey("WorkerID");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("FarmApplication.Model.FarmTasks", b =>
                {
                    b.HasOne("FarmApplication.Model.Equipment", "EquipmentValues")
                        .WithMany()
                        .HasForeignKey("EquipmentValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmApplication.Model.Field", "FieldValues")
                        .WithMany()
                        .HasForeignKey("FieldValuesFieldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmApplication.Model.FarmResources", "ResourcesValues")
                        .WithMany()
                        .HasForeignKey("ResourcesValuesResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FarmApplication.Model.Workers", "WorkersValues")
                        .WithMany()
                        .HasForeignKey("WorkersValuesWorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentValues");

                    b.Navigation("FieldValues");

                    b.Navigation("ResourcesValues");

                    b.Navigation("WorkersValues");
                });

            modelBuilder.Entity("FarmApplication.Model.Field", b =>
                {
                    b.HasOne("FarmApplication.Areas.Identity.Data.FarmApplicationDBUser", "AspNetUsers")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetUsers");
                });
#pragma warning restore 612, 618
        }
    }
}