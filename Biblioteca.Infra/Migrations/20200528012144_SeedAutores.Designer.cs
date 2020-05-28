﻿// <auto-generated />
using System;
using Biblioteca.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteca.Infra.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    [Migration("20200528012144_SeedAutores")]
    partial class SeedAutores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Biblioteca.Domain.LivroContext.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Autor","Livro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = new DateTime(1952, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Robert Cecil Martin"
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Eric Evans"
                        },
                        new
                        {
                            Id = 3,
                            DataNascimento = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Vaughn Vernon"
                        },
                        new
                        {
                            Id = 4,
                            DataNascimento = new DateTime(1961, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Erich Gamma"
                        },
                        new
                        {
                            Id = 5,
                            DataNascimento = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "John Vlissides"
                        },
                        new
                        {
                            Id = 6,
                            DataNascimento = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Richard Helm"
                        },
                        new
                        {
                            Id = 7,
                            DataNascimento = new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Ralph Johnson"
                        });
                });

            modelBuilder.Entity("Biblioteca.Domain.LivroContext.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(5000);

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("SubTitulo")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Livro","Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.LivroContext.LivroAutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("LivroId");

                    b.ToTable("LivroAutor","Livro");
                });

            modelBuilder.Entity("Biblioteca.Domain.LocacaoContext.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Cliente","Locacao");
                });

            modelBuilder.Entity("Biblioteca.Domain.LocacaoContext.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TeveMulta")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Locacao","Locacao");
                });

            modelBuilder.Entity("Biblioteca.Domain.LivroContext.LivroAutor", b =>
                {
                    b.HasOne("Biblioteca.Domain.LivroContext.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.LivroContext.Livro", "Livro")
                        .WithMany("Autores")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biblioteca.Domain.LocacaoContext.Locacao", b =>
                {
                    b.HasOne("Biblioteca.Domain.LocacaoContext.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Biblioteca.Domain.LocacaoContext.Livro", "Livros", b1 =>
                        {
                            b1.Property<int>("LocacaoId")
                                .HasColumnType("int");

                            b1.Property<int>("LivroId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Serial")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LocacaoId", "LivroId");

                            b1.ToTable("Livro","Locacao");

                            b1.WithOwner()
                                .HasForeignKey("LocacaoId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
