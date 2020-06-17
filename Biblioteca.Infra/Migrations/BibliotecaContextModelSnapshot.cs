﻿// <auto-generated />
using System;
using Biblioteca.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biblioteca.Infra.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    partial class BibliotecaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("varchar(300)")
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

            modelBuilder.Entity("Biblioteca.Domain.LivroContext.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Estado","Livro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Ótimo"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Bom"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Ruim"
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
                        .HasColumnType("varchar(5000)")
                        .HasMaxLength(5000);

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Livro","Livro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2002,
                            EstadoId = 1,
                            Serial = "0000000001",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 2,
                            Ano = 2009,
                            EstadoId = 1,
                            Serial = "0000000002",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 3,
                            Ano = 2011,
                            EstadoId = 3,
                            Serial = "0000000003",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 4,
                            Ano = 2017,
                            EstadoId = 2,
                            Serial = "0000000004",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 5,
                            Ano = 2019,
                            EstadoId = 1,
                            Serial = "0000000005",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 6,
                            Ano = 2003,
                            EstadoId = 3,
                            Serial = "0000000006",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 7,
                            Ano = 2013,
                            EstadoId = 2,
                            Serial = "0000000007",
                            Situacao = 0
                        },
                        new
                        {
                            Id = 8,
                            Ano = 2016,
                            EstadoId = 3,
                            Serial = "0000000008",
                            Situacao = 0
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AutorId = 1,
                            LivroId = 1
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 1,
                            LivroId = 2
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 1,
                            LivroId = 3
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 1,
                            LivroId = 4
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 1,
                            LivroId = 5
                        },
                        new
                        {
                            Id = 6,
                            AutorId = 2,
                            LivroId = 6
                        },
                        new
                        {
                            Id = 7,
                            AutorId = 3,
                            LivroId = 7
                        },
                        new
                        {
                            Id = 8,
                            AutorId = 3,
                            LivroId = 8
                        });
                });

            modelBuilder.Entity("Biblioteca.Domain.LocacaoContext.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

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

                    b.Property<bool>("Devolvido")
                        .HasColumnType("bit");

                    b.Property<bool>("TeveMulta")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Locacao","Locacao");
                });

            modelBuilder.Entity("Biblioteca.Domain.LivroContext.Livro", b =>
                {
                    b.HasOne("Biblioteca.Domain.LivroContext.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Biblioteca.Domain.LivroContext.ValueObjects.Titulo", "Titulo", b1 =>
                        {
                            b1.Property<int>("LivroId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Principal")
                                .IsRequired()
                                .HasColumnName("Titulo")
                                .HasColumnType("varchar(300)")
                                .HasMaxLength(300);

                            b1.Property<string>("SubTitulo")
                                .HasColumnName("SubTitulo")
                                .HasColumnType("varchar(300)")
                                .HasMaxLength(300);

                            b1.HasKey("LivroId");

                            b1.ToTable("Livro");

                            b1.WithOwner()
                                .HasForeignKey("LivroId");

                            b1.HasData(
                                new
                                {
                                    LivroId = 1,
                                    Principal = "Agile Software Development, Principles, Patterns, and Practices"
                                },
                                new
                                {
                                    LivroId = 2,
                                    Principal = "Clean Code",
                                    SubTitulo = "A Handbook of Agile Software Craftsmanship"
                                },
                                new
                                {
                                    LivroId = 3,
                                    Principal = "The Clean Coder",
                                    SubTitulo = "A Code Of Conduct For Professional Programmers"
                                },
                                new
                                {
                                    LivroId = 4,
                                    Principal = "Clean Architecture",
                                    SubTitulo = "A Craftsman's Guide to Software Structure and Design"
                                },
                                new
                                {
                                    LivroId = 5,
                                    Principal = "Clean Agile",
                                    SubTitulo = "Back to Basics"
                                },
                                new
                                {
                                    LivroId = 6,
                                    Principal = "Domain-Driven Design",
                                    SubTitulo = "Tackling Complexity in the Heart of Software"
                                },
                                new
                                {
                                    LivroId = 7,
                                    Principal = "Implementing Domain-Driven Design"
                                },
                                new
                                {
                                    LivroId = 8,
                                    Principal = "Domain-Driven Design Distilled"
                                });
                        });
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
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Id")
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("varchar(300)")
                                .HasMaxLength(300);

                            b1.Property<int>("LivroId")
                                .HasColumnType("int");

                            b1.Property<int>("LocacaoId")
                                .HasColumnType("int");

                            b1.Property<string>("SubTitulo")
                                .HasColumnType("varchar(300)")
                                .HasMaxLength(300);

                            b1.Property<string>("Titulo")
                                .IsRequired()
                                .HasColumnType("varchar(300)")
                                .HasMaxLength(300);

                            b1.HasKey("Id");

                            b1.HasIndex("LocacaoId");

                            b1.ToTable("Livro","Locacao");

                            b1.WithOwner()
                                .HasForeignKey("LocacaoId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
