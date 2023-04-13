using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    nik = table.Column<string>(type: "char(5)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.nik);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_universities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_universities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_accounts",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "char(5)", nullable: false),
                    password = table.Column<string>(type: "char(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_accounts", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_tb_tr_accounts_tb_m_employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_educations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major = table.Column<string>(type: "varchar(100)", nullable: false),
                    degree = table.Column<string>(type: "varchar(10)", nullable: false),
                    gpa = table.Column<string>(type: "varchar(5)", nullable: false),
                    university_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_educations", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_educations_tb_tr_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "tb_tr_universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_accountroles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_nik = table.Column<string>(type: "char(5)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_accountroles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_accountroles_tb_tr_accounts_account_nik",
                        column: x => x.account_nik,
                        principalTable: "tb_tr_accounts",
                        principalColumn: "employee_nik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_accountroles_tb_tr_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_tr_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_profilings",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "char(5)", nullable: false),
                    education_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_profilings", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_tb_tr_profilings_tb_m_employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_profilings_tb_tr_educations_education_id",
                        column: x => x.education_id,
                        principalTable: "tb_tr_educations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_account_nik",
                table: "tb_tr_accountroles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_role_id",
                table: "tb_tr_accountroles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_educations_university_id",
                table: "tb_tr_educations",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_profilings_education_id",
                table: "tb_tr_profilings",
                column: "education_id",
                unique: true,
                filter: "[education_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_accountroles");

            migrationBuilder.DropTable(
                name: "tb_tr_profilings");

            migrationBuilder.DropTable(
                name: "tb_tr_accounts");

            migrationBuilder.DropTable(
                name: "tb_tr_roles");

            migrationBuilder.DropTable(
                name: "tb_tr_educations");

            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_tr_universities");
        }
    }
}
