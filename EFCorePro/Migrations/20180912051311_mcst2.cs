using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCorePro.Migrations
{
    public partial class mcst2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ParentUserRoleId",
                table: "UserRoleRelationship");

            migrationBuilder.AlterColumn<int>(
                name: "ParentUserRoleId",
                table: "UserRoleRelationship",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ParentUserRoleId",
                table: "UserRoleRelationship",
                column: "ParentUserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ParentUserRoleId",
                table: "UserRoleRelationship");

            migrationBuilder.AlterColumn<int>(
                name: "ParentUserRoleId",
                table: "UserRoleRelationship",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ParentUserRoleId",
                table: "UserRoleRelationship",
                column: "ParentUserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
