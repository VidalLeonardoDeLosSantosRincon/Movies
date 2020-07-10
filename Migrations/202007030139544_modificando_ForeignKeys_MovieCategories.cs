namespace AppMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificando_ForeignKeys_MovieCategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieCategories", "Movie_Id1", "dbo.Movies");
            DropForeignKey("dbo.MovieCategories", "Category_Id1", "dbo.Categories");
           

            AddForeignKey("dbo.MovieCategories", "Movie_Id", "dbo.Movies");
            AddForeignKey("dbo.MovieCategories", "Category_Id", "dbo.Categories");
        }

        public override void Down()
        {

            DropForeignKey("dbo.MovieCategories", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieCategories", "Category_Id", "dbo.Categories");


            AddForeignKey("dbo.MovieCategories", "Movie_Id1", "dbo.Movies");
            AddForeignKey("dbo.MovieCategories", "Category_Id1", "dbo.Categories");
        }
    }
}
