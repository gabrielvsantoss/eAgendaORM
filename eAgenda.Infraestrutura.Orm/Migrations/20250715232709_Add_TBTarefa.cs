using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Tarefa_TarefaId",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefa",
                table: "Tarefa");

            migrationBuilder.RenameTable(
                name: "Tarefa",
                newName: "Tarefas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Tarefas_TarefaId",
                table: "Itens",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Tarefas_TarefaId",
                table: "Itens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.RenameTable(
                name: "Tarefas",
                newName: "Tarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefa",
                table: "Tarefa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Tarefa_TarefaId",
                table: "Itens",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
