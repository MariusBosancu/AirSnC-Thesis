﻿// <auto-generated />
using AirSnC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirSnC.Migrations.ProductsDb
{
    [DbContext(typeof(ProductsDbContext))]
    partial class ProductsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AirSnC.Models.Products", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Picture1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture2")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture3")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Name");

                    b.ToTable("Productss");
                });
#pragma warning restore 612, 618
        }
    }
}
