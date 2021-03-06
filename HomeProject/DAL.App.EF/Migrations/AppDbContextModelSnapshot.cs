﻿// <auto-generated />
using System;
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.AppUserInPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<int>("AppUserPositionId");

                    b.Property<DateTime>("From");

                    b.Property<DateTime?>("Until");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AppUserPositionId");

                    b.ToTable("AppUsersInPositions");
                });

            modelBuilder.Entity("Domain.AppUserOnObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<DateTime?>("From");

                    b.Property<DateTime?>("Until");

                    b.Property<int>("WorkObjectId");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("WorkObjectId");

                    b.ToTable("AppUsersOnObjects");
                });

            modelBuilder.Entity("Domain.AppUserPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserPositionValueId");

                    b.HasKey("Id");

                    b.HasIndex("AppUserPositionValueId");

                    b.ToTable("AppUsersPositions");
                });

            modelBuilder.Entity("Domain.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ArrivalFee");

                    b.Property<int>("ClientId");

                    b.Property<int?>("CommentId");

                    b.Property<DateTime>("DateTime");

                    b.Property<decimal?>("FinalSum");

                    b.Property<string>("InvoiceNr")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<decimal?>("SumWithOutTaxes");

                    b.Property<decimal?>("TaxPercent");

                    b.Property<int>("WorkObjectId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CommentId");

                    b.HasIndex("WorkObjectId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Domain.BillLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("BillId");

                    b.Property<decimal?>("DiscountPercent");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Sum");

                    b.Property<decimal?>("SumWithDiscount");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("BillLines");
                });

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("ClientGroupId");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(128);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("From");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("ClientGroupId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Domain.ClientGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DescriptionId");

                    b.Property<decimal?>("DiscountPercent");

                    b.Property<int>("NameId");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.HasIndex("NameId");

                    b.ToTable("ClientGroups");
                });

            modelBuilder.Entity("Domain.Identity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Domain.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTime?>("HiringDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTime?>("LeftJob");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.MultiLangString", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(10240);

                    b.HasKey("Id");

                    b.ToTable("MultiLangStrings");
                });

            modelBuilder.Entity("Domain.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillId");

                    b.Property<int>("PaymentMethodId");

                    b.Property<DateTime>("PaymentTime");

                    b.Property<decimal>("Sum");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Domain.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PaymentMethodValueId");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodValueId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Price");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(128);

                    b.Property<int>("ProductNameId");

                    b.HasKey("Id");

                    b.HasIndex("ProductNameId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.ProductForClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<decimal>("Count");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsForClients");
                });

            modelBuilder.Entity("Domain.ProductService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DescriptionId");

                    b.Property<int>("ProductForClientId");

                    b.Property<int>("WorkObjectId");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.HasIndex("ProductForClientId");

                    b.HasIndex("WorkObjectId");

                    b.ToTable("ProductsServices");
                });

            modelBuilder.Entity("Domain.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Culture")
                        .HasMaxLength(5);

                    b.Property<int>("MultiLangStringId");

                    b.Property<string>("Value")
                        .HasMaxLength(10240);

                    b.HasKey("Id");

                    b.HasIndex("MultiLangStringId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Domain.WorkObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime?>("From");

                    b.Property<DateTime?>("Until");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("WorkObjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.AppUserInPosition", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("AppUserInPositions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.AppUserPosition", "AppUserPosition")
                        .WithMany("AppUsersInPosition")
                        .HasForeignKey("AppUserPositionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.AppUserOnObject", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("AppUserOnObjects")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.WorkObject", "WorkObject")
                        .WithMany("AppUsersOnObject")
                        .HasForeignKey("WorkObjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.AppUserPosition", b =>
                {
                    b.HasOne("Domain.MultiLangString", "AppUserPositionValue")
                        .WithMany()
                        .HasForeignKey("AppUserPositionValueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Bill", b =>
                {
                    b.HasOne("Domain.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.MultiLangString", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.WorkObject", "WorkObject")
                        .WithMany("Bills")
                        .HasForeignKey("WorkObjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.BillLine", b =>
                {
                    b.HasOne("Domain.Bill", "Bill")
                        .WithMany("BillLines")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.MultiLangString", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Client", b =>
                {
                    b.HasOne("Domain.ClientGroup", "ClientGroup")
                        .WithMany("Clients")
                        .HasForeignKey("ClientGroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ClientGroup", b =>
                {
                    b.HasOne("Domain.MultiLangString", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.MultiLangString", "Name")
                        .WithMany()
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Payment", b =>
                {
                    b.HasOne("Domain.Bill", "Bill")
                        .WithMany("Payments")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.PaymentMethod", "PaymentMethod")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.PaymentMethod", b =>
                {
                    b.HasOne("Domain.MultiLangString", "PaymentMethodValue")
                        .WithMany()
                        .HasForeignKey("PaymentMethodValueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("Domain.MultiLangString", "ProductName")
                        .WithMany()
                        .HasForeignKey("ProductNameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ProductForClient", b =>
                {
                    b.HasOne("Domain.Client", "Client")
                        .WithMany("ProductsForClient")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("ProductForClients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.ProductService", b =>
                {
                    b.HasOne("Domain.MultiLangString", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.ProductForClient", "ProductForClient")
                        .WithMany("ProductServices")
                        .HasForeignKey("ProductForClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.WorkObject", "WorkObject")
                        .WithMany("ProductsServices")
                        .HasForeignKey("WorkObjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Translation", b =>
                {
                    b.HasOne("Domain.MultiLangString", "MultiLangString")
                        .WithMany("Translations")
                        .HasForeignKey("MultiLangStringId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.WorkObject", b =>
                {
                    b.HasOne("Domain.Client", "Client")
                        .WithMany("WorkObjects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
