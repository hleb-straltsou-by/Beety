﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Models.Enums;
using System;

namespace DatabaseMigrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180219204053_AddUsersTables")]
    partial class AddUsersTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Security.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BossName");

                    b.Property<int?>("PersonalCount");

                    b.Property<int>("ServiceSegment");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Models.Security.Privator", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Experience");

                    b.Property<string>("PayerAccountNumber");

                    b.Property<int>("ServiceCategory");

                    b.Property<int>("ServiceSegment");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Privators");
                });

            modelBuilder.Entity("Models.Security.Redactor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("UserId");

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Redactors");
                });

            modelBuilder.Entity("Models.Security.RegistrationToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivationDate");

                    b.Property<DateTime>("CancellationDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsCancelled");

                    b.Property<string>("Token");

                    b.Property<long?>("User")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("User")
                        .IsUnique();

                    b.ToTable("RegistrationTokens");
                });

            modelBuilder.Entity("Models.Security.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Models.Security.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDay");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(255);

                    b.Property<int>("FailedLoginAttemptsCount");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(40);

                    b.Property<string>("Login");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("Phone");

                    b.Property<string>("Photo");

                    b.Property<DateTime?>("RegisteredAt");

                    b.Property<long?>("RoleId");

                    b.Property<string>("UserName")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Security.Organization", b =>
                {
                    b.HasOne("Models.Security.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Security.Privator", b =>
                {
                    b.HasOne("Models.Security.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Security.Redactor", b =>
                {
                    b.HasOne("Models.Security.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Security.RegistrationToken", b =>
                {
                    b.HasOne("Models.Security.User", "Client")
                        .WithOne("Token")
                        .HasForeignKey("Models.Security.RegistrationToken", "User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Security.User", b =>
                {
                    b.HasOne("Models.Security.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}