using System;
using System.Collections.Generic;
using System.Linq;
using dm_bot.Models;
using dm_bot.Services;
using Microsoft.EntityFrameworkCore;

namespace dm_bot.Contexts
{
    public class DMContext : DbContext
    {
        public DbSet<DungeonMasterAvailability> DungeonMasterAvailabilities { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Lobby> Lobbies { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            var connectionService = new ConnectionService ();

            optionsBuilder.UseNpgsql (connectionService.GetDbConnection ());

        }

        public void SeedDatabase ()
        {
            this.Database.EnsureCreated ();

            if (Ranks.Count () == 0)
            {
                var ranks = new string[] { "F", "D", "C", "B", "A", "S" };

                foreach (var rank in ranks)
                {
                    Ranks.Add (new Rank ()
                    {
                        RankLetter = rank,
                            RankName = $"{rank} Rank"
                    });
                }
            }

            if (Items.Count () == 0)
            {
                Items.AddRange (new List<Item> ()
                {
                    new Item () { Name = "Abacus", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Acid (vial)", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Adamantine Bar", IsTradeOnly = false, GoldCost = 1000 },
                        new Item () { Name = "Airship", IsTradeOnly = false, GoldCost = 20000 },
                        new Item () { Name = "Alchemist's Fire (flask)", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Alchemist's Supplies", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Amulet", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Antitoxin", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Arrow", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Arrows (20)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Assassin's Blood (Ingested)", IsTradeOnly = false, GoldCost = 150 },
                        new Item () { Name = "Backpack", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Bagpipes", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Ball Bearings (Bag of 1,000)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Barrel", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Basic Poison", IsTradeOnly = false, GoldCost = 100 },
                        new Item () { Name = "Basket", IsTradeOnly = false, SilverCost = 4 },
                        new Item () { Name = "Battleaxe", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Bedroll", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Bell", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Bit and bridle", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Blanket", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Block and Tackle", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Blowgun", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Blowgun Needle", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Blowgun Needles (50)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Book", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Breastplate", IsTradeOnly = false, GoldCost = 400 },
                        new Item () { Name = "Brewer's Supplies", IsTradeOnly = false, GoldCost = 20 },
                        new Item () { Name = "Bucket", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Bullseye Lantern", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Burglar's Pack", IsTradeOnly = false, GoldCost = 16 },
                        new Item () { Name = "Burnt Othur Fumes (Inhaled)", IsTradeOnly = false, GoldCost = 500 },
                        new Item () { Name = "Calligrapher's Supplies", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Caltrops", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Caltrops (20)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Camel", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Candle", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Canoe", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Canvas (1 sq. yd.)", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Carpenter's Tools", IsTradeOnly = false, GoldCost = 8 },
                        new Item () { Name = "Carriage", IsTradeOnly = false, GoldCost = 100 },
                        new Item () { Name = "Carrion Crawler Mucus (Contact)", IsTradeOnly = false, GoldCost = 200 },
                        new Item () { Name = "Cart", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Cartographer's Tools", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Chain (10 feet)", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Chain Mail", IsTradeOnly = false, GoldCost = 75 },
                        new Item () { Name = "Chain Shirt", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Chalk (1 piece)", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Chariot", IsTradeOnly = false, GoldCost = 250 },
                        new Item () { Name = "Chest", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Chicken", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Cinnamon", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Climber's Kit", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Cloves", IsTradeOnly = false, GoldCost = 3 },
                        new Item () { Name = "Club", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Cobbler's Tools", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Common Clothes", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Component Pouch", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Cook's Utensils", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Copper", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Costume Clothes", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Cotton Cloth (1 sq. yd.)", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Cow", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Crossbow Bolt", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Crossbow Bolt Case", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Crossbow Bolts (20)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Crowbar", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Crystal", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Dagger", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Dancing Monkey Fruit", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Dart", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Dice Set", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Diplomat's Pack", IsTradeOnly = false, GoldCost = 39 },
                        new Item () { Name = "Disguise Kit", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Donkey", IsTradeOnly = false, GoldCost = 8 },
                        new Item () { Name = "Draft Horse", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Dragonchess Set", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Drow Poison (Injury)", IsTradeOnly = false, GoldCost = 200 },
                        new Item () { Name = "Drum", IsTradeOnly = false, GoldCost = 6 },
                        new Item () { Name = "Dulcimer", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Dungeoneer's Pack", IsTradeOnly = false, GoldCost = 12 },
                        new Item () { Name = "Elephant", IsTradeOnly = false, GoldCost = 200 },
                        new Item () { Name = "Emblem", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Entertainer's Pack", IsTradeOnly = false, GoldCost = 40 },
                        new Item () { Name = "Essence of Ether (Inhaled)", IsTradeOnly = false, GoldCost = 300 },
                        new Item () { Name = "Exotic Saddle", IsTradeOnly = false, GoldCost = 60 },
                        new Item () { Name = "Explorer's Pack", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Feed (per day)", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Fine Clothes", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Fishing Tackle", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Flail", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Flask", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Flour", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Flute", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Forgery Kit", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Galley", IsTradeOnly = false, GoldCost = 30000 },
                        new Item () { Name = "Ginger", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Glaive", IsTradeOnly = false, GoldCost = 20 },
                        new Item () { Name = "Glass Bottle", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Glassblower's Tools", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Goat", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Gold", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Grappling Hook", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Greataxe", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Greatclub", IsTradeOnly = false, SilverCost = 2 },
                        new Item () { Name = "Greater Healing Potion", IsTradeOnly = false, GoldCost = 200 },
                        new Item () { Name = "Greatsword", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Halberd", IsTradeOnly = false, GoldCost = 20 },
                        new Item () { Name = "Half Plate Armor", IsTradeOnly = false, GoldCost = 750 },
                        new Item () { Name = "Hammer", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Hand Crossbow", IsTradeOnly = false, GoldCost = 75 },
                        new Item () { Name = "Handaxe", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Healer's Kit", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Healing Potion", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Heavy Crossbow", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Hempen Rope (50 feet)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Herbalism Kit", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Hide Armor", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Holy Water (flask)", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Hooded Lantern", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Horn", IsTradeOnly = false, GoldCost = 3 },
                        new Item () { Name = "Hourglass", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Hunting Trap", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Ink (1-ounce bottle)", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Ink Pen", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Insect Repellent (block of incense)", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Insect Repellent (greasy salve)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Iron", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Iron Pot", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Iron Spikes", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Iron Spikes (10)", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Javelin", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Jeweler's Tools", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Jug", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Keelboat", IsTradeOnly = false, GoldCost = 3000 },
                        new Item () { Name = "Ladder (10-foot)", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Lamp", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Lance", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Leather Armor", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Leatherworker's Tools", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Light Crossbow", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Light Hammer", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Linen (1 sq. yd.)", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Lock", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Longbow", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Longship", IsTradeOnly = false, GoldCost = 10000 },
                        new Item () { Name = "Longsword", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Lute", IsTradeOnly = false, GoldCost = 35 },
                        new Item () { Name = "Lyre", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Mace", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Magnifying Glass", IsTradeOnly = false, GoldCost = 100 },
                        new Item () { Name = "Malice (Inhaled)", IsTradeOnly = false, GoldCost = 250 },
                        new Item () { Name = "Manacles", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Map or Scroll Case", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Mason's Tools", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Mastiff", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Maul", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Menga leaves (1 ounce)", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Merchant's Scale", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Mess Kit", IsTradeOnly = false, SilverCost = 2 },
                        new Item () { Name = "Midnight Tears (Ingested)", IsTradeOnly = false, GoldCost = 1500 },
                        new Item () { Name = "Military Saddle", IsTradeOnly = false, GoldCost = 20 },
                        new Item () { Name = "Miner's Pick", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Monster Hunter's Pack", IsTradeOnly = false, GoldCost = 33 },
                        new Item () { Name = "Morningstar", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Mule", IsTradeOnly = false, GoldCost = 8 },
                        new Item () { Name = "Navigator's Tools", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Net", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Oil (flask)", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Oil of Taggit (contact)", IsTradeOnly = false, GoldCost = 400 },
                        new Item () { Name = "Orb", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Ox", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Pack Saddle", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Padded Armor", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Painter's Supplies", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Pale Tincture (Ingested)", IsTradeOnly = false, GoldCost = 250 },
                        new Item () { Name = "Pan Flute", IsTradeOnly = false, GoldCost = 12 },
                        new Item () { Name = "Paper (one sheet)", IsTradeOnly = false, SilverCost = 2 },
                        new Item () { Name = "Parchment (one sheet)", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Pepper", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Perfume (vial)", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Pig", IsTradeOnly = false, GoldCost = 3 },
                        new Item () { Name = "Pike", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Pitcher", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Piton", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Plate Armor", IsTradeOnly = false, GoldCost = 1500 },
                        new Item () { Name = "Platinum", IsTradeOnly = false, GoldCost = 500 },
                        new Item () { Name = "Playing Card Set", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Poisoner's Kit", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Pole (10-foot)", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Pony", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Portable Ram", IsTradeOnly = false, GoldCost = 4 },
                        new Item () { Name = "Potion of Climbing", IsTradeOnly = false, GoldCost = 100 },
                        new Item () { Name = "Potter's Tools", IsTradeOnly = false, GoldCost = 19 },
                        new Item () { Name = "Pouch", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Priest's Pack", IsTradeOnly = false, GoldCost = 19 },
                        new Item () { Name = "Purple Worm Poison (Injury)", IsTradeOnly = false, GoldCost = 2000 },
                        new Item () { Name = "Quarterstaff", IsTradeOnly = false, SilverCost = 2 },
                        new Item () { Name = "Quiver", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Rain Catcher", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Rapier", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Rations (1 day)", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Reliquary", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Riding Horse", IsTradeOnly = false, GoldCost = 75 },
                        new Item () { Name = "Riding Saddle", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Ring Mail", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Robes", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Rod", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Rowboat", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Ryath Root", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Sack", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Saddlebags", IsTradeOnly = false, GoldCost = 4 },
                        new Item () { Name = "Saffron", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Sailing Ship", IsTradeOnly = false, GoldCost = 10000 },
                        new Item () { Name = "Salt", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Scale Mail", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Scholar's Pack", IsTradeOnly = false, GoldCost = 40 },
                        new Item () { Name = "Scimitar", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Sealing Wax", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Serpent Venom (Injury)", IsTradeOnly = false, GoldCost = 200 },
                        new Item () { Name = "Shawm", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Sheep", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Shield", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Shortbow", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Shortsword", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Shovel", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Sickle", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Signal Whistle", IsTradeOnly = false, CopperCost = 5 },
                        new Item () { Name = "Signet Ring", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Silk (1 sq. yd.)", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Silk Rope (50 feet)", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Silver", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Sinda Berries (10)", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Sled", IsTradeOnly = false, GoldCost = 20 },
                        new Item () { Name = "Sledgehammer", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Sling", IsTradeOnly = false, SilverCost = 1 },
                        new Item () { Name = "Sling Bullets (20)", IsTradeOnly = false, CopperCost = 4 },
                        new Item () { Name = "Smith's Tools", IsTradeOnly = false, GoldCost = 20 },
                        new Item () { Name = "Soap", IsTradeOnly = false, CopperCost = 2 },
                        new Item () { Name = "Spear", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Spellbook", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Spiked Armor", IsTradeOnly = false, GoldCost = 75 },
                        new Item () { Name = "Splint Armor", IsTradeOnly = false, GoldCost = 200 },
                        new Item () { Name = "Sprig of Mistletoe", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Spyglass", IsTradeOnly = false, GoldCost = 1000 },
                        new Item () { Name = "Stabling (per day)", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Staff", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Steel Mirror", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Studded Leather Armor", IsTradeOnly = false, GoldCost = 45 },
                        new Item () { Name = "Tankard", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Thieves' Tools", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Three-Dragon Ante Set", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Tinderbox", IsTradeOnly = false, SilverCost = 5 },
                        new Item () { Name = "Tinker's Tools", IsTradeOnly = false, GoldCost = 50 },
                        new Item () { Name = "Torch", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Torpor (Ingested)", IsTradeOnly = false, GoldCost = 600 },
                        new Item () { Name = "Totem", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Traveler's Clothes", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Trident", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Truth Serum (Ingested)", IsTradeOnly = false, GoldCost = 150 },
                        new Item () { Name = "Two-Person Tent", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Vial", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Viol", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Wagon", IsTradeOnly = false, GoldCost = 35 },
                        new Item () { Name = "Wand", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "War Pick", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Warhammer", IsTradeOnly = false, GoldCost = 15 },
                        new Item () { Name = "Warhorse", IsTradeOnly = false, GoldCost = 400 },
                        new Item () { Name = "Warm Clothes, Common", IsTradeOnly = false, GoldCost = 6 },
                        new Item () { Name = "Warm Clothes, Fine", IsTradeOnly = false, GoldCost = 30 },
                        new Item () { Name = "Warm Clothes, Traveler's", IsTradeOnly = false, GoldCost = 8 },
                        new Item () { Name = "Warship", IsTradeOnly = false, GoldCost = 25000 },
                        new Item () { Name = "Waterskin", IsTradeOnly = false, SilverCost = 2 },
                        new Item () { Name = "Weaver's Tools", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Wheat", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Whetstone", IsTradeOnly = false, CopperCost = 1 },
                        new Item () { Name = "Whip", IsTradeOnly = false, GoldCost = 2 },
                        new Item () { Name = "Wildroot", IsTradeOnly = false, GoldCost = 25 },
                        new Item () { Name = "Woodcarver's Tools", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Wooden Staff", IsTradeOnly = false, GoldCost = 5 },
                        new Item () { Name = "Wukka Nut", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Wyvern Poison (Injury)", IsTradeOnly = false, GoldCost = 1200 },
                        new Item () { Name = "Yahcha", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Yew Wand", IsTradeOnly = false, GoldCost = 10 },
                        new Item () { Name = "Yklwa", IsTradeOnly = false, GoldCost = 1 },
                        new Item () { Name = "Zabou", IsTradeOnly = false, GoldCost = 10 }
                });
            }

            SaveChanges ();
        }
    }
}