﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyect_alfabet_7._0.Data;

#nullable disable

namespace Proyect_alfabet_7._0.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230903193917_ChangesToContent")]
    partial class ChangesToContent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("ProgressId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isLast")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("ProgressId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("StudentId");

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ResponsableId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ResponsableId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("UserLogin");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserLogin");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.User", b =>
                {
                    b.HasBaseType("Proyect_alfabet_7._0.Models.UserLogin");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Admin", b =>
                {
                    b.HasBaseType("Proyect_alfabet_7._0.Models.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Student", b =>
                {
                    b.HasBaseType("Proyect_alfabet_7._0.Models.User");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasIndex("TutorId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Tutor", b =>
                {
                    b.HasBaseType("Proyect_alfabet_7._0.Models.User");

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Content", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.Lesson", "Lesson")
                        .WithMany("Contents")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyect_alfabet_7._0.Models.Progress", null)
                        .WithMany("FinishedContents")
                        .HasForeignKey("ProgressId");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Lesson", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.Module", "Module")
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Message", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyect_alfabet_7._0.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Progress", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyect_alfabet_7._0.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyect_alfabet_7._0.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Module");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Ticket", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.Tutor", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyect_alfabet_7._0.Models.Admin", "Responsable")
                        .WithMany("TicketList")
                        .HasForeignKey("ResponsableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Responsable");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Student", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.Tutor", null)
                        .WithMany("StudentsInMonitoring")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Lesson", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Module", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Progress", b =>
                {
                    b.Navigation("FinishedContents");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Admin", b =>
                {
                    b.Navigation("TicketList");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Tutor", b =>
                {
                    b.Navigation("StudentsInMonitoring");
                });
#pragma warning restore 612, 618
        }
    }
}
