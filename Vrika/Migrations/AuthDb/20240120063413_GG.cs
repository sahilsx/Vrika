using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vrika.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class GG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c8089d0-77f6-4061-81f0-855d5c5ddac8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ae6d220-071a-4e17-9442-3ffd5967cf0e", "AQAAAAIAAYagAAAAEM1E1DGXlOzW7RKpBt7IRJrbBTFyW+aK8rvHIxkZz/VPbLYjWepP0Sj2Tuca1z0kyg==", "8642c5b6-630e-4689-b49c-6b6e4048c9db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c8089d0-77f6-4061-81f0-855d5c5ddac8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "273d8255-d01f-4a0c-b5f3-75edbe22d426", "AQAAAAIAAYagAAAAEPDwgGSlYqQm2zdeFzRZ2rZZd2Sr49QcvqjO0/Y7YwbrWAiFrplFZ7UoF99XHfJhCw==", "cd09f707-6c11-4392-ac19-d0d3874f5074" });
        }
    }
}
