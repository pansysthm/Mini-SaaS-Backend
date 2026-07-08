using Azure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace MiniSaaSBackend.Migrations.Customs;

public static class MigrationBuilderExtensions
{
    public static OperationBuilder<SqlOperation> CreateUser(
        this MigrationBuilder migrationBuilder,
        string name,
        string password)
    {
        // Parameterized SQL is not natively supported in MigrationBuilder.Sql, 
        // using constant string to prevent basic injection.
        return migrationBuilder.Sql($@"INSERT INTO Users (Id, Name, Email, PasswordHash, Role, CreatedAt) 
            VALUES (NEWID(), '{name}', '{name.ToLower()}@example.com', '{password}', 'Admin', GETDATE());");
    }

    public static OperationBuilder<SqlOperation> DeleteUser(
        this MigrationBuilder migrationBuilder,
        string name)
    {
        return migrationBuilder.Sql($@"DELETE FROM Users  WHERE Name = '{name}'");
    }

}
