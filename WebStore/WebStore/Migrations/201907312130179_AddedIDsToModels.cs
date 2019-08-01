namespace WebStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIDsToModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_CategoryId");
            AddColumn("dbo.ProductCategories", "SupecategoryId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "SupecategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
        }
    }
}
