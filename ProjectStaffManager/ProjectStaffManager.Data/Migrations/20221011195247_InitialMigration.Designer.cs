﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectStaffManager.Data;

#nullable disable

namespace ProjectStaffManager.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221011195247_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectStaffManager.Models.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectStaffManager.Models.Entities.ProjectStaffMember", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StaffMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DaysWorked")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "StaffMemberId");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("ProjectStafMembers");
                });

            modelBuilder.Entity("ProjectStaffManager.Models.Entities.StaffMember", b =>
                {
                    b.Property<int>("StaffMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffMemberId"), 1L, 1);

                    b.HasKey("StaffMemberId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("ProjectStaffManager.Models.Entities.ProjectStaffMember", b =>
                {
                    b.HasOne("ProjectStaffManager.Models.Entities.Project", "Project")
                        .WithMany("ProjectStaffMembers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectStaffManager.Models.Entities.StaffMember", "StaffMember")
                        .WithMany("ProjectStaffMembers")
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("ProjectStaffManager.Models.Entities.Project", b =>
                {
                    b.Navigation("ProjectStaffMembers");
                });

            modelBuilder.Entity("ProjectStaffManager.Models.Entities.StaffMember", b =>
                {
                    b.Navigation("ProjectStaffMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
