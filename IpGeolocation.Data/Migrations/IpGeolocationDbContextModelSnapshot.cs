// <auto-generated />
using System;
using IpGeolocation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IpGeolocation.Data.Migrations
{
    [DbContext(typeof(IpGeolocationDbContext))]
    partial class IpGeolocationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IpGeolocation.Data.Entities.GeolocationsCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EntityCreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("EntityModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IPsErrorCount")
                        .HasColumnType("int");

                    b.Property<int>("IPsInsertedCount")
                        .HasColumnType("int");

                    b.Property<int>("IPsTotalCount")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("GeolocationsCollections", "Geolocations");
                });
#pragma warning restore 612, 618
        }
    }
}
