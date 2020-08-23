using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JBProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "dbo",
                columns: table => new
                {
                    lcountryid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lcountry = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    addedon = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__6489F65FA62BE0C8", x => x.lcountryid);
                });

            migrationBuilder.CreateTable(
                name: "PlanType",
                schema: "dbo",
                columns: table => new
                {
                    PlanID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanType__755C22D7C20AC035", x => x.PlanID);
                });

            migrationBuilder.CreateTable(
                name: "RoleMaster",
                schema: "dbo",
                columns: table => new
                {
                    RoleID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoleMast__8AFACE3ACDFB82B6", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "dbo",
                columns: table => new
                {
                    UserTypeID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "dbo",
                columns: table => new
                {
                    lstateid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lcountryid = table.Column<short>(nullable: true),
                    lstate = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    ltype = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ltin = table.Column<byte>(nullable: false),
                    lstatecode = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    addedon = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__State__8868BBCC77CE0983", x => x.lstateid);
                    table.ForeignKey(
                        name: "FK__State__lcountryi__24485945",
                        column: x => x.lcountryid,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "lcountryid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                schema: "dbo",
                columns: table => new
                {
                    UserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailID = table.Column<string>(maxLength: 256, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    MobileNo = table.Column<long>(nullable: true),
                    UserTypeID = table.Column<short>(nullable: false),
                    PlanID = table.Column<short>(nullable: false),
                    OTP = table.Column<string>(maxLength: 15, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false, defaultValueSql: "(N'')"),
                    LastName = table.Column<string>(maxLength: 256, nullable: false, defaultValueSql: "(N'')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserMast__1788CCACAFF82403", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__UserMaste__PlanI__2A01329B",
                        column: x => x.PlanID,
                        principalSchema: "dbo",
                        principalTable: "PlanType",
                        principalColumn: "PlanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserMaste__UserT__2AF556D4",
                        column: x => x.UserTypeID,
                        principalSchema: "dbo",
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    lcityid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lstateid = table.Column<short>(nullable: true),
                    lcountryid = table.Column<short>(nullable: true),
                    lstate = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    ltype = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ltin = table.Column<byte>(nullable: false),
                    lstatecode = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    addedon = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City__E0907D6E18F908AB", x => x.lcityid);
                    table.ForeignKey(
                        name: "FK__City__lcountryid__3572E547",
                        column: x => x.lcountryid,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "lcountryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__City__lstateid__347EC10E",
                        column: x => x.lstateid,
                        principalSchema: "dbo",
                        principalTable: "State",
                        principalColumn: "lstateid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Bank_Details",
                schema: "dbo",
                columns: table => new
                {
                    AccountID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    Beneficiary_AccountNo = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Beneficiary_AccountType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IFSC_Code = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    Beneficiary_Name = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    Cancelled_Cheque = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsComplete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Ban__349DA586763060CC", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK__User_Bank__UserI__253C7D7E",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "UserMaster",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Company_Details",
                schema: "dbo",
                columns: table => new
                {
                    CompanyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    Company_Name = table.Column<string>(unicode: false, maxLength: 160, nullable: false),
                    Company_EmailID = table.Column<string>(unicode: false, maxLength: 320, nullable: false),
                    website = table.Column<bool>(nullable: true),
                    website_url = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Company_GSTIN = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    BillingAddress_Line1 = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    BillingAddress_Line2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BillingAddress_PinCode = table.Column<int>(nullable: false),
                    BillingAddress_City = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    BillingAddress_State = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    BillingAddress_PhoneCountryCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    BillingAddress_Phone = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Signature = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Logo = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Signature_Data = table.Column<byte[]>(nullable: true),
                    Logo_Data = table.Column<byte[]>(nullable: true),
                    Invoice_Prefix = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Invoice_Suffix = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsComplete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Com__2D971C4C1FB71867", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK__User_Comp__UserI__3943762B",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "UserMaster",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Info",
                schema: "dbo",
                columns: table => new
                {
                    InfoID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    User_Cat = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    sale_medium = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    Monthly_Shipments = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    ProductCategory = table.Column<string>(unicode: false, maxLength: 3000, nullable: false),
                    OtherCategory = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsComplete = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Inf__4DEC9D9A4D3F29E0", x => x.InfoID);
                    table.ForeignKey(
                        name: "FK__User_Info__UserI__3C1FE2D6",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "UserMaster",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    RoleID = table.Column<short>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserInRo__3D978A55E50B2BF8", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK__UserInRol__RoleI__2818EA29",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "RoleMaster",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserInRol__UserI__290D0E62",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "UserMaster",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_lcountryid",
                schema: "dbo",
                table: "City",
                column: "lcountryid");

            migrationBuilder.CreateIndex(
                name: "IX_City_lstateid",
                schema: "dbo",
                table: "City",
                column: "lstateid");

            migrationBuilder.CreateIndex(
                name: "UQ__PlanType__46E12F9E9A2E9B47",
                schema: "dbo",
                table: "PlanType",
                column: "PlanName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__RoleMast__737584F6188F921D",
                schema: "dbo",
                table: "RoleMaster",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_lcountryid",
                schema: "dbo",
                table: "State",
                column: "lcountryid");

            migrationBuilder.CreateIndex(
                name: "IX_User_Bank_Details_UserID",
                schema: "dbo",
                table: "User_Bank_Details",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Company_Details_UserID",
                schema: "dbo",
                table: "User_Company_Details",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Info_UserID",
                schema: "dbo",
                table: "User_Info",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_RoleID",
                schema: "dbo",
                table: "UserInRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_UserID",
                schema: "dbo",
                table: "UserInRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__UserMast__7ED91AEE6DEB1797",
                schema: "dbo",
                table: "UserMaster",
                column: "EmailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_PlanID",
                schema: "dbo",
                table: "UserMaster",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaster_UserTypeID",
                schema: "dbo",
                table: "UserMaster",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__UserType__87E7869178F78539",
                schema: "dbo",
                table: "UserType",
                column: "UserType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_Bank_Details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_Company_Details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User_Info",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserInRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "State",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlanType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "dbo");
        }
    }
}
