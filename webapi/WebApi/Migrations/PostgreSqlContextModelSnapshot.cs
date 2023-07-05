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
<<<<<<< HEAD
                            ConcurrencyStamp = "b9bdacc4-71c5-4082-9b10-90e66798ee0e",
=======
                            ConcurrencyStamp = "a25498ea-10fc-4995-bc05-e28200d5047c",
>>>>>>> origin
                            Email = "user1@example.com",
                            EmailConfirmed = true,
                            EntityId = 1,
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1",
<<<<<<< HEAD
                            PasswordHash = "AQAAAAEAACcQAAAAEEt9W+uJYmFKJwKl0gxRStnGd+D7lovru4fhmBQuCs9gVO10n+2ILpUVCj5/Dpnp7Q==",
=======
                            PasswordHash = "AQAAAAEAACcQAAAAELqGlH/DmzwFqCQAL4UU76vvi4BSIDyeqycQE+Jx22JXkXrK3dLMqDC+CuKVjD3NqQ==",
>>>>>>> origin
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
<<<<<<< HEAD
                            ConcurrencyStamp = "412fd186-557a-4ccf-bd8c-4915d11022c1",
=======
                            ConcurrencyStamp = "ac627e06-06c0-4d34-abb1-6114795b6cc0",
>>>>>>> origin
                            Email = "user2@example.com",
                            EmailConfirmed = true,
                            EntityId = 1,
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2",
<<<<<<< HEAD
                            PasswordHash = "AQAAAAEAACcQAAAAEPoG+Wn69mVv0kyWqF6DwmsyjketSVxbS+lNP2MURfKjtroGp8fdEvItfkQ9cwgC/w==",
=======
                            PasswordHash = "AQAAAAEAACcQAAAAEC/3jCB4dKs+X9dliMYDuwFAcFZgy1HCTcwrhrxvtl1m939XnXGmi/dADoYBCqjRxw==",
>>>>>>> origin
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
<<<<<<< HEAD
                            ConcurrencyStamp = "85d11133-14c9-45ba-bfa3-f0efb577f302",
=======
                            ConcurrencyStamp = "4a2f68d4-ddd8-4ad5-9989-c05ec5b45bd9",
>>>>>>> origin
                            Email = "user3@example.com",
                            EmailConfirmed = true,
                            EntityId = 0,
                            IsAdmin = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@EXAMPLE.COM",
                            NormalizedUserName = "USER3",
<<<<<<< HEAD
                            PasswordHash = "AQAAAAEAACcQAAAAEL3Df9lksxUofJf7GlDkNg+Ucx4k7WSP2OyJW6ohBoXe7lbT0hgu+QOG6TxdzUiUHQ==",
=======
                            PasswordHash = "AQAAAAEAACcQAAAAEP8JKYuCgH2XygdePi9u3qqekzeuft3wwc1AF4/Seci3zx7hKIXXPXLK6cWcVkS85Q==",
>>>>>>> origin
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "07b95e97-e3c0-45ea-8fcd-a57af1e18be0",
                            Email = "gronstal.larson@gmail.com",
                            EmailConfirmed = true,
                            EntityId = 0,
                            IsAdmin = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "GRONSTAL.LARSON@GMAIL.COM",
                            NormalizedUserName = "GRONSTAL.LARSON@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFBvln3w9UYZ6VUOGAgII+JKYx6UuQRvGEuaBtlq+Bk2P7hDHlLW4ApzLo2igLByng==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Gronstal.Larson@gmail.com"
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

            modelBuilder.Entity("WebApi.Models.ListOfCommits", b =>
                {
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

            modelBuilder.Entity("WebApi.Models.ListOfCommits", b =>
                {
                    b.HasOne("WebApi.Models.Commit", "commit")
                        .WithMany()
                        .HasForeignKey("commitId");

                    b.Navigation("commit");
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
