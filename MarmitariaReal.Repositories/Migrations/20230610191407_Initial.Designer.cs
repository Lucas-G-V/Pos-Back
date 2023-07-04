﻿// <auto-generated />
using System;
using MarmitariaReal.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarmitariaReal.Repositories.Migrations
{
    [DbContext(typeof(ProdutosDbContext))]
    [Migration("20230610191407_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarmitariaReal.Domain.Entities.Receita", b =>
                {
                    b.Property<Guid>("ReceitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("UrlImagem")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("ReceitaId");

                    b.ToTable("Receitas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
