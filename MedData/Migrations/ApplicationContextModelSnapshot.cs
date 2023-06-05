﻿// <auto-generated />
using System;
using MedData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedData.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedData.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MedData.Entities.AnamnesisVitae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Heredity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.Property<string>("LifeAnamnesis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PastDiseases")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkPeriod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HospitalizationId")
                        .IsUnique();

                    b.ToTable("AnamnesisVitae");
                });

            modelBuilder.Entity("MedData.Entities.Cabinet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("MedData.Entities.Chamber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BedCount")
                        .HasColumnType("integer");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Chambers");
                });

            modelBuilder.Entity("MedData.Entities.Checkup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Genitourinary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Heart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Hormones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.Property<string>("Nervous")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Skin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Stomach")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("View")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HospitalizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Checkup");
                });

            modelBuilder.Entity("MedData.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MedData.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClinicalDiagnosis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EtiologyPathogenesis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<int>("MkbId")
                        .HasColumnType("integer");

                    b.Property<string>("Rationale")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SyndromicDiagnosis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HospitalizationId");

                    b.HasIndex("MkbId");

                    b.ToTable("Diagnosis");
                });

            modelBuilder.Entity("MedData.Entities.Examination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CabinetId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ExaminationTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.HasIndex("ExaminationTypeId");

                    b.HasIndex("HospitalizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("MedData.Entities.ExaminationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExaminationType");
                });

            modelBuilder.Entity("MedData.Entities.Hospitalization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("HospitalizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HospitalizationMethod")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("MedCardId")
                        .HasColumnType("integer");

                    b.Property<string>("ShortDiagnosis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedCardId");

                    b.ToTable("Hospitalizations");
                });

            modelBuilder.Entity("MedData.Entities.MedCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ExtraPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("MainPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OmsNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.ToTable("MedCards");
                });

            modelBuilder.Entity("MedData.Entities.Mkb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Mkb");
                });

            modelBuilder.Entity("MedData.Entities.PatientInChamber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChamberId")
                        .HasColumnType("integer");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChamberId");

                    b.HasIndex("HospitalizationId");

                    b.ToTable("PatientInChambers");
                });

            modelBuilder.Entity("MedData.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("MedData.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.Property<int>("NewChamberId")
                        .HasColumnType("integer");

                    b.Property<int>("OldChamberId")
                        .HasColumnType("integer");

                    b.Property<string>("Spor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HospitalizationId");

                    b.HasIndex("NewChamberId");

                    b.HasIndex("OldChamberId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MedData.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsStopped")
                        .HasColumnType("boolean");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Result")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Volume")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HospitalizationId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("MedData.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedData.Entities.AnamnesisVitae", b =>
                {
                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithOne("AnamnesisVitae")
                        .HasForeignKey("MedData.Entities.AnamnesisVitae", "HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospitalization");
                });

            modelBuilder.Entity("MedData.Entities.Cabinet", b =>
                {
                    b.HasOne("MedData.Entities.Department", "Department")
                        .WithMany("Cabinets")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MedData.Entities.Chamber", b =>
                {
                    b.HasOne("MedData.Entities.User", "User")
                        .WithMany("Chambers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedData.Entities.Checkup", b =>
                {
                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithMany("Checkups")
                        .HasForeignKey("HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.User", "User")
                        .WithMany("Checkup")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospitalization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedData.Entities.Diagnosis", b =>
                {
                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithMany("Diagnosis")
                        .HasForeignKey("HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.Mkb", "Mkb")
                        .WithMany("DiagnosisCollection")
                        .HasForeignKey("MkbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospitalization");

                    b.Navigation("Mkb");
                });

            modelBuilder.Entity("MedData.Entities.Examination", b =>
                {
                    b.HasOne("MedData.Entities.Cabinet", "Cabinet")
                        .WithMany("Examinations")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.ExaminationType", "ExaminationType")
                        .WithMany("Examinations")
                        .HasForeignKey("ExaminationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithMany("Examinations")
                        .HasForeignKey("HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.User", "User")
                        .WithMany("Examinations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("ExaminationType");

                    b.Navigation("Hospitalization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedData.Entities.Hospitalization", b =>
                {
                    b.HasOne("MedData.Entities.MedCard", "MedCard")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("MedCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedCard");
                });

            modelBuilder.Entity("MedData.Entities.MedCard", b =>
                {
                    b.HasOne("MedData.Entities.Address", "Address")
                        .WithMany("Cards")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MedData.Entities.PatientInChamber", b =>
                {
                    b.HasOne("MedData.Entities.Chamber", "Chamber")
                        .WithMany("PatientsInChamber")
                        .HasForeignKey("ChamberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithMany("PatientInChambers")
                        .HasForeignKey("HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chamber");

                    b.Navigation("Hospitalization");
                });

            modelBuilder.Entity("MedData.Entities.Transaction", b =>
                {
                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithMany("Transactions")
                        .HasForeignKey("HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.Chamber", "NewChamber")
                        .WithMany("NewChamber")
                        .HasForeignKey("NewChamberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.Chamber", "OldChamber")
                        .WithMany("OldChamber")
                        .HasForeignKey("OldChamberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospitalization");

                    b.Navigation("NewChamber");

                    b.Navigation("OldChamber");
                });

            modelBuilder.Entity("MedData.Entities.Treatment", b =>
                {
                    b.HasOne("MedData.Entities.Hospitalization", "Hospitalization")
                        .WithMany("Treatments")
                        .HasForeignKey("HospitalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospitalization");
                });

            modelBuilder.Entity("MedData.Entities.User", b =>
                {
                    b.HasOne("MedData.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedData.Entities.Position", "Position")
                        .WithMany("Users")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("MedData.Entities.Address", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("MedData.Entities.Cabinet", b =>
                {
                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("MedData.Entities.Chamber", b =>
                {
                    b.Navigation("NewChamber");

                    b.Navigation("OldChamber");

                    b.Navigation("PatientsInChamber");
                });

            modelBuilder.Entity("MedData.Entities.Department", b =>
                {
                    b.Navigation("Cabinets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MedData.Entities.ExaminationType", b =>
                {
                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("MedData.Entities.Hospitalization", b =>
                {
                    b.Navigation("AnamnesisVitae")
                        .IsRequired();

                    b.Navigation("Checkups");

                    b.Navigation("Diagnosis");

                    b.Navigation("Examinations");

                    b.Navigation("PatientInChambers");

                    b.Navigation("Transactions");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("MedData.Entities.MedCard", b =>
                {
                    b.Navigation("Hospitalizations");
                });

            modelBuilder.Entity("MedData.Entities.Mkb", b =>
                {
                    b.Navigation("DiagnosisCollection");
                });

            modelBuilder.Entity("MedData.Entities.Position", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MedData.Entities.User", b =>
                {
                    b.Navigation("Chambers");

                    b.Navigation("Checkup");

                    b.Navigation("Examinations");
                });
#pragma warning restore 612, 618
        }
    }
}
