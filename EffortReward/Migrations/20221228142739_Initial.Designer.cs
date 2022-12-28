﻿// <auto-generated />
using System;
using EffortReward.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EffortReward.Migrations
{
    [DbContext(typeof(WeeklyHistoryContext))]
    [Migration("20221228142739_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EffortReward.Data.Entities.WeeklyHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FoodQuality")
                        .HasColumnType("integer");

                    b.Property<int>("Junk")
                        .HasColumnType("integer");

                    b.Property<int>("QntJJ")
                        .HasColumnType("integer");

                    b.Property<int>("QntMM")
                        .HasColumnType("integer");

                    b.Property<int>("Result")
                        .HasColumnType("integer");

                    b.Property<int>("Strategy")
                        .HasColumnType("integer");

                    b.Property<int>("Sugar")
                        .HasColumnType("integer");

                    b.Property<double>("Variation")
                        .HasColumnType("double precision");

                    b.Property<int>("WeekNum")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("WeeklyHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
