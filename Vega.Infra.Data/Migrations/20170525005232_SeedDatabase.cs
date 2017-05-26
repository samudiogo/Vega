
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Infra.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make3')");

            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make1-ModelA',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE1'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make1-ModelB',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE1'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make1-ModelC',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE1'))");


            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make2-ModelA',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE2'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make2-ModelB',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE2'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make2-ModelC',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE2'))");

            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make3-ModelA',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE3'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make3-ModelB',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE3'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeID) VALUES('Make3-ModelC',(SELECT ID FROM  MAKES WHERE NAME = 'MAKE3'))");


            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature1')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature2')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature3')");

            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('samudiogo@gmail.com','Samuel','55 2198070-1947', 1, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make1-ModelA'))");
            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('diogo@gmail.com','Diogo','55 2198070-1947', 1, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make1-ModelB'))");
            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('arpi@gmail.com','Sandro','55 2198070-1947', 1, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make1-ModelC'))");

            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('marcos@gmail.com','Marcos','55 2198070-1947', 2, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make3-ModelA'))");
            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('felipe@gmail.com','Felipe','55 2198070-1947', 2, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make3-ModelB'))");
            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('max@gmail.com','Max','55 2198070-1947', 2, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make2-ModelC'))");

            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('sandra@gmail.com','Sandra','55 2198070-1947', 2, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make2-ModelA'))");
            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('rodrigo@gmail.com','Rodrigo','55 2198070-1947', 3, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make2-ModelB'))");
            migrationBuilder.Sql("INSERT INTO Vehicles VALUES('monica@gmail.com','Monica','55 2198070-1947', 3, GetDate(),(SELECT ID FROM  Models WHERE NAME = 'Make2-ModelC'))");




            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Samuel') , (SELECT ID FROM  Features WHERE NAME = 'Feature1'))");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Samuel') , (SELECT ID FROM  Features WHERE NAME = 'Feature2'))");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Samuel') , (SELECT ID FROM  Features WHERE NAME = 'Feature3'))");

            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Sandro') , (SELECT ID FROM  Features WHERE NAME = 'Feature2'))");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Sandro') , (SELECT ID FROM  Features WHERE NAME = 'Feature3'))");

            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Diogo') , (SELECT ID FROM  Features WHERE NAME = 'Feature1'))");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures VALUES((SELECT ID FROM  Vehicles WHERE ContactName = 'Diogo') , (SELECT ID FROM  Features WHERE NAME = 'Feature3'))");









        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE NAME IN('MAKE1','MAKE2','MAKE3')");
        }
    }
}
