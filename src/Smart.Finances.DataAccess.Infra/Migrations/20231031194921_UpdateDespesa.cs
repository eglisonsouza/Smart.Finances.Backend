using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart.Finances.DataAccess.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDespesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Usuario_DespesaRecorrente_UsuarioId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Despesa_DespesaExtraId",
                table: "Parcelas");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_DespesaRecorrente_UsuarioId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "DespesaRecorrente_UsuarioId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Despesa");

            migrationBuilder.RenameColumn(
                name: "DespesaExtraId",
                table: "Parcelas",
                newName: "DespesaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcelas_DespesaExtraId",
                table: "Parcelas",
                newName: "IX_Parcelas_DespesaId");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Despesa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeParcela",
                table: "Despesa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EhAtivo",
                table: "Despesa",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "EhRecorrente",
                table: "Despesa",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "EhRecorrente",
                table: "Despesa");

            migrationBuilder.RenameColumn(
                name: "DespesaId",
                table: "Parcelas",
                newName: "DespesaExtraId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcelas_DespesaId",
                table: "Parcelas",
                newName: "IX_Parcelas_DespesaExtraId");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Despesa",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeParcela",
                table: "Despesa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "EhAtivo",
                table: "Despesa",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<long>(
                name: "DespesaRecorrente_UsuarioId",
                table: "Despesa",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Despesa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_DespesaRecorrente_UsuarioId",
                table: "Despesa",
                column: "DespesaRecorrente_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Usuario_DespesaRecorrente_UsuarioId",
                table: "Despesa",
                column: "DespesaRecorrente_UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Despesa_DespesaExtraId",
                table: "Parcelas",
                column: "DespesaExtraId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
