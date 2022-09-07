﻿// <auto-generated />
using System;
using IBlog.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IBlog.DataAccess.Migrations
{
    [DbContext(typeof(IBlogContext))]
    partial class IBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IBlog.Entities.Blogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("PublishDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 9, 7, 19, 30, 14, 337, DateTimeKind.Local).AddTicks(7403));

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs", (string)null);
                });

            modelBuilder.Entity("IBlog.Entities.Categories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("IBlog.Entities.Comments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 9, 7, 19, 30, 14, 338, DateTimeKind.Local).AddTicks(1455));

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("IBlog.Entities.Images", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("IBlog.Entities.Interactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("InteracitonType")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InteractionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 9, 7, 19, 30, 14, 338, DateTimeKind.Local).AddTicks(2830));

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Interactions", (string)null);
                });

            modelBuilder.Entity("IBlog.Entities.SocialLinks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Github")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SocialLinks");
                });

            modelBuilder.Entity("IBlog.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<Guid?>("SocialLinksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("SocialLinksId")
                        .IsUnique()
                        .HasFilter("[SocialLinksId] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("IBlog.Entities.Blogs", b =>
                {
                    b.HasOne("IBlog.Entities.Categories", "Categories")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IBlog.Entities.Users", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IBlog.Entities.Comments", b =>
                {
                    b.HasOne("IBlog.Entities.Blogs", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IBlog.Entities.Users", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IBlog.Entities.Images", b =>
                {
                    b.HasOne("IBlog.Entities.Blogs", "Blog")
                        .WithMany("Images")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("IBlog.Entities.Interactions", b =>
                {
                    b.HasOne("IBlog.Entities.Blogs", "Blog")
                        .WithMany("Interactions")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("IBlog.Entities.Users", b =>
                {
                    b.HasOne("IBlog.Entities.SocialLinks", "SocialLinks")
                        .WithOne("User")
                        .HasForeignKey("IBlog.Entities.Users", "SocialLinksId");

                    b.Navigation("SocialLinks");
                });

            modelBuilder.Entity("IBlog.Entities.Blogs", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("IBlog.Entities.Categories", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("IBlog.Entities.SocialLinks", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("IBlog.Entities.Users", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
