namespace AppMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera_migracion : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MovieCategories", new[] { "Category_Id1" });
            DropIndex("dbo.MovieCategories", new[] { "Movie_Id1" });
            DropColumn("dbo.MovieCategories", "Category_Id");
            DropColumn("dbo.MovieCategories", "Movie_Id");
            RenameColumn(table: "dbo.MovieCategories", name: "Category_Id1", newName: "Category_Id");
            RenameColumn(table: "dbo.MovieCategories", name: "Movie_Id1", newName: "Movie_Id");
            AlterColumn("dbo.MovieCategories", "Movie_Id", c => c.Int());
            AlterColumn("dbo.MovieCategories", "Category_Id", c => c.Int());
            CreateIndex("dbo.MovieCategories", "Category_Id");
            CreateIndex("dbo.MovieCategories", "Movie_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MovieCategories", new[] { "Movie_Id" });
            DropIndex("dbo.MovieCategories", new[] { "Category_Id" });
            AlterColumn("dbo.MovieCategories", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieCategories", "Movie_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.MovieCategories", name: "Movie_Id", newName: "Movie_Id1");
            RenameColumn(table: "dbo.MovieCategories", name: "Category_Id", newName: "Category_Id1");
            AddColumn("dbo.MovieCategories", "Movie_Id", c => c.Int(nullable: false));
            AddColumn("dbo.MovieCategories", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieCategories", "Movie_Id1");
            CreateIndex("dbo.MovieCategories", "Category_Id1");
        }
    }
}
