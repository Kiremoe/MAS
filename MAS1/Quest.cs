namespace MAS1
{
    public class Quest : IGamePiece
    {
        public static List<Quest> Quests { get; set; } = new List<Quest>();

        private int _id;
        public int Id
        {
            get { return _id; }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
        }

        public string Name { get; set; }
        public string? Goal { get; set; }
        public string? Description { get; set; }
        public int RewardValue { get; set; }
        public List<Item>? RewardItems { get; set; }

        private List<CharacterQuest> _charactersQuests;
        public List<CharacterQuest> CharactersQuests
        {
            get => _charactersQuests;
            set
            {
                if (value == null) { throw new ArgumentNullException(nameof(value)); }
                _charactersQuests = value;
                // Reasurence in CharacterQuests
            }
        }

        public Quest(string name, string? goal, string? description, int rewardValue, List<Item>? rewardItems)
        {
            int maxid = 0;
            foreach(Quest quest in Quests)
            {
                if (quest.Id > maxid) { maxid = quest.Id; }
            }
            _id = maxid+1;
            _creationDate = DateTime.UtcNow;
            Goal = goal;
            Description = description;
            CharactersQuests = new List<CharacterQuest>();
            RewardValue = rewardValue;
            RewardItems = rewardItems;
            Quests.Add(this);
        }

        public Quest(string name) : this(name, null, null, 0, null) { }
    }
}
