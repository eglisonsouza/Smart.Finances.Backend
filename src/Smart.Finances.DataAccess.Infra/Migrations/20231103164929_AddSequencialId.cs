using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart.Finances.DataAccess.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddSequencialId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Categoria_CategoriaId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Usuario_UsuarioId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Despesa_DespesaId",
                table: "Parcelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcelas",
                table: "Parcelas");

            migrationBuilder.DropIndex(
                name: "IX_Parcelas_DespesaId",
                table: "Parcelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_CategoriaId",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_UsuarioId",
                table: "Despesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "DespesaId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Despesa");

            migrationBuilder.AddColumn<long>(
                name: "SequencialId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "SequencialId",
                table: "Parcelas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "DespesaSequencialId",
                table: "Parcelas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SequencialId",
                table: "Despesa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "CategoriaSequencialId",
                table: "Despesa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioSequencialId",
                table: "Despesa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SequencialId",
                table: "Categoria",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "SequencialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcelas",
                table: "Parcelas",
                column: "SequencialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa",
                column: "SequencialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "SequencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_DespesaSequencialId",
                table: "Parcelas",
                column: "DespesaSequencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_CategoriaSequencialId",
                table: "Despesa",
                column: "CategoriaSequencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_UsuarioSequencialId",
                table: "Despesa",
                column: "UsuarioSequencialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Categoria_CategoriaSequencialId",
                table: "Despesa",
                column: "CategoriaSequencialId",
                principalTable: "Categoria",
                principalColumn: "SequencialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Usuario_UsuarioSequencialId",
                table: "Despesa",
                column: "UsuarioSequencialId",
                principalTable: "Usuario",
                principalColumn: "SequencialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_Despesa_DespesaSequencialId",
                table: "Parcelas",
                column: "DespesaSequencialId",
                principalTable: "Despesa",
                principalColumn: "SequencialId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Categoria_CategoriaSequencialId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Usuario_UsuarioSequencialId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_Despesa_DespesaSequencialId",
                table: "Parcelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcelas",
                table: "Parcelas");

            migrationBuilder.DropIndex(
                name: "IX_Parcelas_DespesaSequencialId",
                table: "Parcelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_CategoriaSequencialId",
                table: "Despesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_UsuarioSequencialId",
                table: "Despesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "SequencialId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "SequencialId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "DespesaSequencialId",
                table: "Parcelas");

            migrationBuilder.DropColumn(
                name: "SequencialId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "CategoriaSequencialId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "UsuarioSequencialId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "SequencialId",
                table: "Categoria");

            migrationBuilder.AddColumn<Guid>(
                name: "DespesaId",
                table: "Parcelas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Despesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Despesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcelas",
                table: "Parcelas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_DespesaId",
                table: "Parcelas",
                column: "DespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_CategoriaId",
                table: "Despesa",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_UsuarioId",
                table: "Despesa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Categoria_CategoriaId",
                table: "Despesa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Usuario_UsuarioId",
                table: "Despesa",
                column: "UsuarioId",
                principalTable: "Usuario",
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
