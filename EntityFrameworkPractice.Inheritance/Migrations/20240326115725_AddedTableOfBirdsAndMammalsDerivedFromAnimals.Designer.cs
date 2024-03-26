﻿// <auto-generated />
using EntityFrameworkPractice.Inheritance.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkPractice.Inheritance.Migrations
{
    [DbContext(typeof(InheritanceContext))]
    [Migration("20240326115725_AddedTableOfBirdsAndMammalsDerivedFromAnimals")]
    partial class AddedTableOfBirdsAndMammalsDerivedFromAnimals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Animals", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Bird", b =>
                {
                    b.HasBaseType("EntityFrameworkPractice.Inheritance.Entity.Animal");

                    b.Property<decimal>("Wingspan")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Birds", (string)null);
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Mammal", b =>
                {
                    b.HasBaseType("EntityFrameworkPractice.Inheritance.Entity.Animal");

                    b.Property<int>("FootNumber")
                        .HasColumnType("int");

                    b.ToTable("Mammals", (string)null);
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Employee", b =>
                {
                    b.HasBaseType("EntityFrameworkPractice.Inheritance.Entity.Person");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Manager", b =>
                {
                    b.HasBaseType("EntityFrameworkPractice.Inheritance.Entity.Person");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Bird", b =>
                {
                    b.HasOne("EntityFrameworkPractice.Inheritance.Entity.Animal", null)
                        .WithOne()
                        .HasForeignKey("EntityFrameworkPractice.Inheritance.Entity.Bird", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkPractice.Inheritance.Entity.Mammal", b =>
                {
                    b.HasOne("EntityFrameworkPractice.Inheritance.Entity.Animal", null)
                        .WithOne()
                        .HasForeignKey("EntityFrameworkPractice.Inheritance.Entity.Mammal", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
