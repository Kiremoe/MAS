namespace MAS1
{
    public class CharacterQuest
    {
        public static List<CharacterQuest> CharactersQuests { get; set; } = new List<CharacterQuest>();

        private Character _character;
        public Character Character
        {
            get => _character;
            set
            {
                _character = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        private Quest _quest;
        public Quest Quest
        {
            get => _quest;
            set
            {
                _quest = value ?? throw new ArgumentNullException(nameof(value));
                if (!_quest.CharactersQuests.Contains(this))
                {
                    _quest.CharactersQuests.Add(this);
                }
            }
        }

        public QuestStatus Status { get; set; }

        public enum QuestStatus
        {
            Claimed,
            ReadyToReturn,
            Done
        }

        public CharacterQuest(Character character, Quest quest, QuestStatus status)
        {
            Character = character;
            Quest = quest;
            Status = status;
            CharactersQuests.Add(this);
        }
    }
}
