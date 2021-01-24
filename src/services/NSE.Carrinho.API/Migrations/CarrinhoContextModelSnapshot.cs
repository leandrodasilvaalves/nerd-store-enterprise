﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSE.Carrinho.API.Data;

namespace NSE.Carrinho.API.Migrations
{
    [DbContext(typeof(CarrinhoContext))]
    partial class CarrinhoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("NSE.Carrinho.API.Models.CarrinhoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorTodal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .HasDatabaseName("IDX_Cliente");

                    b.ToTable("CarrinhoCliente");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Models.CarrinhoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarrinhoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.ToTable("CarrinhoItens");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Models.CarrinhoItem", b =>
                {
                    b.HasOne("NSE.Carrinho.API.Models.CarrinhoCliente", "CarrinhoCliente")
                        .WithMany("Itens")
                        .HasForeignKey("CarrinhoId")
                        .IsRequired();

                    b.Navigation("CarrinhoCliente");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Models.CarrinhoCliente", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
