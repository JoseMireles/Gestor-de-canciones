﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReproductorMusical;

#nullable disable

namespace ReproductorMusical.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230521134832_CreacionTablasCancionyPlaylist")]
    partial class CreacionTablasCancionyPlaylist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReproductorMusical.Models.Cancion", b =>
                {
                    b.Property<int>("Cancion_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cancion_Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Playlist_Id")
                        .HasColumnType("int");

                    b.Property<string>("Productor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cancion_Id");

                    b.HasIndex("Playlist_Id");

                    b.ToTable("Cancion");
                });

            modelBuilder.Entity("ReproductorMusical.Models.Playlist", b =>
                {
                    b.Property<int>("Playlist_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Playlist_Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Playlist_Id");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("ReproductorMusical.Models.Cancion", b =>
                {
                    b.HasOne("ReproductorMusical.Models.Playlist", "Playlist")
                        .WithMany("Cancion")
                        .HasForeignKey("Playlist_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("ReproductorMusical.Models.Playlist", b =>
                {
                    b.Navigation("Cancion");
                });
#pragma warning restore 612, 618
        }
    }
}
