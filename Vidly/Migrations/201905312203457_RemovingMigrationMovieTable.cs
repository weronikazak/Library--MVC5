namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingMigrationMovieTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_ID" });
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                        Genre_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movies", "Genre_ID");
            AddForeignKey("dbo.Movies", "Genre_ID", "dbo.Genres", "ID");
        }
    }
}
