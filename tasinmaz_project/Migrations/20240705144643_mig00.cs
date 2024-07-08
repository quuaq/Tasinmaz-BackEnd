using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace tasinmaz_project.Migrations
{
    public partial class mig00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kullanici",
                columns: table => new
                {
                    kullanici_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_name = table.Column<string>(nullable: true),
                    password_hash = table.Column<byte[]>(nullable: true),
                    password_salt = table.Column<byte[]>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.kullanici_id);
                });

            migrationBuilder.CreateTable(
                name: "sehir",
                columns: table => new
                {
                    sehir_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sehir_ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehir", x => x.sehir_id);
                });

            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    log_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    durum = table.Column<bool>(nullable: false),
                    islem_tipi = table.Column<string>(nullable: true),
                    aciklama = table.Column<string>(nullable: true),
                    tarih = table.Column<DateTime>(nullable: false),
                    log_ip = table.Column<string>(nullable: true),
                    kullanici_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log", x => x.log_id);
                    table.ForeignKey(
                        name: "FK_log_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalTable: "kullanici",
                        principalColumn: "kullanici_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ilce",
                columns: table => new
                {
                    ilce_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ilce_ad = table.Column<string>(nullable: true),
                    sehir_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilce", x => x.ilce_id);
                    table.ForeignKey(
                        name: "FK_ilce_sehir_sehir_id",
                        column: x => x.sehir_id,
                        principalTable: "sehir",
                        principalColumn: "sehir_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mahalle",
                columns: table => new
                {
                    mahalle_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mahalle_ad = table.Column<string>(nullable: true),
                    ilce_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahalle", x => x.mahalle_id);
                    table.ForeignKey(
                        name: "FK_mahalle_ilce_ilce_id",
                        column: x => x.ilce_id,
                        principalTable: "ilce",
                        principalColumn: "ilce_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasinmaz",
                columns: table => new
                {
                    tasinmaz_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ada = table.Column<string>(nullable: true),
                    parsel = table.Column<string>(nullable: true),
                    nitelik = table.Column<string>(nullable: true),
                    koordinat = table.Column<string>(nullable: true),
                    adres = table.Column<string>(nullable: true),
                    mahalle_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasinmaz", x => x.tasinmaz_id);
                    table.ForeignKey(
                        name: "FK_tasinmaz_mahalle_mahalle_id",
                        column: x => x.mahalle_id,
                        principalTable: "mahalle",
                        principalColumn: "mahalle_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilce_sehir_id",
                table: "ilce",
                column: "sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_log_kullanici_id",
                table: "log",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_mahalle_ilce_id",
                table: "mahalle",
                column: "ilce_id");

            migrationBuilder.CreateIndex(
                name: "IX_tasinmaz_mahalle_id",
                table: "tasinmaz",
                column: "mahalle_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "tasinmaz");

            migrationBuilder.DropTable(
                name: "kullanici");

            migrationBuilder.DropTable(
                name: "mahalle");

            migrationBuilder.DropTable(
                name: "ilce");

            migrationBuilder.DropTable(
                name: "sehir");
        }
    }
}
