namespace First.Models
{
    public class Data
    {
        private List<Superhero> SuperheroList;

        public List<Superhero> GetData()
        {
            return SuperheroList;
        }

        public int GetDataCount()
        {
            return SuperheroList.Count;
        }
        //első tipp, nincs benne a videóban egészen
        public Task<List<Superhero>> GetDataAsync(int startIndex, int numberOfRecommend)
        {
            return Task.FromResult(
                SuperheroList
                    .Skip(startIndex)
                    .Take(numberOfRecommend)
                    .ToList());
        }

        /*
    new Superhero(1, "Superman", "Clark Kent", new List<string> { "Flight", "Super Strength", "Heat Vision", "X-Ray Vision" }),
    new Superhero(2, "Batman", "Bruce Wayne", new List<string> { "Martial Arts", "Detective Skills", "High Intelligence", "Technology" }),
    new Superhero(3, "Wonder Woman", "Diana Prince", new List<string> { "Super Strength", "Flight", "Lasso of Truth", "Combat Skills" }),
    new Superhero(4, "Spider-Man", "Peter Parker", new List<string> { "Wall Crawling", "Spider Sense", "Super Agility", "Web Shooting" }),
    new Superhero(5, "Iron Man", "Tony Stark", new List<string> { "Powered Armor", "Flight", "Energy Blasts", "Engineering Genius" }),
    new Superhero(6, "Captain America", "Steve Rogers", new List<string> { "Super Strength", "Enhanced Agility", "Shield Mastery", "Leadership" }),
    new Superhero(7, "Thor", "Thor Odinson", new List<string> { "Lightning Control", "Flight", "Super Strength", "Mjolnir" }),
    new Superhero(8, "Hulk", "Bruce Banner", new List<string> { "Super Strength", "Regeneration", "Durability", "Thunder Clap" }),
    new Superhero(9, "Black Panther", "T'Challa", new List<string> { "Enhanced Senses", "Martial Arts", "Vibranium Suit", "Agility" }),
    new Superhero(10, "Doctor Strange", "Stephen Strange", new List<string> { "Magic", "Teleportation", "Astral Projection", "Time Manipulation" }),
    new Superhero(11, "Flash", "Barry Allen", new List<string> { "Super Speed", "Time Travel", "Phasing", "Accelerated Healing" }),
    new Superhero(12, "Green Lantern", "Hal Jordan", new List<string> { "Power Ring", "Flight", "Energy Constructs", "Force Fields" }),
    new Superhero(13, "Aquaman", "Arthur Curry", new List<string> { "Underwater Breathing", "Super Strength", "Telepathy with Sea Life", "Trident Mastery" }),
    new Superhero(14, "Scarlet Witch", "Wanda Maximoff", new List<string> { "Chaos Magic", "Telekinesis", "Reality Manipulation", "Energy Projection" }),
    new Superhero(15, "Black Widow", "Natasha Romanoff", new List<string> { "Martial Arts", "Espionage", "Marksmanship", "Acrobatics" }),
    new Superhero(16, "Hawkeye", "Clint Barton", new List<string> { "Expert Archer", "Swordsmanship", "Tactics", "Marksmanship" }),
    new Superhero(17, "Wolverine", "Logan", new List<string> { "Regeneration", "Adamantium Claws", "Enhanced Senses", "Longevity" }),
    new Superhero(18, "Deadpool", "Wade Wilson", new List<string> { "Regeneration", "Swordsmanship", "Marksmanship", "Fourth Wall Awareness" }),
    new Superhero(19, "Cyclops", "Scott Summers", new List<string> { "Optic Blasts", "Leadership", "Combat Training", "Strategic Thinking" }),
    new Superhero(20, "Storm", "Ororo Munroe", new List<string> { "Weather Control", "Flight", "Lightning Manipulation", "Wind Manipulation" })
};
        */

    }

    public class Superhero
    {
        private int Id {  get; set; }
        private string Name {  get; set; }
        private string RealName {  get; set; }
        private List<string> Powers { get; set; } = new();

        public Superhero(int id, string name, string realName, List<string> powers)
        {
            Id = id;
            Name = name;
            RealName = realName;
            Powers = powers;
        }
    }
}
