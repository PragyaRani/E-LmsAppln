﻿// <auto-generated />
using System;
using AdminAndInstructor.Microservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdminAndInstructor.Microservice.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221106163730_initialrole")]
    partial class initialrole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiCommonLibrary.DTO.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resource")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int?>("ContentsId")
                        .HasColumnType("int");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicsId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("ContentsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.EStudent", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pin")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("EStudentStudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("EStudentStudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.Course", b =>
                {
                    b.HasOne("ApiCommonLibrary.DTO.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesId");

                    b.HasOne("ApiCommonLibrary.DTO.Content", "Contents")
                        .WithMany()
                        .HasForeignKey("ContentsId");

                    b.HasOne("ApiCommonLibrary.DTO.Topic", "Topics")
                        .WithMany()
                        .HasForeignKey("TopicsId");

                    b.Navigation("Categories");

                    b.Navigation("Contents");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("ApiCommonLibrary.DTO.StudentCourse", b =>
                {
                    b.HasOne("ApiCommonLibrary.DTO.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("ApiCommonLibrary.DTO.EStudent", "EStudent")
                        .WithMany()
                        .HasForeignKey("EStudentStudentId");

                    b.Navigation("Course");

                    b.Navigation("EStudent");
                });
#pragma warning restore 612, 618
        }
    }
}
