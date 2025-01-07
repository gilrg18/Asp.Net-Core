using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class GetPersons_WithTIN_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPersons = @"
                ALTER PROCEDURE [dbo].[GetAllPersons]
                AS BEGIN
                    SELECT PersonId, PersonName, Email, DateOfBirth, Gender,
                    CountryID, Address, ReceiveNewsLetters, TIN FROM [dbo].
                    [Persons]
               END  
            ";
            //To execute the sql statement in this migrationBuilder object
            migrationBuilder.Sql(sp_GetAllPersons);
            //so whenever the above sql statement executes it creates a stored procedure in the db
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPersons = @"
                ALTER PROCEDURE [dbo].[GetAllPersons]
                AS BEGIN
                    SELECT PersonId, PersonName, Email, DateOfBirth, Gender,
                           CountryID, Address, ReceiveNewsLetters
                    FROM [dbo].[Persons]
                END  
            ";
            // Rollback to the previous version of the stored procedure
            migrationBuilder.Sql(sp_GetAllPersons);
        }
    }
}
