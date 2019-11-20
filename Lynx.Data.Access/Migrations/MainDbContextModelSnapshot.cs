﻿// <auto-generated />
using System;
using Lynx.Data.Access.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lynx.Data.Access.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Lynx.Data.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Balance")
                        .HasColumnType("text");

                    b.Property<string>("BankName")
                        .HasColumnType("text");

                    b.Property<string>("Iban")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Lynx.Data.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("BankId")
                        .HasColumnType("integer");

                    b.Property<int>("BusinessUnitId")
                        .HasColumnType("integer");

                    b.Property<int?>("CashierId")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<double>("Net")
                        .HasColumnType("double precision");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<double>("Paid")
                        .HasColumnType("double precision");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentMethode")
                        .HasColumnType("integer");

                    b.Property<string>("Reference")
                        .HasColumnType("text");

                    b.Property<double>("Reste")
                        .HasColumnType("double precision");

                    b.Property<double>("Shippment")
                        .HasColumnType("double precision");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<double>("Taxe")
                        .HasColumnType("double precision");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("BusinessUnitId");

                    b.HasIndex("CashierId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Lynx.Data.Models.BillItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BillId")
                        .HasColumnType("integer");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<double>("Net")
                        .HasColumnType("double precision");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<double>("Taxe")
                        .HasColumnType("double precision");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.Property<int?>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UnitId");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("Lynx.Data.Models.BusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ManagerId")
                        .HasColumnType("integer");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Reference")
                        .HasColumnType("text");

                    b.Property<double>("Revenue")
                        .HasColumnType("double precision");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ManagerId");

                    b.ToTable("BusinessUnits");
                });

            modelBuilder.Entity("Lynx.Data.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<int>("BusinessUnitId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnitId");

                    b.ToTable("Cashiers");
                });

            modelBuilder.Entity("Lynx.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Lynx.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Revenue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Lynx.Data.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<int>("LimitQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("MaxQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StartQuantity")
                        .HasColumnType("integer");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Lynx.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AlertQuantity")
                        .HasColumnType("boolean");

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("integer");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<double>("LastCost")
                        .HasColumnType("double precision");

                    b.Property<double>("LastPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<int>("MinQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.Property<int?>("TaxeId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<double>("WholeSalePrice")
                        .HasColumnType("double precision");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("GroupId");

                    b.HasIndex("StoreId");

                    b.HasIndex("TaxeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Lynx.Data.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastOperation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Reference")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Lynx.Data.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("BillId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("PartnerId")
                        .HasColumnType("integer");

                    b.Property<string>("Reference")
                        .HasColumnType("text");

                    b.Property<double>("Rest")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Lynx.Data.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BusinessUnitId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnitId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Lynx.Data.Models.Taxe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("Lynx.Data.Models.Transfert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int?>("FromBankId")
                        .HasColumnType("integer");

                    b.Property<int?>("FromCashierId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ToBankId")
                        .HasColumnType("integer");

                    b.Property<int?>("ToCashierId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FromBankId");

                    b.HasIndex("FromCashierId");

                    b.HasIndex("ToBankId");

                    b.HasIndex("ToCashierId");

                    b.HasIndex("UserId");

                    b.ToTable("Transferts");
                });

            modelBuilder.Entity("Lynx.Data.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<double>("PriceMultiplier")
                        .HasColumnType("double precision");

                    b.Property<double>("QuantityMultiplier")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Lynx.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastConnection")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lynx.Data.Models.UserBusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BusinessUnitId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnitId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBusinessUnits");
                });

            modelBuilder.Entity("Lynx.Data.Models.Bill", b =>
                {
                    b.HasOne("Lynx.Data.Models.Bank", "Bank")
                        .WithMany("Bills")
                        .HasForeignKey("BankId");

                    b.HasOne("Lynx.Data.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("Bills")
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.Cashier", "Cashier")
                        .WithMany("Bills")
                        .HasForeignKey("CashierId");

                    b.HasOne("Lynx.Data.Models.Partner", "Partner")
                        .WithMany("Bills")
                        .HasForeignKey("PartnerId");

                    b.HasOne("Lynx.Data.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.BillItem", b =>
                {
                    b.HasOne("Lynx.Data.Models.Bill", null)
                        .WithMany("Items")
                        .HasForeignKey("BillId");

                    b.HasOne("Lynx.Data.Models.Item", "Item")
                        .WithMany("BillItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Lynx.Data.Models.BusinessUnit", b =>
                {
                    b.HasOne("Lynx.Data.Models.Client", "Client")
                        .WithMany("BusinessUnits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.User", "Manager")
                        .WithMany("BusinessUnits")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.Cashier", b =>
                {
                    b.HasOne("Lynx.Data.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("Cashiers")
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.Category", b =>
                {
                    b.HasOne("Lynx.Data.Models.Category", "Parent")
                        .WithMany("Categories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Lynx.Data.Models.Item", b =>
                {
                    b.HasOne("Lynx.Data.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Lynx.Data.Models.Discount", "Discount")
                        .WithMany("Items")
                        .HasForeignKey("DiscountId");

                    b.HasOne("Lynx.Data.Models.Item", "Group")
                        .WithMany("Items")
                        .HasForeignKey("GroupId");

                    b.HasOne("Lynx.Data.Models.Store", "Store")
                        .WithMany("Items")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.Taxe", "Taxe")
                        .WithMany("Items")
                        .HasForeignKey("TaxeId");
                });

            modelBuilder.Entity("Lynx.Data.Models.Payment", b =>
                {
                    b.HasOne("Lynx.Data.Models.Bill", "Bill")
                        .WithMany("Payments")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.Store", b =>
                {
                    b.HasOne("Lynx.Data.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("Stores")
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.Transfert", b =>
                {
                    b.HasOne("Lynx.Data.Models.Bank", "FromBank")
                        .WithMany()
                        .HasForeignKey("FromBankId");

                    b.HasOne("Lynx.Data.Models.Cashier", "FromCashier")
                        .WithMany()
                        .HasForeignKey("FromCashierId");

                    b.HasOne("Lynx.Data.Models.Bank", "ToBank")
                        .WithMany()
                        .HasForeignKey("ToBankId");

                    b.HasOne("Lynx.Data.Models.Cashier", "ToCashier")
                        .WithMany()
                        .HasForeignKey("ToCashierId");

                    b.HasOne("Lynx.Data.Models.User", "User")
                        .WithMany("Transferts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.Unit", b =>
                {
                    b.HasOne("Lynx.Data.Models.Item", "Item")
                        .WithMany("Units")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.User", b =>
                {
                    b.HasOne("Lynx.Data.Models.Client", "Client")
                        .WithMany("Users")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lynx.Data.Models.UserBusinessUnit", b =>
                {
                    b.HasOne("Lynx.Data.Models.BusinessUnit", "BusinessUnit")
                        .WithMany()
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lynx.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
