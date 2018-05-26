namespace FingerTips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ft : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                        List_Id = c.Int(),
                        List_Id1 = c.Int(),
                        List_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Lists", t => t.List_Id)
                .ForeignKey("public.Lists", t => t.List_Id1)
                .ForeignKey("public.Lists", t => t.List_Id2)
                .Index(t => t.List_Id)
                .Index(t => t.List_Id1)
                .Index(t => t.List_Id2);
            
            CreateTable(
                "public.Labels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ColorString = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Lists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.LabelCards",
                c => new
                    {
                        Label_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Label_Id, t.Card_Id })
                .ForeignKey("public.Labels", t => t.Label_Id, cascadeDelete: true)
                .ForeignKey("public.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.Label_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "public.MemberCards",
                c => new
                    {
                        Member_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_Id, t.Card_Id })
                .ForeignKey("public.Members", t => t.Member_Id, cascadeDelete: true)
                .ForeignKey("public.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.Member_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.MemberCards", "Card_Id", "public.Cards");
            DropForeignKey("public.MemberCards", "Member_Id", "public.Members");
            DropForeignKey("public.Cards", "List_Id2", "public.Lists");
            DropForeignKey("public.Cards", "List_Id1", "public.Lists");
            DropForeignKey("public.Cards", "List_Id", "public.Lists");
            DropForeignKey("public.LabelCards", "Card_Id", "public.Cards");
            DropForeignKey("public.LabelCards", "Label_Id", "public.Labels");
            DropIndex("public.MemberCards", new[] { "Card_Id" });
            DropIndex("public.MemberCards", new[] { "Member_Id" });
            DropIndex("public.Cards", new[] { "List_Id2" });
            DropIndex("public.Cards", new[] { "List_Id1" });
            DropIndex("public.Cards", new[] { "List_Id" });
            DropIndex("public.LabelCards", new[] { "Card_Id" });
            DropIndex("public.LabelCards", new[] { "Label_Id" });
            DropTable("public.MemberCards");
            DropTable("public.LabelCards");
            DropTable("public.Members");
            DropTable("public.Lists");
            DropTable("public.Labels");
            DropTable("public.Cards");
        }
    }
}
