﻿// <auto-generated />
using System;
using BashTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BashTest.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BashTest.Model.DocumentsPack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MarkId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.ToTable("DocumentsPacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MarkId = 1,
                            Number = 1
                        },
                        new
                        {
                            Id = 2,
                            MarkId = 2,
                            Number = 2
                        },
                        new
                        {
                            Id = 3,
                            MarkId = 1,
                            Number = 3
                        },
                        new
                        {
                            Id = 4,
                            MarkId = 2,
                            Number = 4
                        });
                });

            modelBuilder.Entity("BashTest.Model.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Marks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Mark One",
                            ShortName = "Mark 1"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Mark Two",
                            ShortName = "Mark 2"
                        });
                });

            modelBuilder.Entity("BashTest.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Shifr")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Project 1",
                            Shifr = "pr-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Project 2",
                            Shifr = "pr-2"
                        });
                });

            modelBuilder.Entity("BashTest.Model.ProjectItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Code 1",
                            Name = "Name Item 1",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            Code = "Code 2",
                            Name = "Name Item 2",
                            ParentId = 1,
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 3,
                            Code = "Code 3",
                            Name = "Name Item 3",
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("BashTest.Model.ProjectItemsDocuments", b =>
                {
                    b.Property<int>("ProjectItemId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentsPackId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ProjectItemId", "DocumentsPackId");

                    b.HasIndex("DocumentsPackId");

                    b.ToTable("ProjectItemsDocuments");

                    b.HasData(
                        new
                        {
                            ProjectItemId = 1,
                            DocumentsPackId = 1,
                            Id = 1
                        },
                        new
                        {
                            ProjectItemId = 1,
                            DocumentsPackId = 2,
                            Id = 2
                        },
                        new
                        {
                            ProjectItemId = 2,
                            DocumentsPackId = 3,
                            Id = 3
                        },
                        new
                        {
                            ProjectItemId = 3,
                            DocumentsPackId = 4,
                            Id = 4
                        });
                });

            modelBuilder.Entity("BashTest.Model.DocumentsPack", b =>
                {
                    b.HasOne("BashTest.Model.Mark", "Mark")
                        .WithMany()
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("BashTest.Model.ProjectItem", b =>
                {
                    b.HasOne("BashTest.Model.ProjectItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("BashTest.Model.Project", "Project")
                        .WithMany("ProjectItems")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BashTest.Model.ProjectItemsDocuments", b =>
                {
                    b.HasOne("BashTest.Model.DocumentsPack", "DocumentsPack")
                        .WithMany("DocumentsItems")
                        .HasForeignKey("DocumentsPackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BashTest.Model.ProjectItem", "ProjectItem")
                        .WithMany("DocumentsItems")
                        .HasForeignKey("ProjectItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentsPack");

                    b.Navigation("ProjectItem");
                });

            modelBuilder.Entity("BashTest.Model.DocumentsPack", b =>
                {
                    b.Navigation("DocumentsItems");
                });

            modelBuilder.Entity("BashTest.Model.Project", b =>
                {
                    b.Navigation("ProjectItems");
                });

            modelBuilder.Entity("BashTest.Model.ProjectItem", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("DocumentsItems");
                });
#pragma warning restore 612, 618
        }
    }
}
