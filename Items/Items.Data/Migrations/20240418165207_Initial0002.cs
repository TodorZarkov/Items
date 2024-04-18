using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class Initial0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RotationItemsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemVisibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    AcquiredPrice = table.Column<int>(type: "int", nullable: false),
                    AcquiredDate = table.Column<int>(type: "int", nullable: false),
                    AcquireDocument = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Offers = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVisibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationVisibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    GeoLocation = table.Column<int>(type: "int", nullable: false),
                    Border = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Town = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationVisibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationVisibilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GeoLocation = table.Column<Point>(type: "geography", nullable: true),
                    Border = table.Column<Geometry>(type: "geography", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_LocationVisibilities_LocationVisibilityId",
                        column: x => x.LocationVisibilityId,
                        principalTable: "LocationVisibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_AssignerId",
                        column: x => x.AssignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemVisibilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcquiredPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AcquiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    StartSell = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndSell = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAuction = table.Column<bool>(type: "bit", nullable: true),
                    PromisedQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    OnRotation = table.Column<bool>(type: "bit", nullable: false),
                    OnRotationNow = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_ItemVisibilities_ItemVisibilityId",
                        column: x => x.ItemVisibilityId,
                        principalTable: "ItemVisibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SellerEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SellerPhone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BuyerEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BuyerPhone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    BarterName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BarterMainPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BarterDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BarterQuantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    BarterUnitId = table.Column<int>(type: "int", nullable: true),
                    BarterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemMainPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliverDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SellerOk = table.Column<bool>(type: "bit", nullable: false),
                    BuyerOk = table.Column<bool>(type: "bit", nullable: false),
                    BuyerReceived = table.Column<bool>(type: "bit", nullable: false),
                    SellerReceived = table.Column<bool>(type: "bit", nullable: false),
                    SellerComment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BuyerComment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Items_BarterId",
                        column: x => x.BarterId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Units_BarterUnitId",
                        column: x => x.BarterUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCategories",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCategories", x => new { x.CategoryId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemsCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsCategories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Win = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UseBuyerName = table.Column<bool>(type: "bit", nullable: false),
                    UseBuyerEmail = table.Column<bool>(type: "bit", nullable: false),
                    UseBuyerPhone = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    BarterItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BarterQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Items_BarterItemId",
                        column: x => x.BarterItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileIdentifiers",
                columns: table => new
                {
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuyerContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SellerContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileIdentifiers", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileIdentifiers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileIdentifiers_Contracts_BuyerContractId",
                        column: x => x.BuyerContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileIdentifiers_Contracts_SellerContractId",
                        column: x => x.SellerContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileIdentifiers_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileIdentifiers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("07ebfa14-da6f-471f-a29a-c3232eb436c9"), "F4C41BE7-D11A-4DE4-99FB-7C8C0C8C3A26", "Admin", "ADMIN" },
                    { new Guid("b8e078af-5cbc-4360-a99a-0aa387c563e1"), "8208B486-8D31-4E5C-8BB0-05FF07CF81E0", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "RotationItemsDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), 0, "c9037b4e-9232-4448-bf59-2e340aac49c6", "superadmin@items.bg", false, true, null, "SUPERADMIN@ITEMS.BG", "SUPERADMIN@ITEMS.BG", "AQAAAAEAACcQAAAAEOKlbtAtaU6CVU5xNIcbnAokD8GCWmHpI0R2ys/XyGmHUAPbWRxbXnWZzRtLDZCNjg==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VG5NFKHCN2YOVRDWKLO4OC2UC5RDSZC2", false, "superadmin@items.bg" },
                    { new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 0, "aea9a9f8-e1bb-40b5-a8d4-48ba39c8e336", "pesho@items.com", false, true, null, "PESHO@ITEMS.COM", "PESHO@ITEMS.COM", "AQAAAAEAACcQAAAAEJ0V/T7xWBfBPADyTmq1uGyom6SpZNTEnv80QdkdYk8KJfAFhovqm+UgXyD7Wk/C3A==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JMCTVP5CHQTQAB4TCG25FN2NPAKIWOFB", false, "pesho@items.com" },
                    { new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 0, "5a791e32-6035-4b8f-9100-ef55c918c980", "stamat@items.com", false, true, null, "STAMAT@ITEMS.COM", "STAMAT@ITEMS.COM", "AQAAAAEAACcQAAAAEBpQZ/m297suadBXD4Fs4foNdTHZVUkOv9xlCxug850lxi6CknivWE3fdK3RLBAK4A==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5NJNYJBBTCG5SWFQT2RSD7PJR746JEMM", false, "stamat@items.com" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "IsoCode", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "USD", "United States dollar", "$" },
                    { 2, "EUR", "Euro", "€" },
                    { 3, "BGN", "Bulgarian lev", "Lev" }
                });

            migrationBuilder.InsertData(
                table: "ItemVisibilities",
                columns: new[] { "Id", "AcquireDocument", "AcquiredDate", "AcquiredPrice", "AddedOn", "Description", "Location", "ModifiedOn", "Offers", "Owner", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0fb06c25-8e6f-4fd2-a1d9-3cebb4621d2e"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("49abfa42-69f7-4240-a2ef-4e1b3ef7c16c"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("61c89a18-8bda-4d12-9a70-cdb17aedd752"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("8d725141-2b5a-468f-9e1e-61ab0c7f8f5e"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("a33dd8ed-4619-4d18-a25c-2bb25b7bb456"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("a78c2eda-79cb-4acc-a7e4-92e0b45e20eb"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("c0bbcabf-5c24-4ca6-86bc-eca11ae46eb8"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("cbd7bd12-aa21-4e33-95cf-fd9c342db010"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    { new Guid("d009129e-5655-4cd2-ba67-114e2e792b8c"), 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "LocationVisibilities",
                columns: new[] { "Id", "Address", "Border", "Country", "Description", "GeoLocation", "Name", "Town" },
                values: new object[,]
                {
                    { new Guid("21bb8f90-6e2a-4464-b97f-d051e697c278"), 1, 1, 2, 1, 1, 1, 2 },
                    { new Guid("bcf0602c-9f4d-4ca0-8403-460e9dbd6a75"), 1, 1, 2, 1, 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Assign" },
                    { 3, "Close" },
                    { 4, "Delete" }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bug" },
                    { 2, "NewCategory" },
                    { 3, "NewCurrency" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "Pieces", "pcs" },
                    { 2, "Meter", "m" },
                    { 3, "Square Meter", "m2" },
                    { 4, "Kilogram", "kg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b8e078af-5cbc-4360-a99a-0aa387c563e1"), new Guid("04023b09-a38e-48e1-1082-08db8d0db110") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Various" },
                    { 2, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Toys" },
                    { 3, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Cars" },
                    { 4, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Weapons" },
                    { 5, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Puzzles" },
                    { 6, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), "Instruments" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Border", "Country", "Description", "GeoLocation", "LocationVisibilityId", "Name", "Town", "UserId" },
                values: new object[,]
                {
                    { new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "bul. Slivnitsa 9", null, "Bulgaria", null, null, new Guid("21bb8f90-6e2a-4464-b97f-d051e697c278"), "У нас", "Sofia", new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1") },
                    { new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "bul. Slivnitsa 8", null, "Bulgaria", null, null, new Guid("bcf0602c-9f4d-4ca0-8403-460e9dbd6a75"), "Вкъщи", "Sofia", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59") }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "My Room, Cabinet,  Drawer 5" },
                    { 2, null, new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "My Room, Cabinet,  Drawer 6" },
                    { 3, null, new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "My Room, Desk,  Drawer 1" },
                    { 4, null, new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "My Room, Desk,  Drawer 2" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AcquiredDate", "AcquiredPrice", "AddedOn", "CurrencyId", "CurrentPrice", "Deleted", "Description", "DocumentId", "EndSell", "IsAuction", "ItemVisibilityId", "LocationId", "MainPictureId", "ModifiedOn", "Name", "OnRotation", "OnRotationNow", "OwnerId", "PlaceId", "PromisedQuantity", "Quantity", "StartSell", "UnitId" },
                values: new object[,]
                {
                    { new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"), new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8872), 1, null, false, "The Porsche 911 (pronounced Nine Eleven or in German: Neunelf) is a two-door 2+2 high performance rear-engined sports car introduced in September 1964 by Porsche AG of Stuttgart, Germany. It has a rear-mounted flat-six engine and originally a torsion bar suspension. The car has been continuously enhanced through the years but the basic concept has remained unchanged.[1] The engines were air-cooled until the introduction of the 996 series in 1998.[", null, null, null, new Guid("a33dd8ed-4619-4d18-a25c-2bb25b7bb456"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8873), "1997 Porsche 911 Carrera, Red", true, false, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 0m, 1m, null, 1 },
                    { new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8516), 1, 55m, false, "The Ford Mustang Mach 1 is a performance-oriented option package[1] of the Ford Mustang muscle car, originally introduced in August 1968 for the 1969 model year. It was available until 1978, returned briefly in 2003, 2004, and most recently in 2021.\r\n\r\nAs part of a Ford heritage program, the Mach 1 package returned in 2003 as a high-performance version of the New Edge platform. Visual connections to the 1969 model were integrated into the design to pay homage to the original. This generation of the Mach 1 was discontinued after the 2004 model year, with the introduction of the fifth generation Mustang.\r\n\r\nFord first used the name \"Mach 1\" in its 1969 display of a concept called the \"Levacar Mach I\" at the Ford Rotunda. This concept vehicle used a cushion of air as propulsion on a circular dais. ", null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("8d725141-2b5a-468f-9e1e-61ab0c7f8f5e"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8519), "Ford Mustang Mach1 1973", true, false, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 0m, 1m, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"), new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 23m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8940), 1, null, false, "Hollywood Rides 1:24 Scale 2006", null, null, null, new Guid("d009129e-5655-4cd2-ba67-114e2e792b8c"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8940), "Chevrolet Camaro", true, false, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 2, 0m, 1m, null, 1 },
                    { new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8993), 1, null, false, "Hape knob puzzle vehicles", null, null, null, new Guid("cbd7bd12-aa21-4e33-95cf-fd9c342db010"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8993), "puzzle vehicles", true, false, new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 4, 0m, 1m, null, 1 },
                    { new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"), new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(9003), 1, null, false, null, null, null, null, new Guid("49abfa42-69f7-4240-a2ef-4e1b3ef7c16c"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(9004), "Puzzle Cadillac", true, false, new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 4, 0m, 1m, null, 1 },
                    { new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8975), 1, 55m, false, "Puzzle from cars movie. 500pcs", null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("61c89a18-8bda-4d12-9a70-cdb17aedd752"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8975), "Puzzle Cars", true, false, new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 4, 0m, 1m, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8831), 1, 55m, false, "Very cool small SUV", null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a78c2eda-79cb-4acc-a7e4-92e0b45e20eb"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8832), "Toyota Rav 4", true, false, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 0m, 1m, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8852), 1, 55m, false, "Old Cardboard Vehicle from GDR", null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0fb06c25-8e6f-4fd2-a1d9-3cebb4621d2e"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8852), "Trabant", true, false, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 0m, 1m, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 110m, new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8955), 1, 55m, false, "Brown - Welly 24008 - 1/24 scale", null, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("c0bbcabf-5c24-4ca6-86bc-eca11ae46eb8"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 18, 16, 52, 6, 321, DateTimeKind.Utc).AddTicks(8955), "Land Rover Discovery", true, false, new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 3, 0m, 1m, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "ItemsCategories",
                columns: new[] { "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 2, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92") },
                    { 2, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb") },
                    { 2, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45") },
                    { 2, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") },
                    { 2, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") },
                    { 2, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") },
                    { 2, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee") },
                    { 2, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0") },
                    { 2, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c") },
                    { 3, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92") },
                    { 3, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb") },
                    { 3, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45") },
                    { 3, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") },
                    { 3, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") },
                    { 3, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") },
                    { 3, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee") },
                    { 3, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0") },
                    { 3, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c") },
                    { 5, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") },
                    { 5, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") },
                    { 5, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "BarterItemId", "BarterQuantity", "BuyerId", "CurrencyId", "Expires", "ItemId", "Message", "Quantity", "UseBuyerEmail", "UseBuyerName", "UseBuyerPhone", "Value", "Win" },
                values: new object[] { new Guid("71f73811-33dc-45a8-a3fe-a7d5a2363833"), null, null, new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"), null, 1m, false, false, false, 60m, false });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatorId",
                table: "Categories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BarterId",
                table: "Contracts",
                column: "BarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BarterUnitId",
                table: "Contracts",
                column: "BarterUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BuyerId",
                table: "Contracts",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CurrencyId",
                table: "Contracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ItemId",
                table: "Contracts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SellerId",
                table: "Contracts",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UnitId",
                table: "Contracts",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_BuyerContractId",
                table: "FileIdentifiers",
                column: "BuyerContractId");

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_DocumentId",
                table: "FileIdentifiers",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_ItemId",
                table: "FileIdentifiers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_SellerContractId",
                table: "FileIdentifiers",
                column: "SellerContractId");

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_UserId",
                table: "FileIdentifiers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CurrencyId",
                table: "Items",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DocumentId",
                table: "Items",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemVisibilityId",
                table: "Items",
                column: "ItemVisibilityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocationId",
                table: "Items",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OwnerId",
                table: "Items",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlaceId",
                table: "Items",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnitId",
                table: "Items",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCategories_ItemId",
                table: "ItemsCategories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationVisibilityId",
                table: "Locations",
                column: "LocationVisibilityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BarterItemId",
                table: "Offers",
                column: "BarterItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BuyerId",
                table: "Offers",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CurrencyId",
                table: "Offers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ItemId",
                table: "Offers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_LocationId",
                table: "Places",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssigneeId",
                table: "Tickets",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignerId",
                table: "Tickets",
                column: "AssignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AuthorId",
                table: "Tickets",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeId",
                table: "Tickets",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FileIdentifiers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "ItemsCategories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "ItemVisibilities");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LocationVisibilities");
        }
    }
}
