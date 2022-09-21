using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoObjectModel.Infrostraction.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoNamesFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeoNamesFeatureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeoNamesFeatureKind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureKindNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureKindNameRu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureNameRu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentsEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentsRu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoNamesFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeographicalObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeoNameId = table.Column<int>(type: "int", nullable: false),
                    ParentGeoNameId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeoNamesFeauteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeoNamesFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicalObjects_GeoNamesFeatures_GeoNamesFeatureId",
                        column: x => x.GeoNamesFeatureId,
                        principalTable: "GeoNamesFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeographicalObjectVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthoritativeKnowledgeSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ArchiveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommonInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeographicalObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalObjectVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicalObjectVersions_GeographicalObjects_GeographicalObjectId",
                        column: x => x.GeographicalObjectId,
                        principalTable: "GeographicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeometryVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ArchiveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpperLeftCornerGeocode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LowerRightCornerGeocode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorderGeocodes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaVolue = table.Column<double>(type: "float", nullable: false),
                    WestToEastLength = table.Column<double>(type: "float", nullable: false),
                    NorthToSouthLength = table.Column<double>(type: "float", nullable: false),
                    GeographicalObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeometryVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeometryVersions_GeographicalObjects_GeographicalObjectId",
                        column: x => x.GeographicalObjectId,
                        principalTable: "GeographicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NeighboringObjectLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeographicalObjectAName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeographicalObjectBName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    A2BNumber = table.Column<int>(type: "int", nullable: false),
                    B2ANumber = table.Column<int>(type: "int", nullable: false),
                    A2BCornersOfTheEarth = table.Column<int>(type: "int", nullable: false),
                    B2ACornersOfTheEarth = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeighboringGeographicalObjectsOutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighboringGeographicalObjectsInId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighboringObjectLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NeighboringObjectLinks_GeographicalObjects_NeighboringGeographicalObjectsInId",
                        column: x => x.NeighboringGeographicalObjectsInId,
                        principalTable: "GeographicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NeighboringObjectLinks_GeographicalObjects_NeighboringGeographicalObjectsOutId",
                        column: x => x.NeighboringGeographicalObjectsOutId,
                        principalTable: "GeographicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentChildObjectLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentGeographicalObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildGeographicalObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletelyIncludedFlag = table.Column<bool>(type: "bit", nullable: false),
                    IncludedPercent = table.Column<double>(type: "float", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeographicalObjectParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeographicalObjectChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentChildObjectLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentChildObjectLinks_GeographicalObjects_GeographicalObjectChildId",
                        column: x => x.GeographicalObjectChildId,
                        principalTable: "GeographicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentChildObjectLinks_GeographicalObjects_GeographicalObjectParentId",
                        column: x => x.GeographicalObjectParentId,
                        principalTable: "GeographicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalObjects_GeoNamesFeatureId",
                table: "GeographicalObjects",
                column: "GeoNamesFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalObjectVersions_GeographicalObjectId",
                table: "GeographicalObjectVersions",
                column: "GeographicalObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GeometryVersions_GeographicalObjectId",
                table: "GeometryVersions",
                column: "GeographicalObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NeighboringObjectLinks_NeighboringGeographicalObjectsInId",
                table: "NeighboringObjectLinks",
                column: "NeighboringGeographicalObjectsInId");

            migrationBuilder.CreateIndex(
                name: "IX_NeighboringObjectLinks_NeighboringGeographicalObjectsOutId",
                table: "NeighboringObjectLinks",
                column: "NeighboringGeographicalObjectsOutId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentChildObjectLinks_GeographicalObjectChildId",
                table: "ParentChildObjectLinks",
                column: "GeographicalObjectChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentChildObjectLinks_GeographicalObjectParentId",
                table: "ParentChildObjectLinks",
                column: "GeographicalObjectParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeographicalObjectVersions");

            migrationBuilder.DropTable(
                name: "GeometryVersions");

            migrationBuilder.DropTable(
                name: "NeighboringObjectLinks");

            migrationBuilder.DropTable(
                name: "ParentChildObjectLinks");

            migrationBuilder.DropTable(
                name: "GeographicalObjects");

            migrationBuilder.DropTable(
                name: "GeoNamesFeatures");
        }
    }
}
