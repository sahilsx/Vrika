using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vrika.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class g : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c8089d0-77f6-4061-81f0-855d5c5ddac8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02a9963d-cb4c-4d4c-924e-c60bf4c52172", "AQAAAAIAAYagAAAAEHQyhkTxXbT0A6/OmO2LMv0lW+KA0yRZ9TQ3MZ9zA/GDNCKgejt7h2aPH/ZqLdCmlQ==", "7d5da10e-1c7f-4ef2-9f6a-1d101eabd10e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c8089d0-77f6-4061-81f0-855d5c5ddac8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ae6d220-071a-4e17-9442-3ffd5967cf0e", "AQAAAAIAAYagAAAAEM1E1DGXlOzW7RKpBt7IRJrbBTFyW+aK8rvHIxkZz/VPbLYjWepP0Sj2Tuca1z0kyg==", "8642c5b6-630e-4689-b49c-6b6e4048c9db" });
        }
    }
}
