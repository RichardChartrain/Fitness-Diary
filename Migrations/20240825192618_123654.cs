﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessDiary.Migrations
{
    /// <inheritdoc />
    public partial class _123654 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaExercicios",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaExercicios", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "GruposMusculares",
                columns: table => new
                {
                    IdGrupoMuscular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposMusculares", x => x.IdGrupoMuscular);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DtaNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: true),
                    Altura = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    IdTreino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.IdTreino);
                    table.ForeignKey(
                        name: "FK_Treinos_CategoriaExercicios_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaExercicios",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treinos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    IdExercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Repeticoes = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    CaloriasQueimadasPorSeries = table.Column<double>(type: "float", nullable: false),
                    IdTreino = table.Column<int>(type: "int", nullable: false),
                    IdGrupoMuscular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.IdExercicio);
                    table.ForeignKey(
                        name: "FK_Exercicios_GruposMusculares_IdGrupoMuscular",
                        column: x => x.IdGrupoMuscular,
                        principalTable: "GruposMusculares",
                        principalColumn: "IdGrupoMuscular",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicios_Treinos_IdTreino",
                        column: x => x.IdTreino,
                        principalTable: "Treinos",
                        principalColumn: "IdTreino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriaExercicios",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[,]
                {
                    { 1, "Força" },
                    { 2, "Core e Abdominais" },
                    { 3, "Exercícios com Peso Corporal" },
                    { 4, "Exercícios de Resistência" },
                    { 5, "Exercícios para Grupos Musculares Específicos" }
                });

            migrationBuilder.InsertData(
                table: "GruposMusculares",
                columns: new[] { "IdGrupoMuscular", "Nome" },
                values: new object[,]
                {
                    { 1, "Peitoral" },
                    { 2, "Dorsal" },
                    { 3, "Ombros" },
                    { 4, "Bíceps" },
                    { 5, "Tríceps" },
                    { 6, "Quadríceps" },
                    { 7, "Isquiotibiais" },
                    { 8, "Glúteos" },
                    { 9, "Panturrilhas" },
                    { 10, "Abdômen" },
                    { 11, "Lombar" },
                    { 12, "Músculos do Core" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_IdGrupoMuscular",
                table: "Exercicios",
                column: "IdGrupoMuscular");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_IdTreino",
                table: "Exercicios",
                column: "IdTreino");

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_IdCategoria",
                table: "Treinos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_IdUsuario",
                table: "Treinos",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "GruposMusculares");

            migrationBuilder.DropTable(
                name: "Treinos");

            migrationBuilder.DropTable(
                name: "CategoriaExercicios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
