namespace EF6DebugTranscriber.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeartableswithseed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gear",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Weight = c.Single(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "1")
                                },
                            }),
                        Container_Id = c.Long(),
                        HeroId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gear", t => t.Container_Id)
                .ForeignKey("dbo.Heros", t => t.HeroId)
                .Index(t => t.Container_Id)
                .Index(t => t.HeroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gear", "HeroId", "dbo.Heros");
            DropForeignKey("dbo.Gear", "Container_Id", "dbo.Gear");
            DropIndex("dbo.Gear", new[] { "HeroId" });
            DropIndex("dbo.Gear", new[] { "Container_Id" });
            DropTable("dbo.Gear",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Weight",
                        new Dictionary<string, object>
                        {
                            { "DefaultValue", "1" },
                        }
                    },
                });
        }
    }
}
