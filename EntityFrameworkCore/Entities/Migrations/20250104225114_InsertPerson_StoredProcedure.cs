using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class InsertPerson_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //uniqueidentifier is GUID type for sql server
            string sp_InsertPerson = @"
                CREATE PROCEDURE [dbo].[InsertPerson]
                (@PersonID uniqueidentifier, @PersonName nvarchar(40), 
                @Email nvarchar(40), @DateOfBirth datetime2(7) @Gender varchar(10), @CountryID uniqueidentifier, @Address nvarchar(200)
                @ReceiveNewsLetters bit)
                AS BEGIN
                    INSERT INTO [dbo].[Persons](PersonID, PersonName, Email, DateOfBirth, Gender, CountryID, Address, ReceiveNewsLetters)
                    VALUES (@PersonID, @PersonName, @Email, @DateOfBirth, @Gender, @CountryID, @Address, @ReceiveNewsLetters)
               END  
            ";
            //To execute the sql statement in this migrationBuilder object
            migrationBuilder.Sql(sp_InsertPerson);
            //so whenever the above sql statement executes it creates a stored procedure in the db
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"
                DROP PROCEDURE [dbo].[InsertPerson]        
            ";
            migrationBuilder.Sql(sp_InsertPerson);
        }
    }
}
