using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BucketWithBolts.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class InitialMsSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_src = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resource_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Correspondences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recipient_Id = table.Column<int>(type: "int", nullable: false),
                    Sender_Id = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correspondences_Users_Recipient_Id",
                        column: x => x.Recipient_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Correspondences_Users_Sender_Id",
                        column: x => x.Sender_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Conditions_Condition",
                        column: x => x.Condition,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Resource_Status_Status",
                        column: x => x.Status,
                        principalTable: "Resource_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Users_Owner_id",
                        column: x => x.Owner_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resource_id = table.Column<int>(type: "int", nullable: false),
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Status_Status",
                        column: x => x.Status,
                        principalTable: "Order_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Resources_Resource_id",
                        column: x => x.Resource_id,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resource_Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resource_id = table.Column<int>(type: "int", nullable: false),
                    Image_scr_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_Images_Images_Image_scr_id",
                        column: x => x.Image_scr_id,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_Images_Resources_Resource_id",
                        column: x => x.Resource_id,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Новый" },
                    { 2, "Б/У" }
                });

            migrationBuilder.InsertData(
                table: "Order_Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ожидание" },
                    { 2, "Продан" },
                    { 3, "Отменён" }
                });

            migrationBuilder.InsertData(
                table: "Resource_Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Выставлен" },
                    { 2, "Продан" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Correspondences_Recipient_Id",
                table: "Correspondences",
                column: "Recipient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Correspondences_Sender_Id",
                table: "Correspondences",
                column: "Sender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Order_id",
                table: "Feedbacks",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customer_id",
                table: "Orders",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Resource_id",
                table: "Orders",
                column: "Resource_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_Images_Image_scr_id",
                table: "Resource_Images",
                column: "Image_scr_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_Images_Resource_id",
                table: "Resource_Images",
                column: "Resource_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Condition",
                table: "Resources",
                column: "Condition");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Owner_id",
                table: "Resources",
                column: "Owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Status",
                table: "Resources",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Correspondences");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Resource_Images");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Order_Status");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Resource_Status");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
