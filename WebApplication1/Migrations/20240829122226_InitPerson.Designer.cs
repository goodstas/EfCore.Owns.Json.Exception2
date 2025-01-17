﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.AppDB;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240829122226_InitPerson")]
    partial class InitPerson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasDatabaseName("PersonId_Index")
                        .HasFilter("\"IsDeleted\" = False");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Person", b =>
                {
                    b.OwnsOne("WebApplication1.Models.Details", "PersonalDetails", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<bool>("BoolDetail")
                                .HasColumnType("boolean");

                            b1.Property<string>("StrDetail")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.ToJson("PersonalDetails");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");

                            b1.OwnsMany("WebApplication1.Models.SubDetail", "SubDetails", b2 =>
                                {
                                    b2.Property<Guid>("DetailsPersonId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<double>("DoubleSubDetail")
                                        .HasColumnType("double precision");

                                    b2.Property<int>("IntSubDetail")
                                        .HasColumnType("integer");

                                    b2.Property<string>("StrSubDetail")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("DetailsPersonId", "Id");

                                    b2.ToTable("Person");

                                    b2.WithOwner()
                                        .HasForeignKey("DetailsPersonId");
                                });

                            b1.Navigation("SubDetails");
                        });

                    b.Navigation("PersonalDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
