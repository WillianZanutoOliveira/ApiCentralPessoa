﻿// <auto-generated />
using System;
using ApiCentralPessoa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCentralPessoa.Migrations
{
    [DbContext(typeof(CentralPessoaContext))]
    partial class CentralPessoaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiCentralPessoa.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposTelefones", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("ApiCentralPessoa.Models.Pessoa");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataFalecimento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaeId")
                        .HasColumnType("int");

                    b.Property<int>("PaiId")
                        .HasColumnType("int");

                    b.HasIndex("MaeId")
                        .IsUnique();

                    b.HasIndex("PaiId")
                        .IsUnique();

                    b.ToTable("PessoasFisicas", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("ApiCentralPessoa.Models.Pessoa");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("PessoasJuridicas", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.PessoaTelefone", b =>
                {
                    b.HasBaseType("ApiCentralPessoa.Models.Pessoa");

                    b.Property<bool>("SMS")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoTelefoneId")
                        .HasColumnType("int");

                    b.Property<bool>("WhatsApp")
                        .HasColumnType("tinyint(1)");

                    b.HasIndex("TipoTelefoneId");

                    b.ToTable("PessoasTelefone", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.Mae", b =>
                {
                    b.HasBaseType("ApiCentralPessoa.Models.PessoaFisica");

                    b.Property<string>("NomeMae")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Maes", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.Pai", b =>
                {
                    b.HasBaseType("ApiCentralPessoa.Models.PessoaFisica");

                    b.Property<string>("NomePai")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.Endereco", b =>
                {
                    b.HasOne("ApiCentralPessoa.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.PessoaFisica", b =>
                {
                    b.HasOne("ApiCentralPessoa.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.PessoaFisica", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCentralPessoa.Models.Mae", "Mae")
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.PessoaFisica", "MaeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCentralPessoa.Models.Pai", "Pai")
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.PessoaFisica", "PaiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mae");

                    b.Navigation("Pai");
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.PessoaJuridica", b =>
                {
                    b.HasOne("ApiCentralPessoa.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.PessoaJuridica", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.PessoaTelefone", b =>
                {
                    b.HasOne("ApiCentralPessoa.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.PessoaTelefone", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCentralPessoa.Models.TipoTelefone", "TipoTelefone")
                        .WithMany()
                        .HasForeignKey("TipoTelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTelefone");
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.Mae", b =>
                {
                    b.HasOne("ApiCentralPessoa.Models.PessoaFisica", null)
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.Mae", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiCentralPessoa.Models.Pai", b =>
                {
                    b.HasOne("ApiCentralPessoa.Models.PessoaFisica", null)
                        .WithOne()
                        .HasForeignKey("ApiCentralPessoa.Models.Pai", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
