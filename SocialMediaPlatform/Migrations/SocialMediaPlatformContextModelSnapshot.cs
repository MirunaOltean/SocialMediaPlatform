﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMediaPlatform.DBContext;

#nullable disable

namespace SocialMediaPlatform.Migrations
{
    [DbContext(typeof(SocialMediaPlatformContext))]
    partial class SocialMediaPlatformContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialMediaPlatform.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("TimeStamp")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("SocialMediaPlatform.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateOnly>("TimeStamp")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("SocialMediaPlatform.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SocialMediaPlatform.Models.Comment", b =>
                {
                    b.HasOne("SocialMediaPlatform.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK_Comment_User");

                    b.HasOne("SocialMediaPlatform.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK_Comment_Post");

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialMediaPlatform.Models.Post", b =>
                {
                    b.HasOne("SocialMediaPlatform.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK_Post_User");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("SocialMediaPlatform.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SocialMediaPlatform.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
