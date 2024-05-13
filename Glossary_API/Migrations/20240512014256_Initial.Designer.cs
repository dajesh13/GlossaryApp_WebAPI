﻿// <auto-generated />
using System;
using Glossary_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Glossary_API.Migrations
{
    [DbContext(typeof(GlossaryDbContext))]
    [Migration("20240512014256_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Glossary_API.Definition", b =>
                {
                    b.Property<Guid>("DefinitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("GlossaryDefinition")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("DefinitionId");

                    b.ToTable("Definitions");
                });

            modelBuilder.Entity("Glossary_API.Term", b =>
                {
                    b.Property<Guid>("TermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("GlossaryTerm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("TermId");

                    b.HasIndex("DefinitionId");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Glossary_API.Term", b =>
                {
                    b.HasOne("Glossary_API.Definition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId");

                    b.Navigation("Definition");
                });
#pragma warning restore 612, 618
        }
    }
}