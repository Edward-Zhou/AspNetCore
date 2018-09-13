using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCorePro.Migrations
{
    public partial class mcst1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ChildUserRoleId",
                table: "UserRoleRelationship");

            migrationBuilder.AlterColumn<int>(
                name: "ChildUserRoleId",
                table: "UserRoleRelationship",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ChildUserRoleId",
                table: "UserRoleRelationship",
                column: "ChildUserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ChildUserRoleId",
                table: "UserRoleRelationship");

            migrationBuilder.AlterColumn<int>(
                name: "ChildUserRoleId",
                table: "UserRoleRelationship",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleRelationship_UserRole_ChildUserRoleId",
                table: "UserRoleRelationship",
                column: "ChildUserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
