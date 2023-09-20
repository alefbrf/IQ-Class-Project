﻿// <auto-generated />
using System;
using IQ_Class.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IQ_Class.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230913005927_teste-3")]
    partial class teste3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IQ_Class.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("IQ_Class.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("schools");
                });

            modelBuilder.Entity("IQ_Class.Models.SchoolClass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("schoolid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("schoolid");

                    b.ToTable("school_class");
                });

            modelBuilder.Entity("IQ_Class.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("guid_active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("last_acess")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("online")
                        .HasColumnType("bit");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("schoolid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("schoolid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("IQ_Class.Models.UserClass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("school_classid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("school_classid");

                    b.HasIndex("userid");

                    b.ToTable("users_class");
                });

            modelBuilder.Entity("IQ_Class.Models.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roleid");

                    b.HasIndex("userid");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("IQ_Class.Models.SchoolClass", b =>
                {
                    b.HasOne("IQ_Class.Models.School", "school")
                        .WithMany("school_class")
                        .HasForeignKey("schoolid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("school");
                });

            modelBuilder.Entity("IQ_Class.Models.User", b =>
                {
                    b.HasOne("IQ_Class.Models.School", "school")
                        .WithMany("users")
                        .HasForeignKey("schoolid")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("school");
                });

            modelBuilder.Entity("IQ_Class.Models.UserClass", b =>
                {
                    b.HasOne("IQ_Class.Models.SchoolClass", "school_class")
                        .WithMany("users_class")
                        .HasForeignKey("school_classid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IQ_Class.Models.User", "user")
                        .WithMany("user_classes")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("school_class");

                    b.Navigation("user");
                });

            modelBuilder.Entity("IQ_Class.Models.UserRole", b =>
                {
                    b.HasOne("IQ_Class.Models.Role", "role")
                        .WithMany("user_role")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IQ_Class.Models.User", "user")
                        .WithMany("user_roles")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("IQ_Class.Models.Role", b =>
                {
                    b.Navigation("user_role");
                });

            modelBuilder.Entity("IQ_Class.Models.School", b =>
                {
                    b.Navigation("school_class");

                    b.Navigation("users");
                });

            modelBuilder.Entity("IQ_Class.Models.SchoolClass", b =>
                {
                    b.Navigation("users_class");
                });

            modelBuilder.Entity("IQ_Class.Models.User", b =>
                {
                    b.Navigation("user_classes");

                    b.Navigation("user_roles");
                });
#pragma warning restore 612, 618
        }
    }
}
