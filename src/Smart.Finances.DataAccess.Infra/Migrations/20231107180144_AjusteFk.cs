using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart.Finances.DataAccess.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Categoria_CategoriaId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas");

            migrationBuilder.AddColumn<double>(
                name: "ValorParcela",
                table: "Parcelas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<bool>(
                name: "EhRecorrente",
                table: "Despesa",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EhAtivo",
                table: "Despesa",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Categoria_CategoriaId",
                table: "Despesa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Categoria_CategoriaId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "ValorParcela",
                table: "Parcelas");

            migrationBuilder.AlterColumn<bool>(
                name: "EhRecorrente",
                table: "Despesa",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "EhAtivo",
                table: "Despesa",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Categoria_CategoriaId",
                table: "Despesa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
