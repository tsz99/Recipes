﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipes.Data;

namespace Recipes.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221124090528_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Recipes.Data.AnalyzedInstruction", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeDB_ID")
                        .HasColumnType("int");

                    b.HasKey("DB_ID");

                    b.HasIndex("RecipeDB_ID");

                    b.ToTable("AnalyzedInstructions");
                });

            modelBuilder.Entity("Recipes.Data.AnalyzedInstructionStep", b =>
                {
                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("AnalyzedInstructionId")
                        .HasColumnType("int");

                    b.HasKey("StepId", "AnalyzedInstructionId");

                    b.ToTable("AnalyzedInstructionSteps");
                });

            modelBuilder.Entity("Recipes.Data.Equipment", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DB_ID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Recipes.Data.ExtendedIngredient", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aisle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Consistency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeasuresDB_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameClean")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Original")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeDB_ID")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DB_ID");

                    b.HasIndex("MeasuresDB_ID");

                    b.HasIndex("RecipeDB_ID");

                    b.ToTable("ExtendedIngredients");
                });

            modelBuilder.Entity("Recipes.Data.Ingredient", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("LocalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DB_ID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Recipes.Data.Measures", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MetricDB_ID")
                        .HasColumnType("int");

                    b.Property<int?>("UsDB_ID")
                        .HasColumnType("int");

                    b.HasKey("DB_ID");

                    b.HasIndex("MetricDB_ID");

                    b.HasIndex("UsDB_ID");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("Recipes.Data.Metric", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("UnitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DB_ID");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("Recipes.Data.Recipe", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AggregateLikes")
                        .HasColumnType("int");

                    b.Property<bool>("Cheap")
                        .HasColumnType("bit");

                    b.Property<int>("CookingMinutes")
                        .HasColumnType("int");

                    b.Property<string>("CreatorUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditsText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DairyFree")
                        .HasColumnType("bit");

                    b.Property<string>("Gaps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GlutenFree")
                        .HasColumnType("bit");

                    b.Property<int>("HealthScore")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("License")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LowFodmap")
                        .HasColumnType("bit");

                    b.Property<int>("PreparationMinutes")
                        .HasColumnType("int");

                    b.Property<double>("PricePerServing")
                        .HasColumnType("float");

                    b.Property<int>("ReadyInMinutes")
                        .HasColumnType("int");

                    b.Property<int>("Servings")
                        .HasColumnType("int");

                    b.Property<string>("SourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpoonacularSourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sustainable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vegan")
                        .HasColumnType("bit");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.Property<bool>("VeryHealthy")
                        .HasColumnType("bit");

                    b.Property<bool>("VeryPopular")
                        .HasColumnType("bit");

                    b.Property<int>("WeightWatcherSmartPoints")
                        .HasColumnType("int");

                    b.HasKey("DB_ID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Recipes.Data.RecipeAnalyzedInstruction", b =>
                {
                    b.Property<int>("AnalyzedInstructionId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("AnalyzedInstructionId", "RecipeId");

                    b.ToTable("RecipeAnalyzedInstructions");
                });

            modelBuilder.Entity("Recipes.Data.RecipeExtendedIngredient", b =>
                {
                    b.Property<int>("ExtendedIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("ExtendedIngredientId", "RecipeId");

                    b.ToTable("RecipeExtendedIngredients");
                });

            modelBuilder.Entity("Recipes.Data.Step", b =>
                {
                    b.Property<int>("StepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("StepDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StepId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("Recipes.Data.StepEquipment", b =>
                {
                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("StepId", "EquipmentId");

                    b.ToTable("StepEquipments");
                });

            modelBuilder.Entity("Recipes.Data.StepIngredient", b =>
                {
                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("StepId", "IngredientId");

                    b.ToTable("StepIngredients");
                });

            modelBuilder.Entity("Recipes.Data.Us", b =>
                {
                    b.Property<int>("DB_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("UnitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DB_ID");

                    b.ToTable("Us");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recipes.Data.AnalyzedInstruction", b =>
                {
                    b.HasOne("Recipes.Data.Recipe", null)
                        .WithMany("AnalyzedInstructions")
                        .HasForeignKey("RecipeDB_ID");
                });

            modelBuilder.Entity("Recipes.Data.ExtendedIngredient", b =>
                {
                    b.HasOne("Recipes.Data.Measures", "Measures")
                        .WithMany()
                        .HasForeignKey("MeasuresDB_ID");

                    b.HasOne("Recipes.Data.Recipe", null)
                        .WithMany("ExtendedIngredients")
                        .HasForeignKey("RecipeDB_ID");
                });

            modelBuilder.Entity("Recipes.Data.Measures", b =>
                {
                    b.HasOne("Recipes.Data.Metric", "Metric")
                        .WithMany()
                        .HasForeignKey("MetricDB_ID");

                    b.HasOne("Recipes.Data.Us", "Us")
                        .WithMany()
                        .HasForeignKey("UsDB_ID");
                });
#pragma warning restore 612, 618
        }
    }
}
