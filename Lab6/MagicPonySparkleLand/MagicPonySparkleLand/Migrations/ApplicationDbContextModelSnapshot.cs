﻿// <auto-generated />
using MagicPonySparkleLand.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MagicPonySparkleLand.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MagicPonySparkleLand.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("MessageText");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MagicPonySparkleLand.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("MessageID");

                    b.Property<string>("Name");

                    b.HasKey("UserID");

                    b.HasIndex("MessageID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MagicPonySparkleLand.Models.User", b =>
                {
                    b.HasOne("MagicPonySparkleLand.Models.Message")
                        .WithMany("Users")
                        .HasForeignKey("MessageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
