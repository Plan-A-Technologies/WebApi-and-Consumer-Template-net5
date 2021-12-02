using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Dal.Migrations
{
    /// <summary>
    /// Auditable migration.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class Auditable : Migration
    {
        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'up'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by the
        /// previous migration so that it is up-to-date with regard to this migration.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" />.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Players",
                newSchema: "dbo");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "PlayerPhones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "dbo",
                table: "PlayerPhones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "PlayerPhones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                schema: "dbo",
                table: "PlayerPhones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                schema: "dbo",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'down'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by
        /// this migration so that it returns to the state that it was in before this migration was applied.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" /> if
        /// both 'up' and 'down' migrations are to be supported. If it is not overridden, then calling it
        /// will throw and it will not be possible to migrate in the 'down' direction.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "PlayerPhones");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "PlayerPhones");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "PlayerPhones");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "dbo",
                table: "PlayerPhones");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "dbo",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                schema: "dbo",
                newName: "Players");
        }
    }
}
