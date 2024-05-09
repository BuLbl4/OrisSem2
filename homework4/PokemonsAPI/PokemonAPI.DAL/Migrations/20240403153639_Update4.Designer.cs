﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PokemonAPI.DAL.EfCore;

#nullable disable

namespace TestEfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240403153639_Update4")]
    partial class Update4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Abilities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Breeding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Breedings");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Moves", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.PokemonTypes", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypesId")
                        .HasColumnType("uuid");

                    b.HasKey("PokemonId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Stat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Types", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Abilities", b =>
                {
                    b.HasOne("TestEfCore.EfCore.Entity.Pokemon", "Pokemon")
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Breeding", b =>
                {
                    b.HasOne("TestEfCore.EfCore.Entity.Pokemon", "Pokemon")
                        .WithOne("Breeding")
                        .HasForeignKey("TestEfCore.EfCore.Entity.Breeding", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Moves", b =>
                {
                    b.HasOne("TestEfCore.EfCore.Entity.Pokemon", "Pokemons")
                        .WithMany("Moves")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.PokemonTypes", b =>
                {
                    b.HasOne("TestEfCore.EfCore.Entity.Pokemon", "Pokemon")
                        .WithMany("Types")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestEfCore.EfCore.Entity.Types", "Types")
                        .WithMany("Pokemon")
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Stat", b =>
                {
                    b.HasOne("TestEfCore.EfCore.Entity.Pokemon", "Pokemon")
                        .WithMany("Stats")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Pokemon", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Breeding");

                    b.Navigation("Moves");

                    b.Navigation("Stats");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("TestEfCore.EfCore.Entity.Types", b =>
                {
                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
