using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vrika.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class authdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c8089d0-77f6-4061-81f0-855d5c5ddac8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4772f991-3433-4fee-adf8-1352dc44a817", "ITXSAAHO@GMAIL.COM", "SAHILALTAF", "AQAAAAIAAYagAAAAECgKQ4OtFF4mEh2PRNXPcqdtcyqEV/LSJxrhjIqEkMucpwfJIckypI/Ehvmp1imA2A==", "173cb6cb-f5c8-4b46-b693-255005de2bba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c8089d0-77f6-4061-81f0-855d5c5ddac8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02a9963d-cb4c-4d4c-924e-c60bf4c52172", "SAHILALTAF", "ITXSAAHO@GMAIL.COM", "AQAAAAIAAYagAAAAEHQyhkTxXbT0A6/OmO2LMv0lW+KA0yRZ9TQ3MZ9zA/GDNCKgejt7h2aPH/ZqLdCmlQ==", "7d5da10e-1c7f-4ef2-9f6a-1d101eabd10e" });
        }
    }
}
