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
    [Migration("20230902123416_SegundaMigracionSistemaTickets")]
    partial class SegundaMigracionSistemaTickets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
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

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Ticket", b =>
                {
                    b.HasOne("Proyect_alfabet_7._0.Models.Tutor", "Creator")
                        .WithMany("TicketsSent")
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

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Admin", b =>
                {
                    b.Navigation("TicketList");
                });

            modelBuilder.Entity("Proyect_alfabet_7._0.Models.Tutor", b =>
                {
                    b.Navigation("StudentsInMonitoring");

                    b.Navigation("TicketsSent");
                });
#pragma warning restore 612, 618
        }
    }
}
