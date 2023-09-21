﻿// <auto-generated />
using System;
using Book_Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Book_Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230908201645_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogModelTagModel", b =>
                {
                    b.Property<Guid>("BlogsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BlogsId", "TagsID");

                    b.HasIndex("TagsID");

                    b.ToTable("BlogModelTagModel");
                });

            modelBuilder.Entity("Book_Store.Models.Domains.BlogModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeaturedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlHandled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Book_Store.Models.Domains.TagModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BlogModelTagModel", b =>
                {
                    b.HasOne("Book_Store.Models.Domains.BlogModel", null)
                        .WithMany()
                        .HasForeignKey("BlogsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Store.Models.Domains.TagModel", null)
                        .WithMany()
                        .HasForeignKey("TagsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
