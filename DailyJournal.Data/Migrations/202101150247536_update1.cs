namespace DailyJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food", "Sugar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Meal", "MealNotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meal", "MealNotes", c => c.String());
            DropColumn("dbo.Food", "Sugar");
        }
    }
}
