﻿// <auto-generated />
using System;
using IQ_Class.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IQ_Class.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IQ_Class.Models.DataBase.UserClass", b =>
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

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dt_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dt_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phone")
                        .HasColumnType("int");

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

                    b.Property<int?>("roleid")
                        .HasColumnType("int");

                    b.Property<int?>("schoolid")
                        .HasColumnType("int");

                    b.Property<string>("verification_code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<bool>("verification_code_active")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("roleid");

                    b.HasIndex("schoolid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("IQ_Class.Models.DataBase.UserClass", b =>
                {
                    b.HasOne("IQ_Class.Models.SchoolClass", "school_class")
                        .WithMany("users_class")
                        .HasForeignKey("school_classid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IQ_Class.Models.User", "user")
                        .WithMany("user_class")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("school_class");

                    b.Navigation("user");
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
                    b.HasOne("IQ_Class.Models.Role", "role")
                        .WithMany("users")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("IQ_Class.Models.School", "school")
                        .WithMany("users")
                        .HasForeignKey("schoolid")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("role");

                    b.Navigation("school");
                });

            modelBuilder.Entity("IQ_Class.Models.Role", b =>
                {
                    b.Navigation("users");
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
                    b.Navigation("user_class");
                });
#pragma warning restore 612, 618
        }
    }
}
