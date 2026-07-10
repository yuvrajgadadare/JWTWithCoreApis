using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTWithCoreApis.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "products",
                schema: "dbo",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    rate = table.Column<double>(type: "float", nullable: true),
                    gst = table.Column<double>(type: "float", nullable: true),
                    stock_quantity = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products__47027DF521A3E01B", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                schema: "dbo",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCusto__A4AE64D82C6760C1", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "tblemployees",
                schema: "dbo",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    employee_code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    designation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblemplo__C52E0BA83EF6F507", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Gst = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblProdu__B40CC6CD9AE61534", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "tblstudent_details",
                schema: "dbo",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    mobile_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email_address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblstude__2A33069A6E0ABE11", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "tblusers",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MobileNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ProfilePhoto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblusers__1788CC4C53F2595C", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoiceDetails",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblInvoi__D796AAB521E7BE2A", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "fkcid",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "tblCustomers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "tblInvoicePayments",
                schema: "dbo",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentAmount = table.Column<double>(type: "float", nullable: true),
                    PaymentMode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblInvoi__9B556A3810C69400", x => x.PaymentId);
                    table.ForeignKey(
                        name: "fkincid",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "tblInvoiceDetails",
                        principalColumn: "InvoiceId");
                });

            migrationBuilder.CreateTable(
                name: "tblInvoiceProducts",
                schema: "dbo",
                columns: table => new
                {
                    InvoiceProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblInvoi__D032D0C95C5D3F80", x => x.InvoiceProductId);
                    table.ForeignKey(
                        name: "fkinvoiceid",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "tblInvoiceDetails",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "fkproductid",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "tblProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__tblCusto__250375B1B4E27C0B",
                schema: "dbo",
                table: "tblCustomers",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tblCusto__250375B1D11C89D5",
                schema: "dbo",
                table: "tblCustomers",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tblCusto__49A147403662EB00",
                schema: "dbo",
                table: "tblCustomers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tblCusto__49A147409F4685E8",
                schema: "dbo",
                table: "tblCustomers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tblemplo__B0AA7345CDC14887",
                schema: "dbo",
                table: "tblemployees",
                column: "employee_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceDetails_CustomerId",
                schema: "dbo",
                table: "tblInvoiceDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoicePayments_InvoiceId",
                schema: "dbo",
                table: "tblInvoicePayments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceProducts_InvoiceId",
                schema: "dbo",
                table: "tblInvoiceProducts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoiceProducts_ProductId",
                schema: "dbo",
                table: "tblInvoiceProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblemployees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblInvoicePayments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblInvoiceProducts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblstudent_details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblusers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblInvoiceDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblProducts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblCustomers",
                schema: "dbo");
        }
    }
}
