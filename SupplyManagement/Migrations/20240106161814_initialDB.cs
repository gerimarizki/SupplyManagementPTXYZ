using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyManagement.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_company",
                columns: table => new
                {
                    companyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    companyName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyPhone = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    approvalStatus = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyPhoto = table.Column<byte[]>(type: "varbinary(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_company", x => x.companyID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_manager",
                columns: table => new
                {
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    managerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    managerEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    managerPhone = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_manager", x => x.ManagerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_user",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_user", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_tb_m_user_tb_m_company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "tb_m_company",
                        principalColumn: "companyID");
                    table.ForeignKey(
                        name: "FK_tb_m_user_tb_m_manager_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "tb_m_manager",
                        principalColumn: "ManagerID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_vendor",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vendorName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    businessType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    companyType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_vendor", x => x.VendorID);
                    table.ForeignKey(
                        name: "FK_tb_m_vendor_tb_m_user_UserID",
                        column: x => x.UserID,
                        principalTable: "tb_m_user",
                        principalColumn: "UserID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    projectName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_tb_m_project_tb_m_vendor_VendorID",
                        column: x => x.VendorID,
                        principalTable: "tb_m_vendor",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_company_companyID_companyEmail",
                table: "tb_m_company",
                columns: new[] { "companyID", "companyEmail" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_manager_ManagerID_managerEmail",
                table: "tb_m_manager",
                columns: new[] { "ManagerID", "managerEmail" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_project_ProjectID",
                table: "tb_m_project",
                column: "ProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_project_VendorID",
                table: "tb_m_project",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_CompanyID",
                table: "tb_m_user",
                column: "CompanyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_ManagerID",
                table: "tb_m_user",
                column: "ManagerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_UserID_Email",
                table: "tb_m_user",
                columns: new[] { "UserID", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_vendor_UserID",
                table: "tb_m_vendor",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_vendor_VendorID",
                table: "tb_m_vendor",
                column: "VendorID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_project");

            migrationBuilder.DropTable(
                name: "tb_m_vendor");

            migrationBuilder.DropTable(
                name: "tb_m_user");

            migrationBuilder.DropTable(
                name: "tb_m_company");

            migrationBuilder.DropTable(
                name: "tb_m_manager");
        }
    }
}
