﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherApp.Models;

namespace TeacherApp.Migrations
{
    [DbContext(typeof(TeacherAppContext))]
    [Migration("20180901131615_mig10")]
    partial class mig10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeacherApp.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int>("Credits");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TeacherApp.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Degree");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Gender");

                    b.Property<string>("Institution");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("TeacherApp.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Published");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewContent");

                    b.Property<int>("TeacherID");

                    b.HasKey("ReviewID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("TeacherApp.Models.TeacherCourse", b =>
                {
                    b.Property<int>("TeacherID");

                    b.Property<int>("CourseID");

                    b.HasKey("TeacherID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("TeacherApp.Models.Teacher", b =>
                {
                    b.HasBaseType("TeacherApp.Models.Person");

                    b.Property<string>("About");

                    b.Property<DateTime>("Graduated");

                    b.Property<string>("ImagePath");

                    b.Property<int>("LessonPrice");

                    b.Property<double>("Rating");

                    b.ToTable("Teachers");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("TeacherApp.Models.Review", b =>
                {
                    b.HasOne("TeacherApp.Models.Teacher")
                        .WithMany("Reviews")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeacherApp.Models.TeacherCourse", b =>
                {
                    b.HasOne("TeacherApp.Models.Teacher", "Teacher")
                        .WithMany("TeachersCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TeacherApp.Models.Course", "Course")
                        .WithMany("TeachersCourses")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
