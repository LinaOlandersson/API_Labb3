﻿// <auto-generated />
using API_Labb3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Labb3.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    [Migration("20250425070405_correctedManyToMany")]
    partial class correctedManyToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Labb3.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Vara ute i naturen med spö i handen",
                            Title = "Fiska"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fördjupa sig i romaner och facklitteratur",
                            Title = "Läsa böcker"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Skapa program och appar med kod",
                            Title = "Programmera"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Styrketräning och kondition",
                            Title = "Träna på gym"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Utforska nya platser och kulturer",
                            Title = "Resa"
                        });
                });

            modelBuilder.Entity("API_Labb3.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonInterestId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonInterestId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersonInterestId = 1,
                            Url = "www.fiske.nu"
                        },
                        new
                        {
                            Id = 2,
                            PersonInterestId = 1,
                            Url = "www.vattendjur.se"
                        },
                        new
                        {
                            Id = 3,
                            PersonInterestId = 2,
                            Url = "www.koda.nu"
                        },
                        new
                        {
                            Id = 4,
                            PersonInterestId = 3,
                            Url = "www.vagabond.se"
                        },
                        new
                        {
                            Id = 5,
                            PersonInterestId = 4,
                            Url = "www.gofish.org"
                        },
                        new
                        {
                            Id = 6,
                            PersonInterestId = 5,
                            Url = "www.bokladan.se"
                        },
                        new
                        {
                            Id = 7,
                            PersonInterestId = 5,
                            Url = "www.varbergsbibliotek.se"
                        },
                        new
                        {
                            Id = 8,
                            PersonInterestId = 6,
                            Url = "www.codecademy.com"
                        },
                        new
                        {
                            Id = 9,
                            PersonInterestId = 7,
                            Url = "www.gymma.nu"
                        },
                        new
                        {
                            Id = 10,
                            PersonInterestId = 7,
                            Url = "www.superstark.nu"
                        });
                });

            modelBuilder.Entity("API_Labb3.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            FirstName = "Marcus",
                            LastName = "Lindberg",
                            PhoneNumber = "070-1234567"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Sara",
                            LastName = "Ekström",
                            PhoneNumber = "073-9876543"
                        },
                        new
                        {
                            Id = 1,
                            FirstName = "Jenny",
                            LastName = "Olandersson",
                            PhoneNumber = "076-8400716"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Erik",
                            LastName = "Svensson",
                            PhoneNumber = "072-5554321"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Elin",
                            LastName = "Andersson",
                            PhoneNumber = "076-1122334"
                        });
                });

            modelBuilder.Entity("API_Labb3.Models.PersonInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonInterests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestId = 1,
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            InterestId = 3,
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            InterestId = 5,
                            PersonId = 2
                        },
                        new
                        {
                            Id = 4,
                            InterestId = 1,
                            PersonId = 3
                        },
                        new
                        {
                            Id = 5,
                            InterestId = 2,
                            PersonId = 4
                        },
                        new
                        {
                            Id = 6,
                            InterestId = 3,
                            PersonId = 4
                        },
                        new
                        {
                            Id = 7,
                            InterestId = 4,
                            PersonId = 5
                        });
                });

            modelBuilder.Entity("PersonInterest", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsId")
                        .HasColumnType("int");

                    b.HasKey("InterestsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("PersonInterest");
                });

            modelBuilder.Entity("API_Labb3.Models.Link", b =>
                {
                    b.HasOne("API_Labb3.Models.PersonInterest", "PersonInterest")
                        .WithMany("Links")
                        .HasForeignKey("PersonInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInterest");
                });

            modelBuilder.Entity("API_Labb3.Models.PersonInterest", b =>
                {
                    b.HasOne("API_Labb3.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Labb3.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonInterest", b =>
                {
                    b.HasOne("API_Labb3.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Labb3.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Labb3.Models.PersonInterest", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
