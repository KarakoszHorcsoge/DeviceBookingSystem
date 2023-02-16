using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorotyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administrator_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authoroty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorotyLevel = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authoroty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authoroty_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authoroty_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DelayedEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Command = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelayedEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelayedEvent_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DelayedEvent_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceType_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceType_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CommandOriginId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CommandParentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TargetType = table.Column<int>(type: "int", nullable: false),
                    TargetId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SecondTargetType = table.Column<int>(type: "int", nullable: true),
                    SecondTargetId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CommandType = table.Column<int>(type: "int", nullable: false),
                    Command = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentEventLogId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ChildEventLogId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLog_Administrator_CommandOriginId",
                        column: x => x.CommandOriginId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventLog_Administrator_CommandParentId",
                        column: x => x.CommandParentId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventLog_EventLog_ParentEventLogId",
                        column: x => x.ParentEventLogId,
                        principalTable: "EventLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonGroup_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonGroup_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsBorrowable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CardPrefix = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonType_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonType_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdministratorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preference_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preference_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preference_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    administrator = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reception", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reception_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reception_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reception_Administrator_administrator",
                        column: x => x.administrator,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAbleToBorrow = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NeptunCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdNumberType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdUsername = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comment = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonGroupId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PersonTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonGroup_PersonGroupId",
                        column: x => x.PersonGroupId,
                        principalTable: "PersonGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExperationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OwnerId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdministratorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Card_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Person_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DeviceStatus = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeviceTypeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReceptionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PosesserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_Reception_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Reception",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BorrowRestriction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReceptionId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeviceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeviceTypeId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRestriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowRestriction_Administrator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BorrowRestriction_Administrator_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BorrowRestriction_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowRestriction_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowRestriction_Reception_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Reception",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_AuthorotyId",
                table: "Administrator",
                column: "AuthorotyId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_CreatorId",
                table: "Administrator",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_ModifierId",
                table: "Administrator",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Authoroty_CreatorId",
                table: "Authoroty",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Authoroty_ModifierId",
                table: "Authoroty",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Authoroty_Name",
                table: "Authoroty",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRestriction_CreatorId",
                table: "BorrowRestriction",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRestriction_DeviceId",
                table: "BorrowRestriction",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRestriction_DeviceTypeId",
                table: "BorrowRestriction",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRestriction_ModifierId",
                table: "BorrowRestriction",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRestriction_ReceptionId",
                table: "BorrowRestriction",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_AdministratorId",
                table: "Card",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CreatorId",
                table: "Card",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_ModifierId",
                table: "Card",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_OwnerId",
                table: "Card",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayedEvent_CreatorId",
                table: "DelayedEvent",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayedEvent_ModifierId",
                table: "DelayedEvent",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_CreatorId",
                table: "Device",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceTypeId",
                table: "Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_ModifierId",
                table: "Device",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_PersonId",
                table: "Device",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_ReceptionId",
                table: "Device",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceType_CreatorId",
                table: "DeviceType",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceType_ModifierId",
                table: "DeviceType",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_CommandOriginId",
                table: "EventLog",
                column: "CommandOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_CommandParentId",
                table: "EventLog",
                column: "CommandParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_ParentEventLogId",
                table: "EventLog",
                column: "ParentEventLogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CreatorId",
                table: "Person",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ModifierId",
                table: "Person",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonGroupId",
                table: "Person",
                column: "PersonGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonTypeId",
                table: "Person",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroup_CreatorId",
                table: "PersonGroup",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroup_ModifierId",
                table: "PersonGroup",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonType_CreatorId",
                table: "PersonType",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonType_ModifierId",
                table: "PersonType",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_AdministratorId",
                table: "Preference",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_CreatorId",
                table: "Preference",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_ModifierId",
                table: "Preference",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_administrator",
                table: "Reception",
                column: "administrator");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_CreatorId",
                table: "Reception",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_ModifierId",
                table: "Reception",
                column: "ModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Authoroty_AuthorotyId",
                table: "Administrator",
                column: "AuthorotyId",
                principalTable: "Authoroty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Authoroty_AuthorotyId",
                table: "Administrator");

            migrationBuilder.DropTable(
                name: "BorrowRestriction");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "DelayedEvent");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropTable(
                name: "PersonGroup");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "Authoroty");

            migrationBuilder.DropTable(
                name: "Administrator");
        }
    }
}
