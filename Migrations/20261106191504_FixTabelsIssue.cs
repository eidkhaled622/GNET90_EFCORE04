using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GNET90_EFCORE04.Migrations
{
    /// <inheritdoc />
    public partial class FixTabelsIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Branch_BranchId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Managers_ManagerId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Account_AccountId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Customer_CustomerId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "transactions");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TransactionNumber",
                table: "transactions",
                newName: "IX_transactions_TransactionNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccountId",
                table: "transactions",
                newName: "IX_transactions_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_NationalId",
                table: "Customers",
                newName: "IX_Customers_NationalId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_ManagerId",
                table: "Branches",
                newName: "IX_Branches_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_Code",
                table: "Branches",
                newName: "IX_Branches_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Account_BranchId",
                table: "Accounts",
                newName: "IX_Accounts_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_AccountNumber",
                table: "Accounts",
                newName: "IX_Accounts_AccountNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Accounts_AccountId",
                table: "CustomerAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Customers_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_Accounts_AccountId",
                table: "transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Accounts_AccountId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_Customers_CustomerId",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_Accounts_AccountId",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_TransactionNumber",
                table: "Transaction",
                newName: "IX_Transaction_TransactionNumber");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_AccountId",
                table: "Transaction",
                newName: "IX_Transaction_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_NationalId",
                table: "Customer",
                newName: "IX_Customer_NationalId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_ManagerId",
                table: "Branch",
                newName: "IX_Branch_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_Code",
                table: "Branch",
                newName: "IX_Branch_Code");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_BranchId",
                table: "Account",
                newName: "IX_Account_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Account",
                newName: "IX_Account_AccountNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Branch_BranchId",
                table: "Account",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Managers_ManagerId",
                table: "Branch",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Account_AccountId",
                table: "CustomerAccounts",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_Customer_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountId",
                table: "Transaction",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
