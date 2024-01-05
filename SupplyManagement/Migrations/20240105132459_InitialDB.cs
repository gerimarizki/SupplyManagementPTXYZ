using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_companies",
                columns: table => new
                {
                    companyID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci"),
                    companyName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyPhone = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    approvalStatus = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyPhoto = table.Column<byte[]>(type: "varbinary(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_companies", x => x.companyID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_vendors",
                columns: table => new
                {
                    VendorID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci"),
                    vendorName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    businessType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_vendors", x => x.VendorID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_projects",
                columns: table => new
                {
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci"),
                    projectName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    VendorID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_tb_m_projects_tb_m_vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "tb_m_vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci"),
                    ManagerID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_tb_m_users_tb_m_companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "tb_m_companies",
                        principalColumn: "companyID");
                    table.ForeignKey(
                        name: "FK_tb_m_users_tb_m_vendors_UserID",
                        column: x => x.UserID,
                        principalTable: "tb_m_vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_manager_logistics",
                columns: table => new
                {
                    ManagerID = table.Column<Guid>(type: "uniqueidentifier(36)", nullable: false, collation: "ascii_general_ci"),
                    managerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    managerEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    managerPhone = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_manager_logistics", x => x.ManagerID);
                    table.ForeignKey(
                        name: "FK_tb_m_manager_logistics_tb_m_users_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "tb_m_users",
                        principalColumn: "UserID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_companies_companyID_companyEmail",
                table: "tb_m_companies",
                columns: new[] { "companyID", "companyEmail" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_manager_logistics_ManagerID_managerEmail",
                table: "tb_m_manager_logistics",
                columns: new[] { "ManagerID", "managerEmail" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_projects_ProjectID",
                table: "tb_m_projects",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_projects_VendorID",
                table: "tb_m_projects",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_users_CompanyID",
                table: "tb_m_users",
                column: "CompanyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_users_UserID_Email",
                table: "tb_m_users",
                columns: new[] { "UserID", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_vendors_VendorID",
                table: "tb_m_vendors",
                column: "VendorID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_manager_logistics");

            migrationBuilder.DropTable(
                name: "tb_m_projects");

            migrationBuilder.DropTable(
                name: "tb_m_users");

            migrationBuilder.DropTable(
                name: "tb_m_companies");

            migrationBuilder.DropTable(
                name: "tb_m_vendors");
        }
    }
}
