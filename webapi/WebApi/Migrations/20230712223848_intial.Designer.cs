﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.DataAccess;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20230712223848_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("EntityId")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e4155c99-8d92-41dd-b147-6d8aff137944",
                            Email = "szook7@gmail.com",
                            EmailConfirmed = true,
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SZOOK7@GMAIL.COM",
                            NormalizedUserName = "SZOOK7@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKVkYS3J4SOk53o+eYGU5tV5SYgGsBS+0MhN78r6T2DO0m2iniHJ52z9MHc2TJLgbA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "szook7@gmail.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "67f8ad8f-52a3-4bc1-be8b-0f5f9b25c9b0",
                            Email = "lee.justin001126@gmail.com",
                            EmailConfirmed = true,
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "LEE.JUSTIN001126@GMAIL.COM",
                            NormalizedUserName = "LEE.JUSTIN001126@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFe2cqW704Uo7ygRAQa6mYuMAYTxoJJifeh2lspaAS5r7uQIYgpENTaZKi/ScJgPYw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "lee.justin001126@gmail.com"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "de944ba9-3627-4ed2-a1bf-2c4c6652118f",
                            Email = "erintimlin@gmail.com",
                            EmailConfirmed = true,
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ERINTIMLIN@GMAIL.COM",
                            NormalizedUserName = "ERINTIMLIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJPaaKkHvxo8qTe8xvpt70m+XvXtMAOLOIyJmXe4stDkk/UKYVViFucl6TroE/18Zg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "erintimlin@gmail.com"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "62a5cc98-caa7-4d36-9d87-fed24bf2d634",
                            Email = "gronstal.larson@gmail.com",
                            EmailConfirmed = true,
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "GRONSTAL.LARSON@GMAIL.COM",
                            NormalizedUserName = "GRONSTAL.LARSON@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAENaf0tzVFjBEz1Y3TNixnEHm6iVJNy13K1uY6abDAnKWKSHH5dAtFcYwsmwdCQAX/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Gronstal.Larson@gmail.com"
                        },
                        new
                        {
                            Id = "5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5366497c-c920-4ac4-bd64-966e703878e6",
                            Email = "b.bakshev@gmail.com",
                            EmailConfirmed = true,
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "B.BAKSHEV@GMAIL.COM",
                            NormalizedUserName = "B.BAKSHEV@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMJItyK0jeFHXAyz0bUoZHTN26sEYCU4vRw8g19TKIdjR+yAx0QDd6A2F0GrY/tNlA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "b.bakshev@gmail.com"
                        },
                        new
                        {
                            Id = "6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3523b2da-20ad-41b1-8a1d-d2068891e523",
                            Email = "eliot.lauren@gmail.com",
                            EmailConfirmed = true,
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            IsAdmin = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ELIOT.LAUREN@GMAIL.COM",
                            NormalizedUserName = "ELIOT.LAUREN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBevAZLfE/wWhFiKHzggr1BYore4F9ULlO2ClE8cAKl/WdhDM3N4TQO7NTLXIMhrlQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "eliot.lauren@gmail.com"
                        });
                });

            modelBuilder.Entity("WebApi.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebApi.Models.Commit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("authorId")
                        .HasColumnType("integer");

                    b.Property<int>("comment_count")
                        .HasColumnType("integer");

                    b.Property<string>("commitSha")
                        .HasColumnType("text");

                    b.Property<int?>("committerId")
                        .HasColumnType("integer");

                    b.Property<string>("message")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("authorId");

                    b.HasIndex("committerId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("WebApi.Models.Committer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Committer");
                });

            modelBuilder.Entity("WebApi.Models.EmailEntity", b =>
                {
                    b.Property<string>("EmailEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("appUserId")
                        .HasColumnType("text");

                    b.HasKey("EmailEntityId");

                    b.HasIndex("EntityId");

                    b.HasIndex("appUserId");

                    b.ToTable("emailEntities");

                    b.HasData(
                        new
                        {
                            EmailEntityId = "1",
                            Email = "szook7@gmail.com",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                        },
                        new
                        {
                            EmailEntityId = "2",
                            Email = "lee.justin001126@gmail.com",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                        },
                        new
                        {
                            EmailEntityId = "3",
                            Email = "erintimlin@gmail.com",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                        },
                        new
                        {
                            EmailEntityId = "4",
                            Email = "Gronstal.Larson@gmail.com",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                        },
                        new
                        {
                            EmailEntityId = "5",
                            Email = "b.bakshev@gmail.com",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                        },
                        new
                        {
                            EmailEntityId = "6",
                            Email = "eliot.lauren@gmail.com",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877"
                        });
                });

            modelBuilder.Entity("WebApi.Models.Entity", b =>
                {
                    b.Property<string>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("Entities");

                    b.HasData(
                        new
                        {
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            CompanyName = "EyeCue Lab"
                        },
                        new
                        {
                            EntityId = "98a29f8d-3129-4af1-831a-ff52c16a5c6d",
                            CompanyName = "CocaCola"
                        });
                });

            modelBuilder.Entity("WebApi.Models.ListOfCommits", b =>
                {
                    b.Property<int>("commitCount")
                        .HasColumnType("integer");

                    b.Property<int?>("commitId")
                        .HasColumnType("integer");

                    b.Property<string>("sha")
                        .HasColumnType("text");

                    b.HasIndex("commitId");

                    b.ToTable("ListOfCommits");
                });

            modelBuilder.Entity("WebApi.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683",
                            EntityId = "ca2e28bc-1bd8-4e72-898c-edc028676877",
                            ProjectName = "EyeCue Lab Project"
                        },
                        new
                        {
                            ProjectId = "0ed8fcad-f106-4717-b313-751a41e1077a",
                            EntityId = "98a29f8d-3129-4af1-831a-ff52c16a5c6d",
                            ProjectName = "CocaCola"
                        });
                });

            modelBuilder.Entity("WebApi.Models.ProjectAppUser", b =>
                {
                    b.Property<string>("ProjectAppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<string>("ProjectId")
                        .HasColumnType("text");

                    b.HasKey("ProjectAppUserId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectAppUsers");

                    b.HasData(
                        new
                        {
                            ProjectAppUserId = "1",
                            AppUserId = "1",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683"
                        },
                        new
                        {
                            ProjectAppUserId = "2",
                            AppUserId = "2",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683"
                        },
                        new
                        {
                            ProjectAppUserId = "3",
                            AppUserId = "3",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683"
                        },
                        new
                        {
                            ProjectAppUserId = "4",
                            AppUserId = "4",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683"
                        },
                        new
                        {
                            ProjectAppUserId = "5",
                            AppUserId = "5",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683"
                        },
                        new
                        {
                            ProjectAppUserId = "6",
                            AppUserId = "6",
                            ProjectId = "9bf535b3-cf39-4374-8fbe-51a96bcef683"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApi.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Models.Commit", b =>
                {
                    b.HasOne("WebApi.Models.Author", "author")
                        .WithMany()
                        .HasForeignKey("authorId");

                    b.HasOne("WebApi.Models.Committer", "committer")
                        .WithMany()
                        .HasForeignKey("committerId");

                    b.Navigation("author");

                    b.Navigation("committer");
                });

            modelBuilder.Entity("WebApi.Models.EmailEntity", b =>
                {
                    b.HasOne("WebApi.Models.Entity", "entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.AppUser", "appUser")
                        .WithMany()
                        .HasForeignKey("appUserId");

                    b.Navigation("appUser");

                    b.Navigation("entity");
                });

            modelBuilder.Entity("WebApi.Models.ListOfCommits", b =>
                {
                    b.HasOne("WebApi.Models.Commit", "commit")
                        .WithMany()
                        .HasForeignKey("commitId");

                    b.Navigation("commit");
                });

            modelBuilder.Entity("WebApi.Models.ProjectAppUser", b =>
                {
                    b.HasOne("WebApi.Models.AppUser", "appUser")
                        .WithMany("ProjectAppUsers")
                        .HasForeignKey("AppUserId");

                    b.HasOne("WebApi.Models.Project", "project")
                        .WithMany("ProjectAppUsers")
                        .HasForeignKey("ProjectId");

                    b.Navigation("appUser");

                    b.Navigation("project");
                });

            modelBuilder.Entity("WebApi.Models.AppUser", b =>
                {
                    b.Navigation("ProjectAppUsers");
                });

            modelBuilder.Entity("WebApi.Models.Project", b =>
                {
                    b.Navigation("ProjectAppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}