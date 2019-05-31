namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMovieTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Genres");
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            AlterColumn("dbo.Genres", "ID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "ID", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Movies");
            AddPrimaryKey("dbo.Genres", "ID");
        }
    }
}
