﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.DataAccess;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    partial class PostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("EntityId")
                        .HasColumnType("integer");

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
                            ConcurrencyStamp = "47c68900-7748-4a81-b7be-ed36d105e20f",
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            EntityId = 1,
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEBlxQ3eYGE47YJ6WkfE7Gys1a72FZ5+Ls02AO596n+mi5uZL76AsM56BEUZwWV60AQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "507419f9-b352-4fb9-a053-f240fd7fd777",
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            EntityId = 1,
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEIELL8vWFcZwyWwb6x4CWE5soJwsjvtOlbkoHoDzX7p7BVV1cx0/Y838uwA7krWvNg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8ad3f5d2-2e7f-4da3-bcf3-514a10e8d33d",
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            EntityId = 0,
                            IsAdmin = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@EXAMPLE.COM",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAEAACcQAAAAELOdxK18OyKr+sZ8UJWWu6zvK00cWacJkQ5nhDOkTi23ZDENW4ffVxV1R8k1i4i8Eg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "47a693c0-b61f-4a92-bd39-16f501a23ddd",
                            Email = "gronstal.larson@gmail.com",
                            EmailConfirmed = true,
                            EntityId = 0,
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "GRONSTAL.LARSON@GMAIL.COM",
                            NormalizedUserName = "GRONSTAL.LARSON@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDNKzjVJSaFeDkZwLLF2DHz8fqq59goQCW/eojv5XOuRBitQnu1MFqq35+eDR3GJ9A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Gronstal.Larson@gmail.com"
                        });
                });

            modelBuilder.Entity("WebApi.Models.Commit", b =>
                {
                    b.Property<string>("Sha")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.HasKey("Sha");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("WebApi.Models.Entity", b =>
                {
                    b.Property<string>("EntityId")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("WebApi.Models.EntityAppUser", b =>
                {
                    b.Property<int>("EntityAppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EntityAppUserId"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<int>("EntityId")
                        .HasColumnType("integer");

                    b.Property<string>("EntityId1")
                        .HasColumnType("text");

                    b.HasKey("EntityAppUserId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("EntityId1");

                    b.ToTable("EntityAppUsers");
                });

            modelBuilder.Entity("WebApi.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("text");

                    b.Property<int>("EntityId")
                        .HasColumnType("integer");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WebApi.Models.ProjectAppUser", b =>
                {
                    b.Property<int>("ProjectAppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectAppUserId"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("ProjectId1")
                        .HasColumnType("text");

                    b.Property<string>("appUserId")
                        .HasColumnType("text");

                    b.HasKey("ProjectAppUserId");

                    b.HasIndex("ProjectId1");

                    b.HasIndex("appUserId");

                    b.ToTable("ProjectAppUsers");
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

            modelBuilder.Entity("WebApi.Models.EntityAppUser", b =>
                {
                    b.HasOne("WebApi.Models.AppUser", "AppUser")
                        .WithMany("EntityAppUsers")
                        .HasForeignKey("AppUserId");

                    b.HasOne("WebApi.Models.Entity", "Entity")
                        .WithMany("EntityAppUsers")
                        .HasForeignKey("EntityId1");

                    b.Navigation("AppUser");

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("WebApi.Models.ProjectAppUser", b =>
                {
                    b.HasOne("WebApi.Models.Project", "project")
                        .WithMany("ProjectAppUsers")
                        .HasForeignKey("ProjectId1");

                    b.HasOne("WebApi.Models.AppUser", "appUser")
                        .WithMany("ProjectAppUsers")
                        .HasForeignKey("appUserId");

                    b.Navigation("appUser");

                    b.Navigation("project");
                });

            modelBuilder.Entity("WebApi.Models.AppUser", b =>
                {
                    b.Navigation("EntityAppUsers");

                    b.Navigation("ProjectAppUsers");
                });

            modelBuilder.Entity("WebApi.Models.Entity", b =>
                {
                    b.Navigation("EntityAppUsers");
                });

            modelBuilder.Entity("WebApi.Models.Project", b =>
                {
                    b.Navigation("ProjectAppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
